using System;
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

            // loading map files
            string[] mapLines = LoadMapFile(mapFilePath);
            if (mapLines == null) return;

            int rows = mapLines.Length;
            int cols = mapLines[0].Length;

            // set the size of windows
            this.ClientSize = new Size(cols * cellSize, rows * cellSize + 50);

            Panel mapPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = rows * cellSize
            };
            this.Controls.Add(mapPanel);

            RenderMap(mapLines, mapPanel);

            Button backButton = new Button
            {
                Text = "Go Back",
                Dock = DockStyle.Bottom,
                Height = 40,
                Font = new System.Drawing.Font("Arial", 14)
            };
            backButton.Click += (sender, e) =>
            {
                this.Close();
            };

            this.Controls.Add(backButton);
        }
        private string[] LoadMapFile(string mapFilePath)
        {
            try
            {
                if (!File.Exists(mapFilePath))
                {
                    throw new FileNotFoundException($"Map file could not find：{mapFilePath}");
                }
                return File.ReadAllLines(mapFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fail loading the map file：{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void RenderMap(string[] mapLines, Panel mapPanel)
        {
            int rows = mapLines.Length;
            int cols = mapLines[0].Length;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char cell = mapLines[row][col];
                    PictureBox pictureBox = new PictureBox
                    {
                        Width = cellSize,
                        Height = cellSize,
                        Location = new Point(col * cellSize, row * cellSize),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle,
                        Image = GetImageForCell(cell) 
                    };

                    mapPanel.Controls.Add(pictureBox);
                }
            }
        }

        private Image GetImageForCell(char cell)
        {
            string resourcePath = "Resources/";
            switch (cell)
            {
                case 'G': return Image.FromFile($"{resourcePath}Goal.jpg");
                case 'H': return Image.FromFile($"{resourcePath}Hunter.jpg");
                case 'M': return Image.FromFile($"{resourcePath}Monster.jpg");
                case 'x': return Image.FromFile($"{resourcePath}Pickaxe.jpg");
                case 'p': return Image.FromFile($"{resourcePath}Potion.jpg");
                case 'h': return Image.FromFile($"{resourcePath}Shield.jpg");
                case 'w': return Image.FromFile($"{resourcePath}Sword.jpg");
                case '#': return Image.FromFile($"{resourcePath}Wall.jpg");
                case ' ': return null; 
                default: return null;
            }
        }
    }
}
