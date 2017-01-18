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
        public Deck currentdeck { get; set; }
        public Hand player_hand { get; set; }
        public Hand dealer_hand { get; set; }
        public int numcards { get; set; }

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
            numcards = 2;
            currentdeck = new Deck();
            player_hand = new Hand(numcards);
            dealer_hand = new Hand(2);

            player_hand.deal_cards(currentdeck, numcards);
            display_hand(player_hand);
            player_hand.evaluate_hand();

            richTextBox1.Text = player_hand.result + Environment.NewLine;
            btnDeal.Visible = false;
            btnHit.Visible = true;
            btnStick.Visible = true;
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            player_hand.add_card(currentdeck, 1);
            display_hand(player_hand);
            player_hand.evaluate_hand();

            richTextBox1.Text = player_hand.result + Environment.NewLine;
            btnDeal.Visible = false;
            btnHit.Visible = true;
            btnStick.Visible = true;

            if (player_hand.score >= 21)
            {
                end_game(player_hand, dealer_hand);
            }
        }

        private void btnStick_Click(object sender, EventArgs e)
        {
            end_game(player_hand, dealer_hand);
        }
        #endregion

        #region Methods
        public void display_hand(Hand playerhand)
        {
            int count = 0;
            string currentcard_picture = "";
            DateTime t = DateTime.Now;

            if (playerhand.cards != null && playerhand != null)
                foreach (Card currentcard in playerhand.cards)
                {
                    if (currentcard != null && currentcard.suit != "")
                    {
                        if (currentcard.value < 10)
                            currentcard_picture = "_" + currentcard.value.ToString() + "_" + currentcard.suit;
                        if (currentcard.value == 10)
                            currentcard_picture = "_" + currentcard.value.ToString() + "_" + currentcard.suit;
                        if (currentcard.value == 11)
                            currentcard_picture = "J" + "_" + currentcard.suit;
                        if (currentcard.value == 12)
                            currentcard_picture = "Q" + "_" + currentcard.suit;
                        if (currentcard.value >= 13)
                            currentcard_picture = "K" + "_" + currentcard.suit;
                    }
                    else
                        currentcard_picture = "space";

                    if (count == 0)
                    {

                        pictureBox1.Visible = true; //showing first card
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

        private void end_game(Hand player_hand, Hand dealer_hand)
        {
            dealer_hand.deal_cards(currentdeck, numcards); //deal cards to dealer
            dealer_hand.evaluate_hand();
            while (dealer_hand.score < 15) //dealer sticks on 15 or higher
            {
                dealer_hand.add_card(currentdeck, 1);
                dealer_hand.evaluate_hand();
            }
            if (player_hand.score > 21)
            {
                richTextBox1.Text = "You bust better luck next time." + Environment.NewLine;
            }
            if (dealer_hand.score > 21)
            {
                richTextBox1.Text = "Dealer has " + dealer_hand.score + ", congratulations you win ." + Environment.NewLine;
            }
            else
            {
                if ((player_hand.score >= dealer_hand.score) && (player_hand.score <= 21))
                {
                    richTextBox1.Text += "Dealer has " + dealer_hand.score + ", congratulations you win ." + Environment.NewLine;
                }
                if (player_hand.score == 21)
                {
                    richTextBox1.Text = "Congratulations BLACKJACK, you win ." + Environment.NewLine;
                }
            }
            btnDeal.Visible = true; 
            btnHit.Visible = false;
            btnStick.Visible = false;
        }
        #endregion
    }
}
