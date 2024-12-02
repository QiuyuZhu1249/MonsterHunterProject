using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterLogic.Utilities
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public char[,] MapData { get; private set; }

        public void LoadMap(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"didn't find the map files：{filePath}");
            }
            string[] lines = File.ReadAllLines(filePath);
            Height = lines.Length;
            Width = lines[0].Length;

            MapData = new char[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    MapData[i, j] = lines[i][j];
                }
            }
        }

        public void DisplayMap()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(MapData[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
