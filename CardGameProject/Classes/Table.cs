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
        private PictureBox pictureBoxDiscardPile;
        private Label labelCurrentGamePhase;
        private Label labelPlayer1Wallet;
        private Label labelPlayer2Wallet;
        private Label labelCurrentTurn;

        public Button btnNewGame;
        public Button btnCheck;
        public Button btnBet;
        public Button btnCall;
        public Button btnJunk;
        public Button btnDrawCard;
        public Button btnStand;
        public Button btnSwapFromDrawPile;
        public Button btnSwapFromDiscardPile;
        public Button btnRollDice;

        public Table(Size size)
        {
            this.Size = size;
            InitializeComponent();
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
            // btnRules
            //
            var btnRules = new Button();
            btnRules.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnRules.Location = new System.Drawing.Point(1160, 675);
            btnRules.Name = "rules_btn";
            btnRules.Size = new System.Drawing.Size(111, 37);
            btnRules.TabIndex = 2;
            btnRules.Text = "Rules";
            btnRules.UseVisualStyleBackColor = true;
            btnRules.Click += new System.EventHandler(btnRules_Click);

            Controls.Add(btnRules);
            btnRules.BringToFront();

            //
            // txtSabaccPot
            //
            labelSabaccPot = new Label();
            labelSabaccPot.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            labelSabaccPot.Location = new Point(700, 310);
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
            labelMainPot.Location = new Point(700, 370);
            labelMainPot.AutoSize = true;
            labelMainPot.Text = "Main Pot:";
            labelMainPot.TextAlign = ContentAlignment.MiddleCenter;
            labelMainPot.ForeColor = Color.White;
            labelMainPot.BackColor = Color.Black;

            Controls.Add(labelMainPot);

            labelMainPot.BringToFront();
            labelSabaccPot.BringToFront();
            //
            // btnNewGame
            //
            btnNewGame = new Button();
            btnNewGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnNewGame.Location = new System.Drawing.Point(100, 0);
            btnNewGame.Size = new System.Drawing.Size(111, 37);
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnNewGame);
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
            //
            // PicBoxListPlayerHands
            //
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
            //
            // pictureBoxDiscardPile
            //
            pictureBoxDiscardPile = new PictureBox();
            pictureBoxDiscardPile.Size = new Size(70, 100);
            pictureBoxDiscardPile.Location = new Point(500, 300);
            pictureBoxDiscardPile.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxDiscardPile.BackColor = Color.Transparent;
            pictureBoxDiscardPile.BorderStyle = BorderStyle.FixedSingle;
            pictureTable.Controls.Add(pictureBoxDiscardPile);
            //
            // pictureBoxDrawPile
            //
            var pictureBoxDrawPile = new PictureBox();
            pictureBoxDrawPile.Size = new Size(70, 100);
            pictureBoxDrawPile.Location = new Point(590, 300);
            pictureBoxDrawPile.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxDrawPile.BackColor = Color.Transparent;
            pictureBoxDrawPile.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxDrawPile.Image = ResizeImage(Resources.deck_img_removebg_preview, 70, 100);
            pictureTable.Controls.Add(pictureBoxDrawPile);
            //
            // labelPlayer1Wallet
            //
            labelPlayer1Wallet=new Label();
            labelPlayer1Wallet.Location = new Point(40, 172);
            labelPlayer1Wallet.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer1Wallet.AutoSize = true;
            labelPlayer1Wallet.ForeColor= Color.Black;
            labelPlayer1Wallet.BackColor = Color.White;
            Controls.Add(labelPlayer1Wallet);
            labelPlayer1Wallet.BringToFront();
            labelPlayer1Wallet.Hide();
            //
            // labelPlayer2Wallet
            //
            labelPlayer2Wallet = new Label();
            labelPlayer2Wallet.Location = new Point(40, 677);
            labelPlayer2Wallet.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer2Wallet.AutoSize = true;
            labelPlayer2Wallet.ForeColor = Color.Black;
            labelPlayer2Wallet.BackColor = Color.White;
            Controls.Add(labelPlayer2Wallet);
            labelPlayer2Wallet.BringToFront();
            labelPlayer2Wallet.Hide();
            //
            // btnCheck
            //
            btnCheck = new Button();
            btnCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnCheck.Location = new System.Drawing.Point(950, 180);
            btnCheck.Size = new System.Drawing.Size(111, 37);
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnCheck);
            //
            // btnBet
            //
            btnBet = new Button();
            btnBet.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnBet.Location = new System.Drawing.Point(950, 220);
            btnBet.Size = new System.Drawing.Size(111, 37);
            btnBet.Text = "Bet";
            btnBet.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnBet);
            //
            // btnCall
            //
            btnCall = new Button();
            btnCall.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnCall.Location = new System.Drawing.Point(950, 260);
            btnCall.Size = new System.Drawing.Size(111, 37);
            btnCall.Text = "Call";
            btnCall.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnCall);
            //
            // btnJunk
            //
            btnJunk = new Button();
            btnJunk.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnJunk.Location = new System.Drawing.Point(950, 300);
            btnJunk.Size = new System.Drawing.Size(111, 37);
            btnJunk.Text = "Junk";
            btnJunk.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnJunk);
            //
            // btnDrawCard
            //
            btnDrawCard = new Button();
            btnDrawCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnDrawCard.Location = new System.Drawing.Point(950, 340);
            btnDrawCard.Size = new System.Drawing.Size(111, 37);
            btnDrawCard.Text = "Draw Card";
            btnDrawCard.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnDrawCard);
            //
            // btnStand
            //
            btnStand = new Button();
            btnStand.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnStand.Location = new System.Drawing.Point(950, 380);
            btnStand.Size = new System.Drawing.Size(111, 37);
            btnStand.Text = "Stand";
            btnStand.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnStand);
            //
            // btnSwapFromDrawPile
            //
            btnSwapFromDrawPile = new Button();
            btnSwapFromDrawPile.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnSwapFromDrawPile.Location = new System.Drawing.Point(950, 420);
            btnSwapFromDrawPile.Size = new System.Drawing.Size(111, 37);
            btnSwapFromDrawPile.Text = "Swap From Draw Pile";
            btnSwapFromDrawPile.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnSwapFromDrawPile);
            //
            // btnSwapFromDiscardPile
            //
            btnSwapFromDiscardPile = new Button();
            btnSwapFromDiscardPile.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnSwapFromDiscardPile.Location = new System.Drawing.Point(950, 460);
            btnSwapFromDiscardPile.Size = new System.Drawing.Size(111, 37);
            btnSwapFromDiscardPile.Text = "Swap From Discard Pile";
            btnSwapFromDiscardPile.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnSwapFromDiscardPile);

            //
            // btnRollDice
            //
            btnRollDice = new Button();
            btnRollDice.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnRollDice.Location = new System.Drawing.Point(950, 500);
            btnRollDice.Size = new System.Drawing.Size(111, 37);
            btnRollDice.Text = "Roll Dice";
            btnRollDice.UseVisualStyleBackColor = true;

            pictureTable.Controls.Add(btnRollDice);
            //
            // labelCurrentTurn
            //
            labelCurrentTurn=new Label();
            labelCurrentTurn.AutoSize = false;
            labelCurrentTurn.Size = new Size(20, 20);
            labelCurrentTurn.BackColor = Color.Red;
            labelCurrentTurn.Hide();
            Controls.Add(labelCurrentTurn);
            labelCurrentTurn.BringToFront();
            //
            // labelCurrentGamePhase
            //
            labelCurrentGamePhase = new Label();
            labelCurrentGamePhase.Location = new Point(1000, 30);
            labelCurrentGamePhase.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelCurrentGamePhase.AutoSize = true;
            labelCurrentGamePhase.ForeColor = Color.Black;
            labelCurrentGamePhase.BackColor = Color.White;
            Controls.Add(labelCurrentGamePhase);
            labelCurrentGamePhase.BringToFront();
            labelCurrentGamePhase.Hide();
        }

        public void UpdateButtonsForBetPhase()
        {
            btnDrawCard.Hide();
            btnStand.Hide();
            btnSwapFromDrawPile.Hide();
            btnSwapFromDiscardPile.Hide();
            btnCheck.Show();
            btnBet.Show();
            btnCall.Show();
            btnJunk.Show();
            btnRollDice.Hide();
        }

        public void UpdateButtonsForPlayPhase()
        {
            btnDrawCard.Show();
            btnStand.Show();
            btnSwapFromDrawPile.Show();
            btnSwapFromDiscardPile.Show();
            btnCheck.Hide();
            btnBet.Hide();
            btnCall.Hide();
            btnJunk.Hide();
            btnRollDice.Hide();
        }

        public void UpdateButtonsForSpikePhase()
        {
            btnDrawCard.Hide();
            btnStand.Hide();
            btnSwapFromDrawPile.Hide();
            btnSwapFromDiscardPile.Hide();
            btnCheck.Hide();
            btnBet.Hide();
            btnCall.Hide();
            btnJunk.Hide();
            btnRollDice.Show();
        }

        public void ShowAllButtons()
        {
            btnDrawCard.Show();
            btnStand.Show();
            btnSwapFromDrawPile.Show();
            btnSwapFromDiscardPile.Show();
            btnCheck.Show();
            btnBet.Show();
            btnCall.Show();
            btnJunk.Show();
            btnRollDice.Show();
        }
        public void DisplaySabaccPot(int value)
        {
            labelSabaccPot.Text = $"Sabacc Pot: {value} credits";
        }

        public void DisplayMainPot(int value)
        {
            labelMainPot.Text = $"Main Pot: {value} credits";
        }

        public void DisplayDiscardPile(CardBase topCard)
        {
            pictureBoxDiscardPile.Image = ResizeImage(topCard.GetImage(true), pictureBoxDiscardPile.Width, pictureBoxDiscardPile.Height);
        }

        public void DisplayWallets(Player playerOne, Player playerTwo)
        {
            labelPlayer1Wallet.Text = $"Balance: {playerOne.Wallet} credits";
            labelPlayer2Wallet.Text = $"Balance: {playerTwo.Wallet} credits";
            labelPlayer1Wallet.Show();
            labelPlayer2Wallet.Show();
        }
        internal void DisplayCurrentGamePhase(int currentRound, GamePhase currentPhase)
        {

            labelCurrentGamePhase.Text=$"{currentPhase} Phase - Round: {currentRound}";
            labelCurrentGamePhase.Show();

            switch (currentPhase)
            {
                case GamePhase.Bet:
                    UpdateButtonsForBetPhase();
                    break;
                case GamePhase.Play:
                    UpdateButtonsForPlayPhase();
                    break;
                case GamePhase.Spike:
                    UpdateButtonsForSpikePhase();
                    break;
                case GamePhase.Reveal:
                    ShowAllButtons();
                    break;
                default:
                    break;
            }
        }

        private void btnRules_Click(object sender, EventArgs e)
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
            for (int i = 0; i < 5; i++)
            {
                pictureBoxPlayer1Hand[i].Image = null;
                pictureBoxPlayer2Hand[i].Image = null;
            }
            for (int i = 0; i < handplayer1.Count; i++)
            {
                pictureBoxPlayer1Hand[i].Image = ResizeImage(handplayer1[i].GetImage(true), pictureBoxPlayer1Hand[i].Width, pictureBoxPlayer1Hand[i].Height);
            }
            for (int i = 0; i < handplayer2.Count; i++)
            {
                pictureBoxPlayer2Hand[i].Image = ResizeImage(handplayer2[i].GetImage(true), pictureBoxPlayer2Hand[i].Width, pictureBoxPlayer2Hand[i].Height);
            }
        }

        public void DisplayCurrentPlayerTurn(int turn)
        {
            switch(turn) 
            {
                case 1:
                    labelCurrentTurn.Location = new Point(45, 145);
                    labelCurrentTurn.Show();
                    break;
                case 2:
                    labelCurrentTurn.Location = new Point(45, 645);
                    labelCurrentTurn.Show();
                    break;
            }
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