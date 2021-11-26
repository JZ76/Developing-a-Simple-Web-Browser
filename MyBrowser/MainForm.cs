using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBrowser
{
    public partial class MainForm : Form
    {
        private BrowserManager browserManager;

        public MainForm(ref BrowserManager browserManager)
        {
            InitializeComponent();
            this.browserManager = browserManager;
            loadHistory();
            loadFavorites();
            //register Changed event
            browserManager.Changed += AddURLToHistoryListBox;
            //register Edited event
            browserManager.Edited += AfterEditInFavorite;
            startNewTabWithURL(ref browserManager, browserManager.HomePage);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startNewTabWithURL(ref BrowserManager browserManager, String url)
        {
            //initial a new MyTabPage
            MyTabPage tp = new MyTabPage(ref browserManager, url);
            //get the url in URL TextBox
            URL.Text = url;
            //tabControl adds MyTabPage
            tabControl1.TabPages.Add(tp);
            //switch to this MyTabPage
            tabControl1.SelectedTab = tp;
            //remember to change the color of the button
            addToFavorites.ForeColor = browserManager.isInFavorite(url) ? Color.Lime : Color.Red;
        }

        private void previous_Click(object sender, EventArgs e)
        {
            //get current MyTabPage
            MyTabPage tabPage = (MyTabPage) tabControl1.SelectedTab;
            tabPage.previous();
            URL.Text = tabPage.getCurrURL();
            //decide whether the next and previous button can show up
            //if the index is the last one, then don't have to show the next button
            next.Visible = tabPage.Index < tabPage.urlList.Count - 1;
            //if the index is the first one or -1, don't have to show the previous button
            previous.Visible = tabPage.Index > 0;
        }

        private void next_Click(object sender, EventArgs e)
        {
            MyTabPage tabPage = (MyTabPage) tabControl1.SelectedTab;
            tabPage.next();
            URL.Text = tabPage.getCurrURL();
            previous.Visible = tabPage.Index > 0;
            next.Visible = tabPage.Index < tabPage.urlList.Count - 1;
        }

        private void reload_Click(object sender, EventArgs e)
        {
            MyTabPage temp = (MyTabPage) tabControl1.SelectedTab;
            //send the request again
            temp.reload(temp.getCurrURL());
            URL.Text = temp.getCurrURL();
        }

        private void reload_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                MyTabPage temp = (MyTabPage) tabControl1.SelectedTab;
                temp.reload(temp.getCurrURL());
                URL.Text = temp.getCurrURL();
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            MyTabPage tp = new MyTabPage(ref browserManager);
            tabControl1.TabPages.Add(tp);
            tp.Text = "about:blank";
            tabControl1.SelectedTab = tp;
            //remember to empty the URL textbox
            URL.Text = "";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //the number of tabpage must greater than one
            if (tabControl1.TabPages.Count > 1)
            {
                //remove the selected one
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                //and then, the selected become the last one
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                MyTabPage temp = (MyTabPage) tabControl1.SelectedTab;
                URL.Text = temp.getCurrURL();
            }
        }

        /// <summary>
        /// this is left mouse button click on the homepage button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homePage_Click(object sender, EventArgs e)
        {
            MyTabPage tabPage = new MyTabPage(ref browserManager, browserManager.HomePage);
            tabControl1.TabPages.Add(tabPage);
            tabControl1.SelectedTab = tabPage;
            URL.Text = tabPage.getCurrURL();
        }

        /// <summary>
        /// this is right mouse button click on the homepage button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homePage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //a new form kicks in
                FormEditHomePage homepageForm = new FormEditHomePage(ref browserManager);
                homepageForm.ShowDialog();
            }
        }

        /// <summary>
        /// we have to alter some button when the selected tabpage changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyTabPage tabPage = (MyTabPage) tabControl1.SelectedTab;
            previous.Visible = tabPage.Index > 0;
            next.Visible = tabPage.Index < tabPage.urlList.Count - 1;
            URL.Text = tabPage.getCurrURL();
            addToFavorites.ForeColor = browserManager.isInFavorite(URL.Text) ? Color.Lime : Color.Red;
        }

        /// <summary>
        /// Time complexity O = N*logN
        /// </summary>
        private void loadFavorites()
        {
            //here I use LINQ, which is very helpful
            Dictionary<String, URL> favourites = browserManager.getFavoritesList();
            var SortedByTime = from d in favourites
                                             orderby d.Value.Time.ToFileTime() //sort them by time asc
                                             select d.Value;
            foreach (URL favourite in SortedByTime)
            {
                //we have to include white space here, and will use that later
                FavoritesList.Items.Add(favourite.Title + " --- " + favourite.Url);
            }
        }

        private void Favorites_Click(object sender, EventArgs e)
        {
            //if on, turn it off. if off, turn it on
            FavoritesList.Visible = !FavoritesList.Visible;
        }
        
        private void addToFavorites_Click(object sender, EventArgs e)
        {
            MyTabPage tabPage = (MyTabPage) tabControl1.SelectedTab;
            //first of all, we have to whether it in the list or not,
            //if it in the list already, then delete it
            //if not, add it
            if (browserManager.isInFavorite(URL.Text))
            {
                browserManager.deleteFromFavorite(URL.Text);
                addToFavorites.ForeColor = Color.Red;
                FavoritesList.Items.Remove(tabPage.Text + " --- " + URL.Text);
            }
            else
            {
                if (validateURL(URL.Text))
                {
                    browserManager.addToFavorites(URL.Text, new URL(tabPage.Text, URL.Text, DateTime.Now));
                    addToFavorites.ForeColor = Color.Lime;
                    FavoritesList.Items.Add(tabPage.Text + " --- " + URL.Text);
                }
            }
        }

        //we have to keep where is the pointer point at
        private int FavoriteListIndex;
        //and the X and Y of the pointer
        private Point mousePosition;

        private void FavoritesList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //we need to know which item in the ListBox is chosen
                int index = FavoritesList.IndexFromPoint(e.Location);
                mousePosition = e.Location;
                FavoriteListIndex = index;
                //if the pointer in the items area which is not empty area
                if (index >= 0)
                {
                    //show the contextMenu
                    contextMenuFavorite.Show(FavoritesList, e.Location);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //since url doesn't contains white space, we can split it by white space, and select the last item
            //in the string array
            String[] temp = FavoritesList.Items[FavoriteListIndex].ToString().Split(' ');
            //new form kicks in
            EditFavourite editFavourite = new EditFavourite(ref browserManager, temp[temp.Length - 1],
                browserManager.getTitle(temp[temp.Length - 1]));
            editFavourite.Location =
                new Point(SystemInformation.WorkingArea.Width / 2 + mousePosition.X, mousePosition.Y);
            editFavourite.ShowDialog();
        }
        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] temp = FavoritesList.Items[FavoriteListIndex].ToString().Split(' ');
            //delete selected one
            FavoritesList.Items.RemoveAt(FavoriteListIndex);
            browserManager.deleteFromFavorite(temp[temp.Length - 1]);
            MyTabPage tabPage = (MyTabPage) tabControl1.SelectedTab;
            if (tabPage.getCurrURL().Equals(temp[temp.Length - 1]))
            {
                addToFavorites.ForeColor = Color.Red;
            }
        }
        
        private void AfterEditInFavorite(URL url)
        {
            FavoritesList.Items.RemoveAt(FavoriteListIndex);
            FavoritesList.Items.Insert(FavoriteListIndex,url.Title + " --- " + url.Url);
            MyTabPage tabPage = (MyTabPage) tabControl1.SelectedTab;
            addToFavorites.ForeColor = browserManager.isInFavorite(tabPage.getCurrURL()) ? Color.Lime : Color.Red;
        }
        
        /// <summary>
        /// open the url that user selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FavoritesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = FavoritesList.SelectedIndex;
            if (index != -1)
            {
                FavoritesList.Visible = false;
                String[] temp = FavoritesList.Items[index].ToString().Split(' ');
                startNewTabWithURL(ref browserManager, temp[temp.Length - 1]);
            }
        }

        /// <summary>
        /// Time complexity O = N
        /// </summary>
        private void loadHistory()
        {
            List<URL> list = browserManager.getHistoryList();
            foreach (URL url in list)
            {
                historyList.Items.Add(url.Title + " --- " + url.Url);
            }
        }


        public void AddURLToHistoryListBox(URL url)
        {
            historyList.Items.Insert(0, url.Title + " --- " + url.Url);
        }

        private void history_Click(object sender, EventArgs e)
        {
            historyList.Visible = !historyList.Visible;
        }

        private int historyListIndex;

        private void historyList_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = historyList.IndexFromPoint(e.Location);
                historyListIndex = index;
                if (index >= 0)
                {
                    contextMenuHistory.Show(historyList, e.Location);
                }
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            historyList.Items.RemoveAt(historyListIndex);
            browserManager.deleteFromHistory(historyListIndex);
        }

        private void historyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = historyList.SelectedIndex;
            if (index != -1)
            {
                historyList.Visible = false;
                startNewTabWithURL(ref browserManager, browserManager.getAHistoryByIndex(index));
            }
        }

        private bool validateURL(string input)
        {
            //can only start with http:// or https://,
            //then only [-A-Za-z0-9+&@#/%?=~_|!:,.;] is allowed in the middle,
            //and [-A-Za-z0-9+&@#/%=~_|] is allowed at the end
            return Regex.IsMatch(input, "(https?)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]");
        }

        private void URL_KeyDown(object sender, KeyEventArgs e)
        {
            MyTabPage temp = (MyTabPage) tabControl1.SelectedTab;
            //the Enter key is the trigger
            if (e.KeyCode == Keys.Enter)
            {
                if (validateURL(URL.Text))
                {
                    temp.sendHttpRequest(URL.Text);
                    previous.Visible = temp.Index > 0;
                    addToFavorites.ForeColor = browserManager.isInFavorite(URL.Text) ? Color.Lime : Color.Red;
                }
                else
                {
                    temp.Text = "Wrong URL";
                }
            }
        }

        /// <summary>
        /// this method may very slow, because it has to send a lot http request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bulk_Click(object sender, EventArgs e)
        {
            //keep asking until break;
            while (true)
            {
                DialogResult dr = bulkDownload.ShowDialog();
                String filename = bulkDownload.FileName;
                String pattern = @".txt\z";
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    //we have to make sure it is a txt file first
                    if (!Regex.IsMatch(filename, pattern))
                    {
                        MessageBox.Show("Not a txt file: " + filename, "Wrong file format", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        //read the file
                        List<String> urls = browserManager.getBulkDownloadURLs(filename);
                        //start a new page
                        MyTabPage tp = new MyTabPage(ref browserManager);
                        tabControl1.TabPages.Add(tp);
                        tp.Text = "Bulk Download";
                        tabControl1.SelectedTab = tp;
                        URL.Text = "";
                        //download one by one
                        foreach (string url in urls)
                        {
                            if (url != "")
                            {
                                if (validateURL(url))
                                {
                                    tp.bulkDownload(url);
                                }
                                else
                                {
                                    tp.newPanel.Text += "Wrong URL" + "\r\n";
                                }
                            }
                            else
                            {
                                tp.newPanel.Text += "Empty line" + "\r\n";
                            }
                        }

                        break;
                    }
                }
                else if (dr == DialogResult.Cancel || dr == DialogResult.No)
                {
                    break;
                }
            }
        }
    }
}
