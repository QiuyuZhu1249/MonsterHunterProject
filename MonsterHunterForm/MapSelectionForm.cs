using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterHunterForm
{
    public partial class MapSelectionForm : Form
    {
        public MapSelectionForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Map Selection";
            this.Width = 600;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label mapLabel = new Label
            {
                Text = "Please select your map：",
                Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point((this.ClientSize.Width - 200) / 2, 50)
            };

            Button castleButton = new Button
            {
                Text = "Castle",
                Font = new System.Drawing.Font("Arial", 14),
                Size = new System.Drawing.Size(150, 50),
                Location = new System.Drawing.Point((this.ClientSize.Width - 150) / 2, 120)
            };
            castleButton.Click += (sender, e) =>
            {
                OpenMap("Maps/Castle.map");
            };

            Button marshButton = new Button
            {
                Text = "Marsh",
                Font = new System.Drawing.Font("Arial", 14),
                Size = new System.Drawing.Size(150, 50),
                Location = new System.Drawing.Point((this.ClientSize.Width - 150) / 2, 200)
            };
            marshButton.Click += (sender, e) =>
            {
                OpenMap("Maps/Marsh.map");
            };

            Button hellButton = new Button
            {
                Text = "Hell",
                Font = new System.Drawing.Font("Arial", 14),
                Size = new System.Drawing.Size(150, 50),
                Location = new System.Drawing.Point((this.ClientSize.Width - 150) / 2, 280)
            };
            hellButton.Click += (sender, e) =>
            {
                OpenMap("Maps/Hell.map");
            };

            this.Controls.Add(mapLabel);
            this.Controls.Add(castleButton);
            this.Controls.Add(marshButton);
            this.Controls.Add(hellButton);
        }
        private void OpenMap(string mapFilePath)
        {
            MapDisplayForm mapDisplayForm = new MapDisplayForm(mapFilePath);
            mapDisplayForm.ShowDialog();
        }

    }
}