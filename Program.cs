using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClient
{
    class Program
    {
        static async Task TellAJokeType(string type)
        {
            var client = new HttpClient();
            var url = $"https://official-joke-api.appspot.com/jokes/{type}/random";
            var responseAsStream = await client.GetStreamAsync(url);
            var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);
            var table = new ConsoleTable("Type", "Setup", "PunchLine");

            table.AddRow(joke.Type, joke.Setup, joke.PunchLine);
            table.Write(Format.Minimal);

        }

        static void Main(string[] args)
        {
            var keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
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

                        }
                        if (type == "G")
                        {

                        }
                        if (type == "S")
                        {

                        }
                        else
                        {
                            Console.WriteLine($"I'm sorry {type} isn't a valid option ");
                        }
                        break;

                }
            }
        }
    }
}
