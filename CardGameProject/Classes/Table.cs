using CardGameProject.Forms;
using CardGameProject.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CardGameProject.Classes
{
    internal class Table : Panel
    {
        private Label labelSabaccPot;
        private Label labelMainPot;
        private Label labelNameP1;
        private Label labelNameP2;
        private List<PictureBox> pictureBoxPlayer1Hand;
        private List<PictureBox> pictureBoxPlayer2Hand;
        public Button newGame_btn;
        private PictureBox pictureBoxDiscardPile;

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
            // pictureTable
            //
            var pictureTable = new PictureBox();
            pictureTable.BackColor = SystemColors.ActiveCaptionText;
            pictureTable.BackgroundImage = Properties.Resources.table_removebg_preview_1920x10801;
            pictureTable.BackColor = Color.Black;
            pictureTable.BackgroundImageLayout = ImageLayout.Zoom;
            pictureTable.Location = new Point(0, 0);
            pictureTable.Size = this.Size;
            Controls.Add(pictureTable);
            pictureTable.SendToBack();

            //
            // picturePlayerOne
            //
            var picturePlayerOne = new PictureBox();
            picturePlayerOne.BackgroundImage = Properties.Resources.player1_removebg_preview;
            picturePlayerOne.BackgroundImageLayout = ImageLayout.Zoom;
            picturePlayerOne.BackColor = Color.Transparent;
            picturePlayerOne.Location = new Point(70, 90);
            picturePlayerOne.Size = new Size(100, 78);

            pictureTable.Controls.Add(picturePlayerOne);
            //
            // picturePlayerTwo
            //
            var picturePlayerTwo = new PictureBox();
            picturePlayerTwo.BackgroundImage = Properties.Resources.player2_removebg_preview;
            picturePlayerTwo.BackgroundImageLayout = ImageLayout.Zoom;
            picturePlayerTwo.BackColor = Color.Transparent;
            picturePlayerTwo.Location = new Point(70, 595);
            picturePlayerTwo.Size = new Size(100, 78);

            pictureTable.Controls.Add(picturePlayerTwo);

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

            Controls.Add(rules_btn);
            rules_btn.BringToFront();

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
            //
            // rules_btn
            //
            newGame_btn = new Button();
            newGame_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            newGame_btn.Location = new System.Drawing.Point(100, 0);
            newGame_btn.Size = new System.Drawing.Size(111, 37);
            newGame_btn.Text = "New Game";
            newGame_btn.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(newGame_btn);
            //
            // PlayerOneNameLabel
            //
            labelNameP1 = new Label();
            labelNameP1.Location = new Point(70, 152);
            labelNameP1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            labelNameP1.AutoSize = true;
            labelNameP1.ForeColor = Color.Black;
            labelNameP1.BackColor = Color.White;
            Controls.Add(labelNameP1);
            labelNameP1.BringToFront();
            labelNameP1.Hide();
            //
            // PlayerTwoNameLabel
            //
            labelNameP2 = new Label();
            labelNameP2.Location = new Point(70, 657);
            labelNameP2.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            labelNameP2.AutoSize = true;
            labelNameP2.ForeColor = Color.Black;
            labelNameP2.BackColor = Color.White;
            Controls.Add(labelNameP2);
            labelNameP2.BringToFront();
            labelNameP2.Hide();

            pictureBoxPlayer1Hand = new List<PictureBox>(5);
            pictureBoxPlayer2Hand = new List<PictureBox>(5);
            for (int i = 0; i < 5; i++)
            {
                var pictureBoxCard = new PictureBox();
                pictureBoxCard.Size = new Size(50, 80);
                pictureBoxCard.Location = new Point(180 + 60 * i, 100);
                pictureBoxCard.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBoxCard.BackColor = Color.Transparent;
                pictureBoxPlayer1Hand.Add(pictureBoxCard);

                var pictureBoxCard2 = new PictureBox();
                pictureBoxCard2.Size = new Size(50, 80);
                pictureBoxCard2.Location = new Point(180 + 60 * i, 600);
                pictureBoxCard2.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBoxCard2.BackColor = Color.Transparent;

                pictureBoxPlayer2Hand.Add(pictureBoxCard2);
            }
            foreach (var cardBox in pictureBoxPlayer1Hand)
            {
                pictureTable.Controls.Add(cardBox);
                cardBox.BringToFront();
            }
            foreach (var cardBox in pictureBoxPlayer2Hand)
            {
                pictureTable.Controls.Add(cardBox);
                cardBox.BringToFront();
            }

            pictureBoxDiscardPile = new PictureBox();
            pictureBoxDiscardPile.Size = new Size(70, 100);
            pictureBoxDiscardPile.Location = new Point(400, 300);
            pictureBoxDiscardPile.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxDiscardPile.BackColor = Color.Transparent;
            pictureBoxDiscardPile.BorderStyle = BorderStyle.FixedSingle;
            pictureTable.Controls.Add(pictureBoxDiscardPile);

            var pictureBoxDrawPile = new PictureBox();
            pictureBoxDrawPile.Size = new Size(70, 100);
            pictureBoxDrawPile.Location = new Point(490, 300);
            pictureBoxDrawPile.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxDrawPile.BackColor = Color.Transparent;
            pictureBoxDrawPile.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxDrawPile.Image = ResizeImage(Resources.deck_img_removebg_preview, 70, 100);
            pictureTable.Controls.Add(pictureBoxDrawPile);
        }

        internal void DisplayCurrentGamePhase(int currentRound, GamePhase currentPhase)
        {
        }

        private void rules_btn_Click(object sender, EventArgs e)
        {
            var rulesForm = new RulesForm();
            rulesForm.Show();
        }

        public void DisplayNames(string namePlayer1, string namePlayer2)
        {
            labelNameP1.Text = namePlayer1;
            labelNameP2.Text = namePlayer2;
            labelNameP1.Show();
            labelNameP2.Show();
        }

        public void DisplayHands(List<CardBase> handplayer1, List<CardBase> handplayer2)
        {
            for (int i = 0; i < handplayer1.Count; i++)
            {
                pictureBoxPlayer1Hand[i].Image = ResizeImage(handplayer1[i].GetImage(true), pictureBoxPlayer1Hand[i].Width, pictureBoxPlayer1Hand[i].Height);
            }
            for (int i = 0; i < handplayer2.Count; i++)
            {
                pictureBoxPlayer2Hand[i].Image = ResizeImage(handplayer2[i].GetImage(true), pictureBoxPlayer2Hand[i].Width, pictureBoxPlayer2Hand[i].Height);
            }
        }

        public void DisplayDiscardPile(CardBase topCard)
        {
            pictureBoxDiscardPile.Image = ResizeImage(topCard.GetImage(true), pictureBoxDiscardPile.Width, pictureBoxDiscardPile.Height);
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}