using System;
using System.Collections.Generic;
using System.IO;
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

            //key is function name, and value should be address
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
                //Console.WriteLine($"{item.Key}={item.Value}");
            }

            var functionDictionary = MonoFunctions.Instance.FunctionDictionary;
            //this.intptr_1 = this.intptr_0 + 102855;
            string format = "intptr_{0} = intptr_0 + 0x{1};";
            foreach (var item in functionDictionary) //key is id and value is function name
            {
                var functionName = item.Value;
                var ptrId = item.Key;
                if (!dictionary.ContainsKey(functionName))
                {
                    throw new Exception($"Can not find address for function {functionName}");
                }

                var address = dictionary[functionName];
                Console.WriteLine(format, ptrId, address);
            }
        }
    }
}
