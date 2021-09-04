using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace EstrelaDaMorteAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            var url = "https://swapi.dev/api/starships/9/";
            var nome = BuscarNomeEstrela();
            var model = BuscarModeloEstrela();
            var length = BuscarLenghtEstrela();

            Console.WriteLine("O nome da Nave é: " + nome);
            Console.WriteLine("Seu Modelo é : " + model);
            Console.WriteLine("Seu Comprimento é de:  " + length + "m");

            Console.ReadKey();


        }
        public static string ObterWebRequest(string metodohttp, string url)
        {
            WebRequest webRequest = WebRequest.Create(url);

            webRequest.Method = metodohttp;

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            string StreamReaderResponse = string.Empty;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader streamreader = new StreamReader(stream);
                StreamReaderResponse = streamreader.ReadToEnd();
            }

            return StreamReaderResponse;
        }

        public static string BuscarNomeEstrela()
        {
            string url = "https://swapi.dev/api/starships/9/";

            var requestResult = ObterWebRequest("GET", url);
            var resultadoConversao = JsonConvert.DeserializeObject<DadosEstrela>(requestResult);



            return resultadoConversao.name;


        }
        public static string BuscarModeloEstrela()
        {
            string url = "https://swapi.dev/api/starships/9/";

            var requestResult = ObterWebRequest("GET", url);
            var resultadoConversao = JsonConvert.DeserializeObject<DadosEstrela>(requestResult);



            return resultadoConversao.model;


        }
        public static string BuscarLenghtEstrela()
        {

            HttpClient client = new HttpClient();
            string url = "https://swapi.dev/api/starships/9/";

            var resultado = client.GetAsync(url).Result;
            var resultadoBody = resultado.Content.ReadAsStringAsync().Result;
            //var conversao = JToken.Parse(resultadoBody)["length"];
            var conversao = JToken.Parse(resultadoBody).ToObject<DadosEstrela>();

            return conversao.length;


          
        }

        // app settings





















    }
    }

