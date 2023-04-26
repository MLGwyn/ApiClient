using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClient
{
    class Program
    {
        static async Task TellAJoke(string type)
        {
            var client = new HttpClient();
            var url = $"https://official-joke-api.appspot.com/jokes/{type}/random";
            var responseAsStream = await client.GetStreamAsync(url);
            var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);

            foreach (var joke in jokes)
            {
                Console.WriteLine($"\n-{joke.Setup}\n");
            }

            Console.Write("Press ENTER for punch line");
            Console.ReadLine();

            foreach (var joke in jokes)
            {
                Console.WriteLine($"\n-{joke.PunchLine}\n");
            }
        }

        static async Task TellARandomJoke()
        {
            var client = new HttpClient();
            var url = "https://official-joke-api.appspot.com/jokes/random";
            var responseAsStream = await client.GetStreamAsync(url);
            var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);

            Console.WriteLine($"\n-{joke.Setup}\n");
            Console.Write("Press ENTER for punchline");
            Console.ReadLine();
            Console.WriteLine($"\n-{joke.PunchLine}\n");
        }

        static async Task Main(string[] args)
        {
            var keepGoing = true;
            while (keepGoing)
            {
                Console.Write("Would you like to hear a joke? [Y/N] ");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "N":
                        keepGoing = false;
                        break;

                    case "Y":
                        Console.Write("What type of joke would you like to hear?\n[P]rogramming\n[G]eneral\n[S]urprise me! ");
                        var type = Console.ReadLine().ToUpper();
                        if (type == "P")
                        {
                            await TellAJoke("programming");
                        }
                        else if (type == "G")
                        {
                            await TellAJoke("general");
                        }
                        else if (type == "S")
                        {
                            await TellARandomJoke();
                        }
                        else
                        {
                            Console.WriteLine($"I'm sorry {type} isn't a valid option. ");
                        }
                        break;

                    default:
                        Console.WriteLine($"I'm sorry {choice} isn't a valid option ");
                        break;

                }
            }
        }
    }
}
