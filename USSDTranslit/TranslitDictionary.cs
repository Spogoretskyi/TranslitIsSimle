using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows;

namespace USSDTranslit
{
    class TranslitDictionary
    {
        string _path = String.Format("{0}\\dictionaryRus.json",System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        string _pathU = String.Format("{0}\\dictionaryUA.json", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        string _logpath = String.Format(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        public static Dictionary<string, string> translationRUS = new Dictionary<string, string>();
        public static Dictionary<string, string> translationUA = new Dictionary<string, string>();

        private Dictionary<string, string> LoadRUS()
        {
            try
            {
                string readText = File.ReadAllText(_path);
                byte[] encodedBytes = Encoding.Default.GetBytes(readText);
                var tmp = JsonConvert.DeserializeObject<JObject>(Encoding.Default.GetString(encodedBytes));
                translationRUS = tmp.ToObject<Dictionary<string, string>>();
                return translationRUS;
            }
            catch (Exception ex)
            {
                using (StreamWriter outputFile = new StreamWriter(_path + @"LogParameters.txt", true))
                {
                    outputFile.WriteLine(DateTime.Now.ToString());
                    outputFile.WriteLine(ex);
                    outputFile.WriteLine();
                    outputFile.Close();
                }
            }
            return translationRUS;
        }

        private Dictionary<string, string> LoadUA()
        {
            try
            {
                string readText = File.ReadAllText(_pathU);
                byte[] encodedBytes = Encoding.Default.GetBytes(readText);
                var tmp = JsonConvert.DeserializeObject<JObject>(Encoding.Default.GetString(encodedBytes));
                translationUA = tmp.ToObject<Dictionary<string, string>>();
                return translationUA;
            }
            catch (Exception ex)
            {
                using (StreamWriter outputFile = new StreamWriter(_path + @"LogParameters.txt", true))
                {
                    outputFile.WriteLine(DateTime.Now.ToString());
                    outputFile.WriteLine(ex);
                    outputFile.WriteLine();
                    outputFile.Close();
                }
            }
            return translationUA;
        }

        public string ToTranslitRu(string c)
    {
            LoadRUS();
        string result;
        if (translationRUS.TryGetValue(c, out result))
            return result;
        else
            return c.ToString();
    }
        public string ToTranslitUA(string c)
        {
            LoadUA();
            string result;
            if (translationUA.TryGetValue(c, out result))
                return result;
            else
                return c.ToString();
        }
    }

}
