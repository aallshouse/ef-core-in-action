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
            var command = CommandPrompt();
            switch(command)
            {
              case "l":
                Commands.ListAll();
                break;
              case "u":
                Console.WriteLine("Enter the book ID that you would like to update.");
                int entityId;
                var entity = CommandPrompt();
                if(Int32.TryParse(entity, out entityId))
                  Commands.ChangeWebUrl(entityId);
                else
                  Console.WriteLine("Invalid entity ID entered.");
                
                break;
              case "e":
                return;
              default:
                Console.WriteLine("Unknown command.");
                break;
            }
          } while (true);
        }

        static string CommandPrompt()
        {
          Console.Write("> ");
          return Console.ReadLine();
        }
    }
}