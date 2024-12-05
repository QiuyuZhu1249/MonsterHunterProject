using MonsterHunterConsole.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterHunterLogic.Utilities;
using MonsterHunterLogic.Models;

namespace MonsterHunterConsole.Controller
{
    public class GameController
    {
        private bool isRunning;
        private string[] maps = { "Maps/Castle.map", "Maps/Marsh.map", "Maps/Hell.map" }; 
        private Map currentMap;
        private int playerX; 
        private int playerY; 

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

                    LoadAndStartGame(selectedMap);
                }
            }
        }

        private void LoadAndStartGame(string mapFile)
        {
            currentMap = new Map();

            try
            {
                currentMap.LoadMap(mapFile);

                FindPlayerStartPosition();

                StartGameLoop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fail loading map ：{ex.Message}");
                Console.WriteLine("\n Press B to go back the map selection...");

                while (true)
                {
                    var input = Console.ReadKey(true).Key;
                    if (input == ConsoleKey.B)
                    {
                        ShowMapSelectionScreen();
                        break;
                    }
                }
            }
        }

        private void FindPlayerStartPosition()
        {
            for (int i = 0; i < currentMap.Height; i++)
            {
                for (int j = 0; j < currentMap.Width; j++)
                {
                    if (currentMap.MapData[i, j] == 'H')
                    {
                        playerX = j;
                        playerY = i;
                        return;
                    }
                }
            }

            throw new Exception("Didn't find the original position of the character ('H')！");
        }

        private void StartGameLoop()
        {
            while (true)
            {
                Console.Clear();
                currentMap.DisplayMap();

                Console.WriteLine("\n Please use arrow button to move the hunter");

                var input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.Q)
                {
                    ShowMapSelectionScreen();
                    break;
                }

                HandlePlayerMovement(input);
            }
        }

        private void HandlePlayerMovement(ConsoleKey input)
        {
            int newX = playerX;
            int newY = playerY;

            if (input == ConsoleKey.UpArrow)
                newY--;
            else if (input == ConsoleKey.DownArrow)
                newY++;
            else if (input == ConsoleKey.LeftArrow)
                newX--;
            else if (input == ConsoleKey.RightArrow)
                newX++;

            if (newX >= 0 && newX < currentMap.Width && newY >= 0 && newY < currentMap.Height)
            {
                if (currentMap.MapData[newY, newX] != '#')
                {
                    currentMap.MapData[playerY, playerX] = ' '; 
                    playerX = newX;
                    playerY = newY;
                    currentMap.MapData[playerY, playerX] = 'H';
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
