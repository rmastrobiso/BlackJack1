using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        public Deck currentDeck { get; set; }
        public Hand playerHand { get; set; }
        public Hand dealerHand { get; set; }
        public int numCards { get; set; }
        public bool newGame = true;

        public Form1()
        {
            InitializeComponent();

            btnDeal.Visible = true;
            btnHit.Visible = false;
            btnStick.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Events
        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (newGame)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                pictureBox11.Visible = false;
                pictureBox12.Visible = false;

                newGame = false;
            }

            numCards = 2;
            currentDeck = new Deck();
            playerHand = new Hand(numCards);
            dealerHand = new Hand(2);

            playerHand.DealCards(currentDeck, numCards);
            DisplayHand(playerHand);
            playerHand.EvaluateHand();

            richTextBox1.Text = playerHand.result + Environment.NewLine;
            btnDeal.Visible = false;
            btnHit.Visible = true;
            btnStick.Visible = true;
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            playerHand.AddCard(currentDeck, 1);
            DisplayHand(playerHand);
            playerHand.EvaluateHand();

            richTextBox1.Text = playerHand.result + Environment.NewLine;
            btnDeal.Visible = false;
            btnHit.Visible = true;
            btnStick.Visible = true;

            if (playerHand.score >= 21)
            {
                EndGame(playerHand, dealerHand);
            }
        }

        private void btnStick_Click(object sender, EventArgs e)
        {
            EndGame(playerHand, dealerHand);
        }
        #endregion

        #region Methods
        public void DisplayHand(Hand playerHand)
        {
            int count = 0;
            string currentcard_picture = "";
            DateTime t = DateTime.Now;

            if (playerHand.cards != null && playerHand != null)
                foreach (Card currentcard in playerHand.cards)
                {
                    if (currentcard != null && currentcard.suit != "")
                        currentcard_picture = "_" + currentcard.value.ToString() + "_" + currentcard.suit;
                    else
                        currentcard_picture = "space";

                    if (count == 0)
                    {

                        pictureBox1.Visible = true; 
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox1.Image = myImage;
                        pictureBox1.BringToFront();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 1)
                    {
                        pictureBox2.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox2.Image = myImage;
                        pictureBox2.BringToFront();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 2)
                    {
                        pictureBox3.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox3.BringToFront();
                        pictureBox3.Image = myImage;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 3)
                    {
                        pictureBox4.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox4.BringToFront();
                        pictureBox4.Image = myImage;
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 4)
                    {
                        pictureBox5.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        pictureBox3.BringToFront();
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox5.BringToFront();
                        pictureBox5.Image = myImage;
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 5)
                    {
                        pictureBox6.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox6.BringToFront();
                        pictureBox6.Image = myImage;
                        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 6)
                    {
                        pictureBox7.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox7.BringToFront();
                        pictureBox7.Image = myImage;
                        pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 7)
                    {
                        pictureBox8.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox8.BringToFront();
                        pictureBox8.Image = myImage;
                        pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 8)
                    {
                        pictureBox9.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox9.BringToFront();
                        pictureBox9.Image = myImage;
                        pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 9)
                    {
                        pictureBox10.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox10.BringToFront();
                        pictureBox10.Image = myImage;
                        pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 10)
                    {
                        pictureBox11.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox11.BringToFront();
                        pictureBox11.Image = myImage;
                        pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 11)
                    {
                        pictureBox12.Visible = true;
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox12.BringToFront();
                        pictureBox12.Image = myImage;
                        pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    count++;
                }
        }

        private void EndGame(Hand playerHand, Hand dealerHand)
        {
            dealerHand.DealCards(currentDeck, numCards); //deal cards to dealer
            dealerHand.EvaluateHand();

            while (dealerHand.score < 15) //dealer sticks on 15 or higher
            {
                dealerHand.AddCard(currentDeck, 1);
                dealerHand.EvaluateHand();
            }

            if (playerHand.score > 21)
                richTextBox1.Text = "You bust better luck next time." + Environment.NewLine;

            if (dealerHand.score > 21)
            {
                richTextBox1.Text = "Dealer has " + dealerHand.score + ", congratulations you win ." + Environment.NewLine;
            }
            else
            {
                if ((dealerHand.score >= dealerHand.score) && (dealerHand.score <= 21))
                                    richTextBox1.Text += "Dealer has " + dealerHand.score + ", congratulations you win ." + Environment.NewLine;

                if (playerHand.score == 21)
                    richTextBox1.Text = "Congratulations BLACKJACK, you win ." + Environment.NewLine;
            }

            btnDeal.Visible = true; 
            btnHit.Visible = false;
            btnStick.Visible = false;

            newGame = true;
        }
        #endregion
    }
}
