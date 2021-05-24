using System;
using System.Collections.Generic;
using Task_1_7.Common;
using System.IO;

namespace ConsoleApp7
{
    public static class Program
    {
        public static FileReader fileReader = new FileReader();
        public static void Main()
        {
            Console.WriteLine("Start...");
            string filePath = Path.Combine(PathHelper.SolutionFolderPath, "Files", "Countries.txt");
            Console.WriteLine("File Path is: " + filePath);
            Dictionary<int, Country> dictionary = AddCountryToDictionary(CreateDictionary(filePath));
            fileReader.PrintFile(ConvertDictionaryToArray(EditIsTelenorSupportedInDictionary(dictionary)), filePath);

            Console.WriteLine("End...");
            Console.ReadLine();
        }

        public static Dictionary<int, Country> CreateDictionary(string filePath)
        {
            int i = 0;
            string[] countryArray = fileReader.GetCountryArrayFromFile(filePath);
            Dictionary<int, Country> countries = new Dictionary<int, Country>();
            string subline = ";";
            int startIndex = 0;
            while ((countryArray[i] != null) && (countryArray[i].Length > 0))
            {
                int index = countryArray[i].IndexOf(subline);
                int length = countryArray[i].Length;
                Country country = new Country();
                country.Name = countryArray[i].Substring(startIndex, index);

                if (countryArray[i].Substring(index + 1) == "true" || countryArray[i].Substring(index + 1) == "True" || countryArray[i].Substring(index + 1) == "TRUE")
                {
                    country.IsTelenorSupported = true;
                }
                else if (countryArray[i].Substring(index + 1) == "false" || countryArray[i].Substring(index + 1) == "False" || countryArray[i].Substring(index + 1) == "FALSE")
                {
                    country.IsTelenorSupported = false;
                }
                countries.Add(i + 1, country);
                i++;
            }
        return countries;
        }

        public static Dictionary<int, Country> AddCountryToDictionary(Dictionary<int, Country> dictionary)
        {
            bool flag = false;
            foreach (KeyValuePair<int, Country> kvp in dictionary)
            {
                if ((kvp.Value.Name == "Ukraine"))
                {
                    flag = true;
                }
            }
            if (flag == true)
            {
                return dictionary;
            }
            else
            {
                Country country = new Country() { Name = "Ukraine", IsTelenorSupported = true };
                dictionary.Add(dictionary.Count + 1, country);
                return dictionary;
            }
        }

        public static void PrintDictionary(Dictionary<int, Country> dictionary)
        {
            Console.WriteLine("\nHere is the Dictionary: ");
            foreach (KeyValuePair<int, Country> kvp in dictionary)
            {
                Console.WriteLine("Key = {0}, Value Name = {1}, Value IsTelenorSupported = {2}", kvp.Key, kvp.Value.Name, kvp.Value.IsTelenorSupported);
            }
        }

        public static Dictionary<int, Country> EditIsTelenorSupportedInDictionary(Dictionary<int, Country> dictionary)
        {
            foreach (KeyValuePair<int, Country> kvp in dictionary)
            {
                if ((kvp.Value.IsTelenorSupported != true) && ((kvp.Value.Name == "Denmark") || (kvp.Value.Name == "Hungary")))
                {
                    kvp.Value.IsTelenorSupported = true;
                    Console.WriteLine("Updates: Key = {0}, Value Name = {1}, Value IsTelenorSupported = {2}", kvp.Key, kvp.Value.Name, kvp.Value.IsTelenorSupported);
                }
            }
        PrintDictionary(dictionary);
        return dictionary;
        }

        public static string[] ConvertDictionaryToArray(Dictionary<int, Country> dictionary)
        {
            int i = 0;
            string[] countryArray = new string[30];
            foreach (var entry in dictionary)
            {
                 string dictionaryString = entry.Value.Name + ";" + entry.Value.IsTelenorSupported;
                 countryArray[i] = dictionaryString;
                 i++;
            }
        return countryArray;
        }
    }
}
