using CardGameProject.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CardGameProject.Classes
{
    internal class Table : Panel
    {
        private Label labelSabaccPot;
        private Label labelMainPot;

        public Table(Size size)
        {
            this.Size = size;
            InitializeComponent();
        }

        public void DisplaySabaccPot(int value)
        {
            labelSabaccPot.Text = $"Sabacc Pot: {value} credits";
        }

        public void DisplayMainPot(int value)
        {
            labelMainPot.Text = $"Main Pot: {value} credits";
        }

        private void InitializeComponent()
        {
            BackColor = Color.Transparent;
            //
            // picturePlayerOne
            //
            var picturePlayerOne = new PictureBox();
            picturePlayerOne.BackgroundImage = Properties.Resources.player1_removebg_preview;
            picturePlayerOne.BackgroundImageLayout = ImageLayout.Zoom;
            picturePlayerOne.BackColor = Color.Transparent;
            picturePlayerOne.Location = new Point(70, 90);
            picturePlayerOne.Size = new Size(100, 78);

            Controls.Add(picturePlayerOne);
            //
            // picturePlayerTwo
            //
            var picturePlayerTwo = new PictureBox();
            picturePlayerTwo.BackgroundImage = Properties.Resources.player2_removebg_preview;
            picturePlayerTwo.BackgroundImageLayout = ImageLayout.Zoom;
            picturePlayerTwo.BackColor = Color.Transparent;
            picturePlayerTwo.Location = new Point(70, 595);
            picturePlayerTwo.Size = new Size(100, 78);

            Controls.Add(picturePlayerTwo);
            //
            // pictureTable
            //
            var pictureTable = new PictureBox();
            pictureTable.BackColor = SystemColors.ActiveCaptionText;
            pictureTable.BackgroundImage = Properties.Resources.table_removebg_preview_1920x10801;
            pictureTable.BackColor = Color.Black;
            pictureTable.BackgroundImageLayout = ImageLayout.Zoom;
            pictureTable.Location = new Point(0, 0);
            pictureTable.Size = this.Size;
            //
            // rules_btn
            //
            var rules_btn = new Button();
            rules_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            rules_btn.Location = new System.Drawing.Point(1160, 675);
            rules_btn.Name = "rules_btn";
            rules_btn.Size = new System.Drawing.Size(111, 37);
            rules_btn.TabIndex = 2;
            rules_btn.Text = "Rules";
            rules_btn.UseVisualStyleBackColor = true;
            rules_btn.Click += new System.EventHandler(rules_btn_Click);

            pictureTable.Controls.Add(rules_btn);


            Controls.Add(pictureTable);
            //
            // txtSabaccPot
            //
            labelSabaccPot = new Label();
            labelSabaccPot.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            labelSabaccPot.Location = new Point(1050, 330);
            labelSabaccPot.AutoSize = true;
            labelSabaccPot.Text = "Sabacc Pot:";
            labelSabaccPot.TextAlign = ContentAlignment.MiddleCenter;
            labelSabaccPot.ForeColor = Color.White;
            labelSabaccPot.BackColor = Color.Black;

            Controls.Add(labelSabaccPot);
            //
            // txtMainPot
            //
            labelMainPot = new Label();
            labelMainPot.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            labelMainPot.Location = new Point(1060, 380);
            labelMainPot.AutoSize = true;
            labelMainPot.Text = "Main Pot:";
            labelMainPot.TextAlign = ContentAlignment.MiddleCenter;
            labelMainPot.ForeColor = Color.White;
            labelMainPot.BackColor = Color.Black;

            Controls.Add(labelMainPot);

            labelMainPot.BringToFront();
            labelSabaccPot.BringToFront();
        }

        void rules_btn_Click(object sender, EventArgs e)
        {

            var rulesForm = new RulesForm();
            rulesForm.Show();

        }
    }
}