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
            Dictionary<int, Country> dictionary = CreateDictionary(filePath);
            if (dictionary != null)
            {
                dictionary = AddCountryToDictionary(dictionary);
                dictionary = EditIsTelenorSupportedInDictionary(dictionary);
                PrintDictionary(dictionary);
                fileReader.PrintFile(ConvertDictionaryToArray(dictionary), filePath);
            }
            Console.WriteLine("End...");
            Console.ReadLine();
        }

        public static Dictionary<int, Country> CreateDictionary(string filePath)
        {
           if (fileReader.GetCountryArrayFromFile(filePath) != null)
            {
                int i = 0;
                List<string> countryList = fileReader.GetCountryArrayFromFile(filePath);
                Dictionary<int, Country> countries = new Dictionary<int, Country>();
                string subline = ";";
                int startIndex = 0;
                foreach (string countryElement in countryList)
                {
                    int index = countryElement.IndexOf(subline);
                    Country country = new Country
                    {
                        Name = countryElement.Substring(startIndex, index)
                    };
                    if (countryElement.Substring(index + 1).ToLower() == "true")
                    {
                        country.IsTelenorSupported = true;
                    }
                    else
                    {
                        country.IsTelenorSupported = false;
                    }
                    countries.Add(i + 1, country);
                    i++;
                }
                return countries;
            }
            return null;
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
                Country country = new Country() { 
                    Name = "Ukraine", 
                    IsTelenorSupported = true };

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
        return dictionary;
        }

        public static List<string> ConvertDictionaryToArray(Dictionary<int, Country> dictionary)
        {
            List<string> countryList = new List<string>();
            foreach (var entry in dictionary)
            {
                 string dictionaryString = entry.Value.Name + ";" + entry.Value.IsTelenorSupported;
                 countryList.Add(dictionaryString);
            }
        return countryList;
        }
    }
}
