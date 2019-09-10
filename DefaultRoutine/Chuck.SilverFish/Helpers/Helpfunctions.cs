using System;
using System.Collections.Generic;
using System.IO;
using Hearthbuddy.Windows;
using Chuck.SilverFish;
using log4net;

namespace SilverFish.Helpers
{
    /// <summary>
    ///     The helpfunctions.
    /// </summary>

    public class Helpfunctions
    {
        /// <summary>The logger for this type.</summary>
        private static readonly ILog Log = MainWindow.ChuckLog;
        public List<Playfield> storedBoards = new List<Playfield>();


        public static List<T> TakeList<T>(IEnumerable<T> source, int limit)
        {
            List<T> retlist = new List<T>();
            int i = 0;

            foreach (T item in source)
            {
                retlist.Add(item);
                i++;

                if (i >= limit) break;
            }
            return retlist;
        }


        public bool runningbot = false;

        private static Helpfunctions instance;

        public static Helpfunctions Instance
        {
            get { return instance ?? (instance = new Helpfunctions()); }
        }

        private Helpfunctions()
        {

            //System.IO.File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, "");
        }

        private bool writelogg = true;

        public void createNewLoggfile()
        {
            FileHelper.CreateEmptyFile(Settings.Instance.LogFilePath);
        }

        public DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public void ErrorLog(object obj)
        {
            Log.ErrorFormat(obj?.ToString());
        }

        public void InfoLog(object obj)
        {
            Log.InfoFormat(obj?.ToString());
        }

        public void WarnLog(object obj)
        {
            Log.WarnFormat(obj?.ToString());
        }

        private string sendbuffer = "";

        public void resetBuffer()
        {
            this.sendbuffer = "";
        }

        public void writeToBuffer(string data)
        {
            this.sendbuffer += "\r\n" + data;
        }

        public void writeBufferToFile()
        {
            bool writed = true;
            this.sendbuffer += "<EoF>";
            while (writed)
            {
                try
                {
                    File.WriteAllText(Settings.Instance.DataFolderPath + "crrntbrd.txt", this.sendbuffer);
                    writed = false;
                }
                catch(Exception ex)
                {
                    Instance.ErrorLog(ex);
                    writed = true;
                }
            }
            this.sendbuffer = "";
        }

        public void writeBufferToActionFile()
        {
            bool writed = true;
            this.sendbuffer += "<EoF>";
            this.ErrorLog("write to action file: " + sendbuffer);
            while (writed)
            {
                try
                {
                    File.WriteAllText(Settings.Instance.DataFolderPath + "actionstodo.txt", this.sendbuffer);
                    writed = false;
                }
                catch(Exception ex)
                {
                    Instance.ErrorLog(ex);
                    writed = true;
                }
            }
            this.sendbuffer = "";
        }



    }
}
