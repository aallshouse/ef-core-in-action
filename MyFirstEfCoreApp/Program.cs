using System;

namespace MyFirstEfCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine("Commands: l (list), u (change url), and e (exit)");
          Console.Write("Checking if database exists... ");
          Console.WriteLine("it exists.");

          do
          {
            Console.Write("> ");
            var command = Console.ReadLine();
            switch(command)
            {
              case "l":
                Commands.ListAll();
                break;
              case "u":
                Commands.ChangeWebUrl();
                break;
              case "e":
                return;
              default:
                Console.WriteLine("Unknown command.");
                break;
            }
          } while (true);
        }
    }
}