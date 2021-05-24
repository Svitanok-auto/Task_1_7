using System;
using System.IO;

namespace Task_1_7.Common
{
    public class FileReader
    {
        public string[] GetCountryArrayFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    string line;
                    int counter = 0;
                    string[] countryLines = new string[30];
                    Console.WriteLine("\nInitial File: ");
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);                     
                        countryLines[counter] = line;
                        counter++;
                    }
                streamReader.Close();
                fileStream.Close();
                return countryLines;
                }
            }
        return null;
        }

        public void PrintFile(string[] countryArray, string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    fileStream.Seek(0, SeekOrigin.Begin);
                    Console.WriteLine("\nUpdated File: ");
                    foreach (var entry in countryArray)
                    {
                        streamWriter.WriteLine(entry);
                        Console.WriteLine(entry);
                    }
                    streamWriter.Close();
                    fileStream.Close();
                }
            }
        }
    }
}

