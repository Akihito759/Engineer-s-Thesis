using Puma.Net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR
{
    public static class PumaNET
    {
        public static string Recognize(string path,bool languagePolish = false)
        {
            try
            {
                using (var ocr = new PumaPage(path))
                {
                    ocr.EnableSpeller = false;
                    if (languagePolish)
                    {
                        ocr.Language = PumaLanguage.Polish;
                        
                    }
                    else
                    {
                        ocr.Language = PumaLanguage.English;
                    }
                    return ocr.RecognizeToString();
                }

            }
            catch
            {
                return "Can't recognize text - PumaNET framework error";
            }
        }

        public static string Recognize(Bitmap image, bool languagePolish = false)
        {
            try
            {
                using (var ocr = new PumaPage(image))
                {
                    ocr.EnableSpeller = false;
                    if (languagePolish)
                    {
                        ocr.Language = PumaLanguage.Polish;
                    }
                    else
                    {
                        ocr.Language = PumaLanguage.English;
                    }
                    return ocr.RecognizeToString();
                }

            }
            catch
            {
                return "Can't recognize text - PumaNET framework error";
            }
        }

    }
}
