using System;
using System.Collections.Generic;
using System.IO;

namespace MyBrowser
{
    /// <summary>
    /// this is a generic delegate
    /// </summary>
    /// <typeparam name="T">can be a List or a dictionary</typeparam>
    public delegate void SpecificStructure<T>(ref T t,String[] temp,String line);
    public class FileIO
    {
        private String[] temp = new string[3];
        /// <summary>
        /// we have to write history and favourite back to a file,
        /// so the information can be stored
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fileName">which is a path of target file</param>
        /// <param name="append">whether we have to overwrite the file</param>
        public void writeToFile(String text, String fileName,bool append)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName, append);
                sw.WriteLine(text);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e+" Failed to load "+fileName);
                throw;
            }
        }
        /// <summary>
        /// this method will acts differently depends on what kinds of data structure comes in,
        /// reduce duplicate code
        /// </summary>
        /// <param name="t">the data structure</param>
        /// <param name="fileName"></param>
        /// <param name="structure">a delegate method</param>
        /// <typeparam name="T"></typeparam>
        public void readFile<T>(ref T t, String fileName, SpecificStructure<T> structure)
        {
            String line;
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //because it is reference, so we can change the original data structure
                        structure(ref t, temp, line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file ( "+fileName+" ) could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public String readHomePage(String fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    //only read one line
                    return sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file ( "+fileName+" ) could not be read:");
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}