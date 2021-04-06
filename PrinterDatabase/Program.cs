using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;

namespace PrinterDatabase
{
    static class Program
    {

        static void Main()
        {
            DataExtractor.Extract(@"D:\Documents\Visual Studio 2019\SPL\00137.SPL");
            //File.Delete(@"C:\Windows\System32\spool\PRINTERS\00046.SPL");

            //System.Timers.Timer aTimer = new System.Timers.Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 1000;
            //aTimer.Enabled = true;

            //Console.Read();


            //ReadFile(@"D:\Documents\Visual Studio 2019\SPL\00137.SPL");
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            CheckNewFile();
        }

        public static void TestDatabaseConnection()
        {

        }

        public static void VerifyBackupFolder()
        {

        }

        public static bool CheckNewFile()
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Windows\System32\spool\PRINTERS");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.spl"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
                Console.WriteLine(file.Name);
            }
            return true;
        }

        public static void CreateBackup()
        {

        }
        /// <summary>
        /// Insert data into database
        /// </summary>
        /// 
        public static void PushData()
        {

        }
        public static void RemoveFiles()
        {

        }
    }
   
}
