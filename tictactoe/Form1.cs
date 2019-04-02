using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        bool turn = true; // When True It's X turn, If false O's turn
        int turnCount = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            Application.Exit(); // exit button
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Joar", "Tic Tac Toe"); //about button info
        }

        private void button_click(object sender, EventArgs e) // Playing field
        {
            Button b = (Button)sender;  // gives the button a value/text X / O
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turnCount++;                // counting all the moves...

            WinnerCheck();
        }

        private void WinnerCheck()
        {
            bool winner = false;
          

            //horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;

            //vertical checks
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;

            //diagonal checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                winner = true;



            if (winner)                 // shows the winner 
            {
                DisableButtons();
                string win = "";
                if (turn)
                    win = "O";
                else
                    win = "X";
                MessageBox.Show("Player " + win + " Wins!", "Winner"); //popup text for the winner
            }

            else          // no winner, popup for draw 
            {
                if(turnCount == 9)
                    MessageBox.Show("Draw! ", "Who Won!?");
            }

        }

        private void DisableButtons() //disable the rest of the buttons so you can't keep playing
        {
            try
            {
                foreach(Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void A3_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e) // new game
        {
            turn = true;        // returning the values to startvalue
            turnCount = 0;
            try
            {
                foreach (Control c in Controls)    // enable the buttons again
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}
