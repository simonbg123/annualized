using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AnnualizeLibrary
{
   
   
   
   /// <summary>
   /// This class is used to update or create a transaction history CSV file.
   /// It currently contains one static method, <code>BMO</code>, which can be 
   /// used to convert raw transaction histories from that institution into the required CSV format:
   /// <para>
   /// Year, Month, Day, transaction code, amount, number of shares, price
   /// </para>
   /// <para>More details on fields in Annualizer class documentation</para>
   /// </summary>   
    public class CsvUpdater
   {
      
        static string newLine = Environment.NewLine;
        public static string dataDirectory = "data";
        public static string backupDirectory = "backup";
        public static string GetCsvFilePath(string fundName)
        {
            string space = "[ \t]+";
            return Path.Combine(dataDirectory, Regex.Replace(fundName, space, "_") + ".csv");
        }

        /// <summary>
        /// Converts the text of a BMO Fund transaction history obtained from the BMO website,
        /// into a formatted.csv data file for use with the Annualizer class.
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="csvFilePath"></param>
        /// <param name="currentPrice"></param>
        /// <param name="currentNumShares"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static bool BMO(
            TextReader lines, 
            string csvFilePath, 
            double currentPrice, 
            double currentNumShares,
            int year,
            int month,
            int day) 
        {
            
            try
            {
                // find what the last line is in the existing csv file, starts at 1
                string previousMostRecentEntry = "";
                string oldCsvFileContents = null;
                bool csvFileAlreadyExisted = File.Exists(csvFilePath);

                if (csvFileAlreadyExisted)
                {
                    MakeBackup(csvFilePath);

                    using (StreamReader br = new StreamReader(csvFilePath))
                    {
                        br.ReadLine();
                        br.ReadLine();
                        br.ReadLine();
                        br.ReadLine();
                        previousMostRecentEntry = br.ReadLine() + newLine;
                        oldCsvFileContents = br.ReadToEnd();
                                       
                    }                
                }

                DateTimeFormatInfo dateTimeFormat = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
                dateTimeFormat.ShortDatePattern = "MMM. dd, yyyy";

                StringBuilder csvBuilder = new StringBuilder();
            
                for (String line = lines.ReadLine(); line != null; line = lines.ReadLine())
                {
                    // the last empty line after the last '\n'
                    if (line == "") continue;
                  
                    string csvEntry = makeCsvEntry(dateTimeFormat, line);
                    csvBuilder.Append(csvEntry);
                
                    if (previousMostRecentEntry.Equals(csvEntry))
                    {
                        break;
                    }                
                }

                // Append our StringBuilder to the CSV file, or create a new one
                using (StreamWriter sw = new StreamWriter(csvFilePath))
                {
                    // first legend
                    sw.WriteLine("Current_Share_Price    Current_Number_of_Shares    Current_Year    Current_Month    Current_Day");
                    sw.WriteLine($"{currentPrice}\t{currentNumShares}\t{year}\t{month}\t{day}");
                    // first line : format
                    sw.WriteLine(
                        "Year    Month    Day    transaction_code    amount    number_of_shares    price"
                        + newLine 
                        + "(p: purchase, s: sale, r: re-invested income, tf: transferred from other fund)");
               
                    sw.Write(csvBuilder);
                    if (csvFileAlreadyExisted) 
                        sw.Write(oldCsvFileContents);
                }
            }
            catch(Exception ex)
            {
                using (StreamWriter errorLog = new StreamWriter("errorLog.txt", true))
                {
                    errorLog.WriteLine(DateTime.Now + "\n" + csvFilePath + "\n" +
                        ex.Message + newLine + ex.StackTrace + "\n\n");
                }

                return false;
            }
            
            return true;
        }

        private static string makeCsvEntry(DateTimeFormatInfo dateTimeFormat, string line)
        {
            StringBuilder entryBuilder = new StringBuilder();
            DateTime date = DateTime.Parse(line.Substring(0, 13), dateTimeFormat);
            entryBuilder.Append(date.Year + "\t" + date.Month + "\t " + date.Day + "\t");

            if (line.Contains(" bought ")) entryBuilder.Append('p' + "\t");
            else if (line.Contains(" sold ")) entryBuilder.Append('s' + "\t");
            else if (line.Contains(" re-invested ")) entryBuilder.Append('r' + "\t");
            else if (line.Contains(" transferred from ")) entryBuilder.Append("tf\t");

            string[] tokens = line.Split(new string[] { "$", "\t", " " },
               StringSplitOptions.RemoveEmptyEntries);

            //  Starting from the last three fields
            //  note that the "-" sign when shares are sold
            // is ignored. We already know it is a sale and will treat data accordingly 
            // in calculateAnnualized()
            for (int i = tokens.Length - 3; i < tokens.Length; i++)
            {
                entryBuilder.Append(Regex.Replace(tokens[i], ",", "") + ((i < tokens.Length - 1) ? "\t" : ""));
            }
            entryBuilder.Append(newLine);

            return entryBuilder.ToString();
        }

        private static void MakeBackup(string csvFilePath)
        {
            Directory.CreateDirectory(backupDirectory);
            string backupFilePath = GetBackupFilePath(csvFilePath);
            
            if (File.Exists(backupFilePath))
            {
                File.Delete(backupFilePath);
            }
            File.Copy(csvFilePath, backupFilePath);
        }

        private static string GetBackupFilePath(string filePath)
        {
            return Path.Combine(backupDirectory, Path.GetFileName(filePath));
        }
    }
}
