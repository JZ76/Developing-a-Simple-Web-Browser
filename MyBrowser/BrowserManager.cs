using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyBrowser
{
    public class BrowserManager
    {
        public delegate void AddedToHistoryList(URL url);
        //Changed event is that if a new url added to history, we will inform the historyList in MainForm class that
        //it should add this url too
        public event AddedToHistoryList Changed;

        public delegate void EditInFavoriteList(URL url);
        //Edited event is if a favorite item changed by user, after we do the same change in favorite, we have to tell
        //FavoriteList in MainForm class that it should change that item too
        public event EditInFavoriteList Edited;

        private List<URL> history = new List<URL>();
        private Dictionary<String, URL> favorite = new Dictionary<string, URL>();
        private FileIO FileIO = new FileIO();
        private String homePage;
        //this means we have to keep three txt files and the exe file together
        private String path = System.Windows.Forms.Application.StartupPath;


        public BrowserManager()
        {
            //load everything from txt files
            load();
        }
        
        /// <summary>
        /// Delegate reduces a lot of code, we can only pass the way we want into FileIO, since both of them
        /// need to read multiple lines, the only difference is how to feed into data structures
        /// </summary>
        private void load()
        {
            FileIO.readFile(ref history, System.IO.Path.Combine(path, "History.txt"), loadToList);
            FileIO.readFile(ref favorite, System.IO.Path.Combine(path, "Favorite.txt"), loadToDic);
            homePage = FileIO.readHomePage(System.IO.Path.Combine(path, "Homepage.txt"));
        }

        public static void loadToList(ref List<URL> list, String[] temp, String line)
        {
            //Deserialization
            temp = line.Split('|');
            list.Add(new URL(temp[0], temp[1], DateTime.FromFileTime(long.Parse(temp[2]))));
        }

        public static void loadToDic(ref Dictionary<String, URL> dictionary, String[] temp, String line)
        {
            temp = line.Split('|');
            dictionary.Add(temp[1], new URL(temp[0], temp[1], DateTime.FromFileTime(long.Parse(temp[2]))));
        }

        public static void loadDownload(ref List<String> list, String[] temp, String line)
        {
            list.Add(line);
        }

        public string HomePage
        {
            get => homePage;
            set
            {
                //we have to keep the changes, so in the next boot, we will not lose it
                homePage = value;
                FileIO.writeToFile(value, System.IO.Path.Combine(path, "Homepage.txt"), false);
            }
        }

        /// <summary>
        /// if we don't consider writeback:
        /// Create: time complexity O = 1 
        /// Delete: time complexity O = 1 
        /// Update: time complexity O = 1 
        /// Retrieve: time complexity O = 1 
        /// </summary>
        /// <param name="surl"></param>
        /// <param name="url"></param>
        public void addToFavorites(String surl, URL url)
        {
            favorite.Add(surl, url);
            writeBackFavorite();
        }

        public void deleteFromFavorite(String key)
        {
            favorite.Remove(key);
            writeBackFavorite();
        }

        public void editFavoriteTitle(String newTitle, String newkey, String key)
        {
            //we have to keep timestamp the same as before, because it actually not a new added favorite
            DateTime temp = favorite[key].Time;
            favorite.Remove(key);
            URL url = new URL(newTitle, newkey, temp);
            favorite.Add(newkey, url);
            //we tell the MainForm can use that method here
            Edited(url);
            writeBackFavorite();
        }

        public Dictionary<String, URL> getFavoritesList()
        {
            return favorite;
        }

        public bool isInFavorite(String key)
        {
            return favorite.ContainsKey(key);
        }

        public String getTitle(String key)
        {
            return favorite[key].Title;
        }

        /// <summary>
        /// if we don't consider writeback:
        /// Create: time complexity O = N 
        /// Delete: time complexity O = N 
        /// Update: NULL
        /// Retrieve: time complexity O = 1 
        /// </summary>
        /// <param name="url"></param>
        public void addToHistory(URL url)
        {
            //because our history has to keep order by added time desc,
            //the new added url has to be inserted into the front
            history.Insert(0, url);
            writeBackHistory();
            //inform the historyList to do the same thing
            Changed(url);
        }

        public void deleteFromHistory(int index)
        {
            //here we will keep the index in history and historyList the same,
            //so it is easy to operate both of them
            history.RemoveAt(index);
            writeBackHistory();
        }

        public List<URL> getHistoryList()
        {
            return history;
        }

        public String getAHistoryByIndex(int index)
        {
            return history[index].Url;
        }

        /// <summary>
        /// after each changes, we will make the changes firmly
        /// </summary>
        private void writeBackFavorite()
        {
            String result = "";
            foreach (KeyValuePair<String, URL> kv in favorite)
            {
                result += kv.Value.ToString();
                result += "\r\n";
            }

            FileIO.writeToFile(result, System.IO.Path.Combine(path, "Favorite.txt"), false);
        }

        private void writeBackHistory()
        {
            String result = "";
            foreach (URL url in history)
            {
                result += url.ToString();
                result += "\r\n";
            }

            FileIO.writeToFile(result, System.IO.Path.Combine(path, "History.txt"), false);
        }

        public List<String> getBulkDownloadURLs(String filename)
        {
            List<String> urls = new List<String>();
            //using delegate again
            FileIO.readFile(ref urls, filename, loadDownload);
            return urls;
        }
    }
}