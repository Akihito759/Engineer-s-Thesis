using OCR.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR
{
    public class Tester
    {
        public string OCRSpaceTxt { get; private set; }
        public string PumaNETTxt { get; private set; }
        public string TesseractTxt { get; private set; }
        private string _path;

        public Tester(string path, bool languagePolish = false)
        {
            _path = path;
            OCRSpaceTxt = OCRSpace.Recognize(path, languagePolish);
            PumaNETTxt = PumaNET.Recognize(path, languagePolish);
            TesseractTxt = Tesseract.Recognize(path);
            show();
        }

        public void show()
        {
            Console.WriteLine(_path);
            Console.WriteLine("====OCRSpaceTxt====");
            Console.WriteLine(OCRSpaceTxt);
            Console.WriteLine("====PumaNETTxt====");
            Console.WriteLine(PumaNETTxt);
            Console.WriteLine("====TesseractTxt====");
            Console.WriteLine(TesseractTxt);
        }


    }
}
