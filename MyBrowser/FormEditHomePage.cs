using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyBrowser
{
    public partial class FormEditHomePage : Form
    {
        private BrowserManager browserManager;

        public FormEditHomePage(ref BrowserManager browserManager)
        {
            InitializeComponent();
            this.browserManager = browserManager;
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// we pass the new home page url to browserManager class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            String newHP = newHomePage.Text;
            if (validateURL(newHP))
            {
                browserManager.HomePage = newHP;
                Close();
            }
            else
            {
                MessageBox.Show("Wrong URL", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool validateURL(string input)
        {
            return Regex.IsMatch(input, "(https?)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]");
        }
    }
}
