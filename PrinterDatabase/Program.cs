using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PrinterDatabase
{
    static class Program
    {
        static void Main()
        {
            ReadFile(@"D:\Documents\Visual Studio 2019\SPL\00137.SPL");
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
    }
}
