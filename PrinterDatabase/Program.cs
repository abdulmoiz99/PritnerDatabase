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
        static string directoryPath = @"C:\Windows\System32\spool\PRINTERS";
        static string backupFolderPath = @"G:\Backup";

        static void Main()
        {

            if (TestDatabaseConnection() && VerifyBackupFolder())
            {
                while (true)
                {
                    DirectoryInfo d = new DirectoryInfo(directoryPath);
                    FileInfo[] Files = d.GetFiles("*.spl");
                    foreach (FileInfo file in Files)
                    {
                        Console.WriteLine(file.Name);
                        CreateBackup(file.FullName, "06/04/2021 09:39:36", " 07 11653284 2");
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

            string backupFilePath = backupFolderPath + "\\" + DateTime.Replace(@"/", "-").Replace(":","-") + " " + NsComputer.Replace(" ", string.Empty) + ".txt";

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
