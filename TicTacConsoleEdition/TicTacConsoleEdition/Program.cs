using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacConsoleEdition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Should we play?Crosses first");
            GameHandler gameHandler = new GameHandler();
            gameHandler.StartGame();
            Console.ReadLine();
        }
    }
}
