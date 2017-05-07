using System;
using System.Threading.Tasks;
using IdentityModel;

namespace CoreWithIdentityServerFour.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hellow World");
            MainAsync().Wait();
        }

        static async Task MainAsync(){
            await Runner.Run();
        }
    }
}
