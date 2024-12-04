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
        public MapDisplayForm(string mapFilePath)
        {
            InitializeComponent();
            SetupForm(mapFilePath);
        }

        private void SetupForm(string mapFilePath)
        {
            this.Text = "Map Display";
            this.Width = 800;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            TextBox mapTextBox = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Consolas", 12),
                BackColor = System.Drawing.Color.Black,
                ForeColor = System.Drawing.Color.White
            };

            try
            {
                if (!File.Exists(mapFilePath))
                {
                    throw new FileNotFoundException($"didn't find the map file：{mapFilePath}");
                }

                string mapContent = File.ReadAllText(mapFilePath);
                mapTextBox.Text = mapContent; 
            }
            catch (Exception ex)
            {
                mapTextBox.Text = $"Fail to load the map：{ex.Message}";
            }

            Button backButton = new Button
            {
                Text = "Go Back",
                Dock = DockStyle.Bottom,
                Height = 50,
                Font = new System.Drawing.Font("Arial", 14)
            };

            backButton.Click += (sender, e) =>
            {
                this.Close();
            };

            this.Controls.Add(mapTextBox);
            this.Controls.Add(backButton);
        }
    }
}
