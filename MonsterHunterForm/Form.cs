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
    public partial class CenteredFixedForm : Form
    {
        public CenteredFixedForm()
        {
            SetupForm();
        }

        private void SetupForm()
        {
            // add windows form's name
            this.Text = "Monster Hunter";

            // set the size for the window
            this.Width = 800;
            this.Height = 600;

            // set the window in center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // not allow to change the size for the window
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; 
            this.MinimizeBox = true;

            Label welcomeLabel = new Label
            {
                Text = "Welcome to Monster Hunter\n" +
                "---develop by Qiuyu",

                Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point((this.ClientSize.Width - 400) / 2, 150), 
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            // add start button
            Button startButton = new Button
            {
                Text = "Start Game",
                Font = new System.Drawing.Font("Arial", 14),
                Size = new System.Drawing.Size(150, 50),
                Location = new System.Drawing.Point((this.ClientSize.Width - 150) / 2, 300)
            };

            startButton.Click += (sender, e) =>
            {
                // open the window of map selections 
                MapSelectionForm mapSelectionForm = new MapSelectionForm();
                mapSelectionForm.Show();
                this.Hide();
            };

            // add quit button
            Button exitButton = new Button
            {
                Text = "Quit Game",
                Font = new System.Drawing.Font("Arial", 14),
                Size = new System.Drawing.Size(150, 50),
                Location = new System.Drawing.Point((this.ClientSize.Width - 150) / 2, 400)
            };

            exitButton.Click += (sender, e) =>
            {
                Application.Exit(); 
            };

            this.Controls.Add(welcomeLabel);
            this.Controls.Add(startButton);
            this.Controls.Add(exitButton);
        }

    }
}
