using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;

namespace ApiClient
{
    class Program
    {
        static async Task TellAGeneralJoke()
        {
            var client = new HttpClient();
            var url = "https://official-joke-api.appspot.com/jokes/general/random";
            var responseAsStream = await client.GetStreamAsync(url);
            var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);
            var table = new ConsoleTable("Type:", "Setup:", "PunchLine:");

            foreach (var joke in jokes)
            {
                table.AddRow(joke.Type, joke.Setup, joke.PunchLine);
            }
            table.Write(Format.Minimal);
        }

        static async Task TellAProgrammingJoke()
        {
            var client = new HttpClient();
            var url = "https://official-joke-api.appspot.com/jokes/programming/random";
            var responseAsStream = await client.GetStreamAsync(url);
            var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);
            var table = new ConsoleTable("Type:", "Setup:", "PunchLine:");

            foreach (var joke in jokes)
            {
                table.AddRow(joke.Type, joke.Setup, joke.PunchLine);
            }
            table.Write(Format.Minimal);
        }

        static async Task TellARandomJoke()
        {
            var client = new HttpClient();
            var url = "https://official-joke-api.appspot.com/jokes/random";
            var responseAsStream = await client.GetStreamAsync(url);
            var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);
            var table = new ConsoleTable("Type:", "Setup:", "PunchLine:");

            table.AddRow(joke.Type, joke.Setup, joke.PunchLine);
            table.Write(Format.Minimal);
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
                            await TellAProgrammingJoke();
                        }
                        else if (type == "G")
                        {
                            await TellAGeneralJoke();
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
