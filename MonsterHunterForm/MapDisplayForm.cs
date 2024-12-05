﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterHunterForm
{
    public partial class MapDisplayForm : Form
    {
        private int cellSize = 32;
        private char[,] mapData;
        private PictureBox[,] pictureBoxes;
        private Point hunterPosition;

        public MapDisplayForm(string mapFilePath)
        {
            InitializeComponent();
            SetupForm(mapFilePath);
        }

        private void SetupForm(string mapFilePath)
        {
            this.Text = "Map Display";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.KeyPreview = true;
            this.KeyDown += MapDisplayForm_KeyDown;

            // Load map files
            string[] mapLines = LoadMapFile(mapFilePath);
            if (mapLines == null) return;

            int rows = mapLines.Length;
            int cols = mapLines[0].Length;

            // Initialize map data
            mapData = new char[rows, cols];
            pictureBoxes = new PictureBox[rows, cols];
            InitializeMapData(mapLines);

            // Set the size of the window
            this.ClientSize = new Size(cols * cellSize, rows * cellSize + 50);

            // Create map panel
            Panel mapPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = rows * cellSize
            };
            this.Controls.Add(mapPanel);

            // Render map
            RenderMap(mapPanel);

            // Add back button
            Button backButton = new Button
            {
                Text = "Go Back",
                Dock = DockStyle.Bottom,
                Height = 40,
                Font = new System.Drawing.Font("Arial", 14)
            };
            backButton.Click += (sender, e) => this.Close();
            this.Controls.Add(backButton);
        }

        private string[] LoadMapFile(string mapFilePath)
        {
            try
            {
                if (!File.Exists(mapFilePath))
                {
                    throw new FileNotFoundException($"Map file could not be found: {mapFilePath}");
                }
                return File.ReadAllLines(mapFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load the map file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void InitializeMapData(string[] mapLines)
        {
            for (int row = 0; row < mapLines.Length; row++)
            {
                for (int col = 0; col < mapLines[row].Length; col++)
                {
                    mapData[row, col] = mapLines[row][col];
                    if (mapData[row, col] == 'H') 
                    {
                        hunterPosition = new Point(col, row);
                    }
                }
            }
        }

        private void RenderMap(Panel mapPanel)
        {
            int rows = mapData.GetLength(0);
            int cols = mapData.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Width = cellSize,
                        Height = cellSize,
                        Location = new Point(col * cellSize, row * cellSize),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle,
                        Image = GetImageForCell(mapData[row, col])
                    };

                    mapPanel.Controls.Add(pictureBox);
                    pictureBoxes[row, col] = pictureBox;
                }
            }
        }

        private Image GetImageForCell(char cell)
        {
            string resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
            switch (cell)
            {
                case 'G': return Image.FromFile(Path.Combine(resourcePath, "Goal.jpg"));
                case 'H': return Image.FromFile(Path.Combine(resourcePath, "Hunter.jpg"));
                case 'M': return Image.FromFile(Path.Combine(resourcePath, "Monster.jpg"));
                case 'x': return Image.FromFile(Path.Combine(resourcePath, "Pickaxe.jpg"));
                case 'p': return Image.FromFile(Path.Combine(resourcePath, "Potion.jpg"));
                case 'h': return Image.FromFile(Path.Combine(resourcePath, "Shield.jpg"));
                case 'w': return Image.FromFile(Path.Combine(resourcePath, "Sword.jpg"));
                case '#': return Image.FromFile(Path.Combine(resourcePath, "Wall.jpg"));
                case ' ': return null; // Empty space
                default: return null;
            }
        }

        private void MapDisplayForm_KeyDown(object sender, KeyEventArgs e)
        {
            int dx = 0, dy = 0;

            // Set movement direction based on WASD keys
            switch (e.KeyCode)
            {
                case Keys.W: dy = -1; break;
                case Keys.S: dy = 1; break;  
                case Keys.A: dx = -1; break; 
                case Keys.D: dx = 1; break;  
                default: return;
            }

            MoveHunter(dx, dy);
        }

        private void MoveHunter(int dx, int dy)
        {
            int newX = hunterPosition.X + dx;
            int newY = hunterPosition.Y + dy;

            // Check boundaries and collisions
            if (newX < 0 || newX >= mapData.GetLength(1) || newY < 0 || newY >= mapData.GetLength(0)) return;
            if (mapData[newY, newX] == '#') return; 

            // Update map data
            mapData[hunterPosition.Y, hunterPosition.X] = ' ';
            mapData[newY, newX] = 'H'; 
            hunterPosition = new Point(newX, newY);

            // Update display
            pictureBoxes[hunterPosition.Y, hunterPosition.X].Image = GetImageForCell('H'); 
            pictureBoxes[newY - dy, newX - dx].Image = GetImageForCell(' '); 
        }
    }
}0