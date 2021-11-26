using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBrowser
{
    public partial class EditFavourite : Form
    {
        private BrowserManager browserManager;
        private String url;
        private String title;

        public EditFavourite(ref BrowserManager browserManager, String url, String title)
        {
            InitializeComponent();
            this.browserManager = browserManager;
            this.url = url;
            this.title = title;
            textBox1.Text = title;
            textBox2.Text = url;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// we get the title from textBox1 and url from textBox2,
        /// and pass them to browserManager class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            //because we will use "|" as spilt sign, so title must not contain this
            if (validateURL(textBox2.Text) && !textBox1.Text.Contains('|') && textBox1.Text.Length!=0)
            {
                browserManager.editFavoriteTitle(textBox1.Text, textBox2.Text, url);
                Close();
            }
            else
            {
                MessageBox.Show("Wrong URL or title contains \"|\" or title is empty", "Wrong", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool validateURL(string input)
        {
            return Regex.IsMatch(input, "(https?)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]");
        }
    }
}
