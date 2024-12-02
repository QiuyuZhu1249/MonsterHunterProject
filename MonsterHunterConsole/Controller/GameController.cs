using MonsterHunterConsole.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterHunterLogic.Utilities;

namespace MonsterHunterConsole.Controller
{
    public class GameController
    {
        private bool isRunning;
        private string[] maps = { "Maps/Castle.map", "Maps/Marsh.map", "Maps/Hell.map" };

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
                    string selectedMap = maps[mapIndex];

                    LoadAndDisplayMap(selectedMap);

                    ShowMapSelectionScreen();
                }
            }
        }

        private void LoadAndDisplayMap(string mapFile)
        {
            Map map = new Map();

            try
            {
                map.LoadMap(mapFile); // 加载地图文件
                Console.Clear();
                Console.WriteLine($"Loading the map：{mapFile}");
                map.DisplayMap(); // 显示地图内容
                Console.WriteLine("\n Press any button to go back...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed loading the map：{ex.Message}");
                Console.WriteLine("\n Press any button to go back...");
                Console.ReadKey();
            }
        }

        private void ExitGame()
        {
            isRunning = false;
            ConsoleUI.ExitMessage();
        }
    }
}
