using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace MonoTest
{
    [TestFixture]
    class MainTest
    {
        [Test]
        public void Test()
        {
            var addressFilePath = @"C:\repository\GitHub\ChuckLu\HearthBuddy\SilverFish\MonoTest\mono-address.txt";
            var lines = File.ReadAllLines(addressFilePath);
            string separator = " - ";
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                if (line.Contains(separator))
                {
                   var array = line.Split(new[] { separator }, StringSplitOptions.None);
                   if (array.Length == 2)
                   {
                       dictionary.Add(array[1],array[0]);
                   }
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}={item.Value}");
            }
        }
    }
}
