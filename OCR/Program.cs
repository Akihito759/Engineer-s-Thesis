using OCR.Engines;
using Puma.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;

namespace OCR
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Akihito\source\repos\Engineer's Thesis\OCR\Samples";

            List<string> pathList = new List<string>(Directory.GetFiles(path, "*.*", SearchOption.AllDirectories));

            foreach(var image in pathList)
            {
               // var temp = new Tester(image,true);
            }
            var tester = new Tester(@"C:\Users\Akihito\source\repos\Engineer's Thesis\OCR\bin\Debug\tested.jpg",true);

            Console.ReadKey();
        }
    }
}

