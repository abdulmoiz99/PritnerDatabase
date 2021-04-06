using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterDatabase
{
    struct Data
    {
        public string time, date, meterID, voucherID, powerQuantity, totalAmount, tvaTax, otherTax, pocAgent;
    }

    class DataExtractor
    {
        public static Data Extract(string path)
        {
            Data data;

            string[] lines = File.ReadAllLines(path);

            //For DateTime
            data.time = lines[4];
            data.date = data.time.Split(' ')[0];
            data.time = data.time.Replace(data.date, "");
            data.time = data.time.TrimStart(' ');
            Console.WriteLine("Time: " + data.time);
            Console.WriteLine("Date: " + data.date);

            //For Meter ID
            data.meterID = lines[7];
            data.meterID = data.meterID.Replace(" ", "");
            data.meterID = data.meterID.Split(':')[1];
            Console.WriteLine("Meter ID: " + data.meterID);

            //For Voucher ID (Pincode)
            data.voucherID = lines[16] + lines[17];
            data.voucherID = data.voucherID.Replace(" ", "");
            data.voucherID = data.voucherID.Replace("*", "");
            Console.WriteLine("Voucher ID: " + data.voucherID);

            //For Power Quantity
            data.powerQuantity = FindLine(lines, "Totales");
            data.powerQuantity = data.powerQuantity.Split(' ')[data.powerQuantity.Split(' ').Length - 1];
            Console.WriteLine("Power Quantity: " + data.powerQuantity);

            //For Total Amount
            data.totalAmount = FindLine(lines, "Valeur");
            data.totalAmount = data.totalAmount.Split(' ')[data.totalAmount.Split(' ').Length - 2];
            Console.WriteLine("Total Value: " + data.totalAmount);

            //For TVA Tax
            data.tvaTax = FindLine(lines, "TVA");
            data.tvaTax = data.tvaTax.Split(' ')[data.tvaTax.Split(' ').Length - 1];
            Console.WriteLine("TVA Tax: " + data.tvaTax);

            //For Other Tax
            data.otherTax = FindLine(lines, "Eclairage");
            data.otherTax = data.otherTax.Split(' ')[data.otherTax.Split(' ').Length - 1];
            Console.WriteLine("Other Tax: " + data.otherTax);

            //For Operator (POC Agent)
            data.pocAgent = lines[FindLastLineIndex(lines, "----------------------------------------") + 1];
            data.pocAgent = data.pocAgent.Split(':')[1];
            data.pocAgent = data.pocAgent.TrimStart(' ');
            Console.WriteLine("Operator: " + data.pocAgent);

            return data;
        }

        private static string FindLine(string[] lines, string word)
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

        private static int FindLastLineIndex(string[] lines, string word)
        {
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                if (lines[i].Contains(word))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
