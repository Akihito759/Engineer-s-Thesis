using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OCR.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.Engines
{

    public class OCRSpace
    {
        private static RestClient _client = new RestClient("https://api.ocr.space/parse/image");

        public static string Recognize(string path, bool languagePolish = false)
        {
            string language = "eng";
            string text = string.Empty;
            if (languagePolish)
            {
                language = "pol";
            }
            var request = new RestRequest(Method.POST);
            request.AddParameter("apikey", "113cfeaad888957");
            request.AddParameter("language", language);
            request.AddFile("image", path);
            IRestResponse response = _client.Execute(request);

            var json = response.Content; // raw content as string
            var obj = JsonConvert.DeserializeObject<JsonModel>(json);

            foreach(var item in obj.ParsedResults)
            {
                text += item.ParsedText;
            }

            return text;

        }

    }
}
