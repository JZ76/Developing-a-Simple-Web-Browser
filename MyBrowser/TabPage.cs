using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MyBrowser
{
    /// <summary>
    /// the reason that inherit from TabPage is we seen each TabPage as an item in our browser,
    /// they have their own list of url, and if we want to our browser become multithreading,
    /// each thread can response for one TabPage
    /// </summary>
    class MyTabPage : TabPage
    {
        //newPanel shows the code of a website
        public RichTextBox newPanel = new RichTextBox();
        //because we have to move forward and backward on a tab,
        //so we need a list to keep all url that shown on this tab
        public List<String> urlList = new List<string>();
        //this is a pointer to indicate the position in the list
        private int index = -1;
        
        private BrowserManager browserManager;

        /// <summary>
        /// this constructor starts a rich text box in a new tab
        /// </summary>
        /// <param name="browserManager"></param>
        public MyTabPage(ref BrowserManager browserManager)
        {
            this.browserManager = browserManager;
            newPanel.Multiline = true;
            newPanel.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            newPanel.WordWrap = true;
            newPanel.SelectionFont = new Font("Arial", 13);
            newPanel.ReadOnly = true;
            newPanel.Parent = this;
            newPanel.Dock = DockStyle.Fill;
            newPanel.Show();
        }

        /// <summary>
        /// this is a overload constructor, starts with a url
        /// </summary>
        /// <param name="browserManager"></param>
        /// <param name="url"></param>
        public MyTabPage(ref BrowserManager browserManager, String url)
        {
            this.browserManager = browserManager;
            newPanel.Multiline = true;
            newPanel.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            newPanel.WordWrap = true;
            newPanel.SelectionFont = new Font("Arial", 13);
            newPanel.ReadOnly = true;
            newPanel.Parent = this;
            newPanel.Dock = DockStyle.Fill;
            sendHttpRequest(url);
            newPanel.Show();
        }

        /// <summary>
        /// the HttpWebRequest can only send Hyper Text Transfer Protocol or
        /// Hyper Text Transfer Protocol over SecureSocket Layer
        /// </summary>
        /// <param name="url"></param>
        public void sendHttpRequest(String url)
        {
            try
            {
                //shake hand first
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.KeepAlive = false;
                request.Method = "Get";
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                using (StreamReader readStream = new StreamReader(response.GetResponseStream()))
                {
                    String temp = readStream.ReadToEnd();
                    this.Text = getTitle(temp).Trim() + Convert.ToInt32(response.StatusCode);
                    urlList.Add(url);
                    //the index becomes the last one
                    index = urlList.Count - 1;
                    newPanel.Text = temp;
                    //here we inform the browserManager a new url should be added in the history
                    browserManager.addToHistory(new URL(Text, url, DateTime.Now));
                }
            }
            catch (WebException e)
            {
                string pattern = "^\\(+[0-9]*";
                Regex rx = new Regex(pattern);
                //if the exception is a status error, we will out put the status code and info
                //otherwise, output all error message
                newPanel.Text = rx.IsMatch(e.Message.Split(':')[1].Trim()) ? e.Message.Split(':')[1] : e.Message;
                Text = "Web Error";
                urlList.Add(url);
                index = urlList.Count - 1;
                browserManager.addToHistory(new URL(Text, url, DateTime.Now));
            }
            catch (Exception e)
            {
                newPanel.Text = e.Message;
                Text = "Error";
                urlList.Add(url);
                index = urlList.Count - 1;
                browserManager.addToHistory(new URL(Text, url, DateTime.Now));
            }
        }

        public void reload(String url)
        {
            int temp = index;
            sendHttpRequest(url);
            index = temp;
            urlList.RemoveAt(urlList.Count - 1);
        }

        /// <summary>
        /// move previous
        /// </summary>
        /// <returns></returns>
        public int previous()
        {
            if (index > 0)
            {
                int temp = index - 1;
                sendHttpRequest(urlList[--index]);
                index = temp;
                urlList.RemoveAt(urlList.Count - 1);
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// move next
        /// </summary>
        /// <returns></returns>
        public int next()
        {
            //check the range of index
            if (index < urlList.Count - 1)
            {
                int temp = index + 1;
                //because after sending the request the index will become the last one,
                sendHttpRequest(urlList[++index]);
                //so we have to change index back to the original plus one,
                index = temp;
                //and don't forget to remove the last one in the list, since it is not a new url
                urlList.RemoveAt(urlList.Count - 1);
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public void bulkDownload(String url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.KeepAlive = false;
                request.Method = "Get";
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                //convert the http status code into int
                String s = "<" + Convert.ToInt32(response.StatusCode) + "> ";
                using (StreamReader readStream = new StreamReader(response.GetResponseStream()))
                {
                    String temp = readStream.ReadToEnd();
                    //get the size of whole code
                    s += "<" + System.Text.ASCIIEncoding.ASCII.GetByteCount(temp) + "> ";
                    s += "<" + url + ">" + "\r\n";
                    newPanel.Text += s;
                }
            }
            catch (WebException webException)
            {
                try
                {
                    //if failed, we get the status code from the WebException
                    HttpStatusCode wRespStatusCode = ((HttpWebResponse) webException.Response).StatusCode;
                    newPanel.Text += "<" + Convert.ToInt32(wRespStatusCode) + "> " + "<0> " + "<" + url + "> " + "\r\n";
                }
                catch (Exception e)
                {
                    newPanel.Text += e.Message + "\r\n";
                }
            }
            catch (Exception e)
            {
                newPanel.Text += e.Message + "\r\n";
            }
        }

        /// <summary>
        /// we use regular expression to filter the title in the return code
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        private String getTitle(String strUrl)
        {
            //find the sign of title
            String pattern = @"<title>(?<title>[^<]*)</title>";
            String answer = Regex.Match(strUrl, pattern).ToString();
            //delete the starting sign
            answer = answer.Replace("<title>", "");
            //delete the ending sign
            answer = answer.Replace("</title>", "");
            return answer;
        }

        /// <summary>
        /// return which url is the current tab shown
        /// </summary>
        /// <returns></returns>
        public String getCurrURL()
        {
            return index != -1 ? urlList[index] : "";
        }

        public int Index => index;
    }
}
