using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR
{
    public class Tesseract
    {



        //public Tesseract()
        //{
        //    //Stopwatch stopwatch = new Stopwatch();
        //    //stopwatch.Start();

        //    var solutionDirectory = Path.GetFullPath($@"..\..");
        //     _tesseractPath = solutionDirectory + @"\tesseract-master.1244";
        //    //var testFiles = Directory.EnumerateFiles(solutionDirectory + @"\samples");

        //    //var maxDegreeOfParallelism = Environment.ProcessorCount;
        //    //Parallel.ForEach(testFiles, new ParallelOptions { MaxDegreeOfParallelism = maxDegreeOfParallelism }, (fileName) =>
        //    //{
        //    //    var imageFile = File.ReadAllBytes(fileName);
        //    //    var text = ParseText(tesseractPath, imageFile, "eng", "pol");
        //    //    Console.WriteLine("File:" + fileName + "\n" + text + "\n");
        //    //});

        //    //stopwatch.Stop();
        //    //Console.WriteLine("Duration: " + stopwatch.Elapsed);
        //    //Console.WriteLine("Press enter to continue...");
        //    //Console.ReadLine();
        //}

        private static  string ParseText(string tesseractPath, byte[] imageFile, params string[] lang)
        {
            

            string output = string.Empty;
            var tempOutputFile = Path.GetTempPath() + Guid.NewGuid();
            var tempImageFile = Path.GetTempFileName();

            try
            {
                File.WriteAllBytes(tempImageFile, imageFile);

                ProcessStartInfo info = new ProcessStartInfo();
                info.WorkingDirectory = tesseractPath;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.UseShellExecute = false;
                info.FileName = "cmd.exe";
                info.Arguments =
                    "/c tesseract.exe " +
                    // Image file.
                    tempImageFile + " " +
                    // Output file (tesseract add '.txt' at the end)
                    tempOutputFile +
                    // Languages.
                    " -l " + string.Join("+", lang);

                // Start tesseract.
                Process process = Process.Start(info);
                process.WaitForExit();
                if (process.ExitCode == 0)
                {
                    // Exit code: success.
                    output = File.ReadAllText(tempOutputFile + ".txt");
                }
                else
                {
                    throw new Exception("Error. Tesseract stopped with an error code = " + process.ExitCode);
                }
            }
            finally
            {
                File.Delete(tempImageFile);
                File.Delete(tempOutputFile + ".txt");
            }
            return output;
        }

        public static string Recognize(string path)
        {
            try
            {
                var solutionDirectory = Path.GetFullPath($@"..\..");
                string tesseractPath = solutionDirectory + @"\tesseract-master.1244";
                tesseractPath = @"C:\Users\Akihito\source\repos\Engineer's Thesis\OCR\tesseract-master.1244";

                var imageFile = File.ReadAllBytes(path);
                var text = ParseText(tesseractPath, imageFile, "eng", "pol");
                return text;
            }
            catch
            {
                return "Can't recognize text - Tesseract framework error";
            }
        }

       
    }
}
