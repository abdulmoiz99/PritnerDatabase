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
        static FileSystemWatcher watcher;

        static void Main()
        {

            File.Delete(@"C:\Windows\System32\spool\PRINTERS\00046.SPL");

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            Console.Read();


            //ReadFile(@"D:\Documents\Visual Studio 2019\SPL\00137.SPL");
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            CheckNewFile();
        }
        public static void ReadFile(string path)
        {
            string time, date, pincode, totalUnit, totalValue;

            string[] lines = File.ReadAllLines(path);

            //For DateTime
            time = lines[4];
            date = time.Split(' ')[0];
            time = time.Replace(date, "");
            time = time.TrimStart(' ');
            Console.WriteLine("Time: " + time);
            Console.WriteLine("Date: " + date);

            //For Pincode
            pincode = lines[16] + lines[17];
            pincode = pincode.Replace(" ", "");
            pincode = pincode.Replace("*", "");
            Console.WriteLine("Pincode: " + pincode);

            //For Total Unit
            totalUnit = FindLine(lines, "Totales");
            totalUnit = totalUnit.Split(' ')[totalUnit.Split(' ').Length - 1];
            Console.WriteLine("Total Unit: " + totalUnit);

            //For Total Value
            totalValue = FindLine(lines, "Valeur");
            totalValue = totalValue.Split(' ')[totalValue.Split(' ').Length - 2];
            Console.WriteLine("Total Value: " + totalValue);
        }

        public static string FindLine(string[] lines, string word) 
        {
            foreach (string line in lines) 
            {
                if (line.Contains(word)) 
                {
                    return line;
                }
            }
            return string.Empty;
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
