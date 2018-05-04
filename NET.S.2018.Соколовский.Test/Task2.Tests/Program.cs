using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2;

namespace Task2.Tests
{
    public static class Program
    {
        public static void Main()
        {
            RandomBytesFileGenerator bytesGenerator = new RandomBytesFileGenerator();
            RandomCharsFileGenerator charsGenerator = new RandomCharsFileGenerator();
            bytesGenerator.GenerateFiles(2, 4);
            charsGenerator.GenerateFiles(2, 4);
        }
    }
}
