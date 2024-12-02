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
            // set the size and details for the window
            this.Text = "Map selections";
            this.Width = 600;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // write title
            Label mapLabel = new Label
            {
                Text = "Please choose one map：",
                Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point((this.ClientSize.Width - 200) / 2, 50)
            };

            //create buttons
            Button castleButton = new Button
            {
                Text = "Castle",
                Font = new System.Drawing.Font("Arial", 14),
                Size = new System.Drawing.Size(150, 50),
                Location = new System.Drawing.Point((this.ClientSize.Width - 150) / 2, 120)
            };
            castleButton.Click += (sender, e) =>
            {
                MessageBox.Show("You Choose the map：Castle");
            };

            Button swampButton = new Button
            {
                Text = "Marsh",
                Font = new System.Drawing.Font("Arial", 14),
                Size = new System.Drawing.Size(150, 50),
                Location = new System.Drawing.Point((this.ClientSize.Width - 150) / 2, 200)
            };
            swampButton.Click += (sender, e) =>
            {
                MessageBox.Show("You Choose the map：Marsh");
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
                MessageBox.Show("You Choose the map：Hell");
            };

            // add go back button
            Button backButton = new Button
            {
                Text = "Go back",
                Font = new System.Drawing.Font("Arial", 12),
                Size = new System.Drawing.Size(100, 40),
                Location = new System.Drawing.Point(20, 320)
            };
            backButton.Click += (sender, e) =>
            {
                CenteredFixedForm mainForm = new CenteredFixedForm();
                mainForm.Show();
                this.Close(); 
            };

            this.Controls.Add(mapLabel);
            this.Controls.Add(castleButton);
            this.Controls.Add(swampButton);
            this.Controls.Add(hellButton);
            this.Controls.Add(backButton);
        }
    }
}
