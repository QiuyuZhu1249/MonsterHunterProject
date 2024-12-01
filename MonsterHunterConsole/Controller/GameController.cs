using MonsterHunterConsole.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterConsole.Controller
{
    public class GameController
    {
        private bool isRunning;
        private string[] maps = { "Castle", "Marsh", "Hell" };

        public void Start()
        {
            isRunning = true;
            ShowBannerScreen();

            while (isRunning)
            {
            }
        }

        private void ShowBannerScreen()
        {
            ConsoleUI.ShowBanner();
            while (true)
            {
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.F1)
                {
                    ShowMapSelectionScreen();
                    break;
                }
                else if (input == ConsoleKey.F2)
                {
                    ExitGame();
                    break;
                }
            }
        }

        private void ShowMapSelectionScreen()
        {
            ConsoleUI.ShowMapSelectionScreen(maps);
            while (true)
            {
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.F2)
                {
                    ExitGame();
                    break;
                }
                else if (input == ConsoleKey.D1 || input == ConsoleKey.D2 || input == ConsoleKey.D3)
                {
                    int mapIndex = input - ConsoleKey.D1;
                    Console.Clear();
                    Console.WriteLine($"You choose:{maps[mapIndex]}");
                    Console.WriteLine("Press any button to Quit...");
                    Console.ReadKey();
                    ShowMapSelectionScreen();
                }
            }
        }

        private void ExitGame()
        {
            isRunning = false;
            ConsoleUI.ExitMessage();
        }
    }
}
