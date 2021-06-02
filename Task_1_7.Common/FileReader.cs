using System;
using System.Collections.Generic;
using System.IO;

namespace Task_1_7.Common
{
    public class FileReader
    {
        public List<string> GetCountryListFromFile(string filePath)
        {
            try
            {
                using FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
                StreamReader streamReader = new StreamReader(fileStream);
                string line;
                int counter = 0;
                List<string> countryLines = new List<string>();
                Console.WriteLine("\nInitial File: ");
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    countryLines.Add(line);
                    counter++;
                }
                streamReader.Close();
                fileStream.Close();
                return countryLines;
            }
            catch (SystemException ex)
            {
                Console.WriteLine("\nFile doesn't exist or path is incorrect: " + ex.Message);
                return null;
            }
        }

        public void PrintFile(List<string> countryList, string filePath)
        {
            try
            {
                using FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                fileStream.Seek(0, SeekOrigin.Begin);
                Console.WriteLine("\nUpdated File: ");
                foreach (var entry in countryList)
                {
                    streamWriter.WriteLine(entry);
                    Console.WriteLine(entry);
                }
                streamWriter.Close();
                fileStream.Close();
            }
            catch (SystemException ex)
            {
                Console.WriteLine("\nFile doesn't exist or path is incorrect: " + ex.Message);
            }
        }
    }
}

