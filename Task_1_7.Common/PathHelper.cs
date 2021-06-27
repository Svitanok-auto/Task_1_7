using System;
using System.IO;

namespace Task_1_7.Common
{
    public static class PathHelper
    {
        public static string SolutionFolderPath
        {
            get
            {
                var currentFolderPath = Path.GetDirectoryName(Environment.CurrentDirectory);
                var directory = new DirectoryInfo(currentFolderPath);
                while (directory != null && directory.GetFiles("*.csproj").Length == 0)
                {
                    directory = directory.Parent;
                    Console.WriteLine(directory);
                }
                return directory?.FullName ?? string.Empty;
            }
        }
    }
}
