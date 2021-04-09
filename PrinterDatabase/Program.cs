using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Configuration;

namespace PrinterDatabase
{
    static class Program
    {
        static string directoryPath = @"C:\Windows\System32\spool\PRINTERS";
        static string backupFolderPath = @"G:\Backup";

        static void Main()
        {

            backupFolderPath = ConfigurationManager.AppSettings["backupPath"];
            if (TestDatabaseConnection() && VerifyBackupFolder())
            {
                while (true)
                {
                    DirectoryInfo d = new DirectoryInfo(directoryPath);
                    FileInfo[] Files = d.GetFiles("*.spl");
                    foreach (FileInfo file in Files)
                    {
                        Console.WriteLine("\n\n============" + DateTime.Now + "============");
                        Console.WriteLine(file.Name);
                        var data = DataExtractor.Extract(file.FullName);
                        CreateBackup(file.FullName, data.date + " " + data.time, data.meterID); //MEter ID = N§ Compteur 
                        DeleteFile(file.Name);
                        Thread.Sleep(3000);
                    }


                }
            }
        }
        public static bool TestDatabaseConnection()
        {
            return true;
        }
        public static bool VerifyBackupFolder()
        {
            bool exists = System.IO.Directory.Exists(backupFolderPath);

            if (!exists)

            {
                System.IO.Directory.CreateDirectory(backupFolderPath);
                Console.WriteLine("Backup Folder Created:  " + backupFolderPath);
            }
            return true;
        }
        public static void DeleteFile(string fileName)
        {
            string filepath = directoryPath + @"\" + fileName;
            File.Delete(filepath); // delete SPL File
            Console.WriteLine("File Deleted:  " + fileName);
            File.Delete(filepath); // delete SHL File
        }

        public static void CreateBackup(string sourcefilePath, string DateTime, string NsComputer)
        {

            string backupFilePath = backupFolderPath + "\\" + DateTime.Replace(@"/", "-").Replace(":", "-") + " " + NsComputer.Replace(" ", string.Empty) + ".txt";

            File.WriteAllLines(backupFilePath, File.ReadAllLines(sourcefilePath));
            Console.WriteLine("Backup Craeted:  " + backupFilePath);

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
