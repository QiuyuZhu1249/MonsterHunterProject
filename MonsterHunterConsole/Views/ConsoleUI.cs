using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterConsole.Views
{
    public static class ConsoleUI
    {
        public static void ShowBanner()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine(" Welcome to  Monster Hunter !!! ");
            Console.WriteLine("================================");
            Console.WriteLine("Press F1 Start the Game");
            Console.WriteLine("Press F2 Quit the Game");
        }

        public static void ShowMapSelectionScreen(string[] maps)
        {
            Console.Clear();
            Console.WriteLine("Please Choose one of the following maps：");
            for (int i = 0; i < maps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {maps[i]}");
            }
            Console.WriteLine("\nPress F2 Quit the Game");
        }

        public static void ExitMessage()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing Monster Hunter!");
            Console.WriteLine("Press any button to Quit...");
            Console.ReadKey();
        }
    }
}
