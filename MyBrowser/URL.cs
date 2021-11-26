using System;
using System.Text.RegularExpressions;

namespace MyBrowser
{
    public class URL
    {
        private String title;
        private String url;
        private DateTime time;

        public URL(String title, String url, DateTime time)
        {
            this.time = time;
            this.title = title;
            this.url = url;
        }
        /// <summary>
        /// we have to overwrite the ToString method,
        /// so we could serialization in a way as we want
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            //this is actually a danger way to add "|" as split sign,
            //Although it won't shows in url and time,
            //the user may input this in the title
            return title + "|" + url + "|" + time.ToFileTime();
        }
        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Url
        {
            get => url;
            set => url = value;
        }

        public DateTime Time
        {
            get => time;
            set => time = value;
        }
    }
}