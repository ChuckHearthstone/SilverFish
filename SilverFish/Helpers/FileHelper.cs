using System;
using System.IO;

namespace SilverFish.Helpers
{
    public class FileHelper
    {
        public static void CreateEmptyFile(string filePath)
        {
            var folder = Path.GetDirectoryName(filePath);
            if (string.IsNullOrEmpty(folder))
            {
                throw new Exception($"Can not get folder from {filePath}");
            }

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            File.Create(filePath).Dispose();
        }
    }
}
