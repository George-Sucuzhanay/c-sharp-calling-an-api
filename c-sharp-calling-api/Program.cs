// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Linq;


namespace WebAPIClient
{
    class AnObject
    {
        [JsonProperty("name")]
        public string ? Name { get; set;}
        [JsonProperty("street")]
        public string ? Street { get; set; }
        [JsonProperty("city")]
        public string ? City { get; set; }
        //[JsonProperty("")]
        //[JsonProperty("")]
    }

    public class Type
    {
        [JsonProperty("name")]
        public string ? Name { get; set; }
    }

    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        private static async Task ProcessRepositories()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter new city here: ");

                    var newObjectHere = Console.ReadLine();

                    if (string.IsNullOrEmpty(newObjectHere))
                    {
                        break;
                    }

                    var result = await client.GetAsync("https://www.refugerestrooms.org/api/v1/restrooms/search?page=1&per_page=5&offset=0&query=" + newObjectHere.ToLower());
                    var resultRead = await result.Content.ReadAsStringAsync();

                    var my_object = JsonConvert.DeserializeObject<AnObject>(resultRead);

                    // when making a endpoint here I can read the data
                    // the api call is making the call but b/c the data itself is an array of object it is not able to access it properly
                    // this api result looks diferently from the pokeapi api result

                    Console.WriteLine("MYOBJECT: " + my_object);

                    Console.WriteLine("---");
                    //Console.WriteLine("Name: " + my_object.Name);
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR. Please enter a valid city name!");
                }

            }
        }

        static async Task Main(string[] args)

        {
            await ProcessRepositories();

        }

    }
}

//namespace WebAPIClient
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            // Display the number of command line arguments.
//            Console.WriteLine(args.Length);
//        }
//    }
//}


