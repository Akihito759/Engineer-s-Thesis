using Puma.Net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                if (System.IO.File.Exists(path) == false)
                {
                    throw new FileNotFoundException();
                }

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
            catch (FileNotFoundException)
            {
                return "Błędna ścieżka pliku/brak pliku";
            }
            catch
            {
                return "Can't recognize text - PumaNET framework error";
            }
        }

       

    }
}
