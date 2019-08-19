using System;
using Golf.Models;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Starting Application");
            App app = new App();
            app.Run();
        }
    }
}
