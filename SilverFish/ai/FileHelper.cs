using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverFish.ai
{
    public class FileHelper
    {
        public static void CreateEmptyFile(string filename)
        {
            File.Create(filename).Dispose();
        }
    }
}
