using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToePollasky
{
    public partial class Form1 : Form
    {



        Label[,] grid = new Label[3, 3];

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            setupScreen();
            setupGame();
        }



        private void setupGame()
        {
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    grid[x, y].Text = "";
                }
            }
        }

        private void setupScreen()
        {
            grid[0, 0] = label1;
            grid[0, 1] = label2;
            grid[0, 2] = label3;
            grid[1, 0] = label4;
            grid[1, 1] = label5;
            grid[1, 2] = label6;
            grid[2, 0] = label7;
            grid[2, 1] = label8;
            grid[2, 2] = label9;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            this.Text = "TicTacToe: One Player";
            ComputerMove();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;

        }


        public int CurrentPlayer()
        {
            // this tells the computer what players turn it is (1 or 2)
            int PlayerNumberInt = 0; 
            string PlayerNumberText = lblPlayer.Text.Substring(lblPlayer.Text.Length + 0); 
            // assign 1 if it's player one's turn
            if (PlayerNumberText == "x")
            {
                PlayerNumberInt = 1;
            }
            // assign 2 if it's player two's turn
            else if (PlayerNumberText == "o")
            {
                PlayerNumberInt = 2;
            }
            else 
            {
                
            }
            return PlayerNumberInt;
        }

        private void changePlayers()
        {
            // this method changes the lblPlayer text from one player to the other
            // if it was player one's turn change to player two
            if (lblPlayer.Text == "x")
            {
                lblPlayer.Text = "o";
                // if in one player mode, and no one has won yet, the computer moves automatically during player two's turn
                if (this.Text == "TicTacToe: One Player" && label1.Enabled == true)
                {
                    ComputerMove(); // call the method for the computer to make its move
                }
            }
            else if (lblPlayer.Text == "o")
            {
                lblPlayer.Text = "o";
            }
            else 
            {
                
            }
        }

        private void changeSquare(int xPos, int yPos)
        {
            String lastMove = lblPlayer.Text;

            if (grid[xPos, yPos].Text == "")
            {
                grid[xPos, yPos].Text = lblPlayer.Text;
                if (grid[xPos, yPos].Text == "X")
                {
                    lblPlayer.Text = "O";
                }
                else
                {
                    lblPlayer.Text = "X";
                }
            }

            // Check if the new move has won the game
            checkWin(lastMove);
        }

        private void checkWin(String lastMove)
        {
            Boolean hasWon = false;
            if (grid[0, 0].Text == lastMove && grid[0, 0].Text == grid[0, 1].Text && grid[0, 1].Text == grid[0, 2].Text)
            {
                hasWon = true;
                MessageBox.Show(lastMove + " Wins!!", "Congratulations!!");
               
            }
            else if (grid[1, 0].Text == lastMove && grid[1, 0].Text == grid[1, 1].Text && grid[1, 1].Text == grid[1, 2].Text)
            {
                hasWon = true;
                MessageBox.Show(lastMove + " Wins!!", "Congratulations!!");
            }
            else if (grid[2, 0].Text == lastMove && grid[2, 0].Text == grid[2, 1].Text && grid[2, 1].Text == grid[2, 2].Text)
            {
                hasWon = true;
                MessageBox.Show(lastMove + " Wins!!", "Congratulations!!");
            }
            else if (grid[0, 0].Text == lastMove && grid[0, 0].Text == grid[1, 0].Text && grid[1, 0].Text == grid[2, 0].Text)
            {
                hasWon = true;
                MessageBox.Show(lastMove + " Wins!!", "Congratulations!!");
            }
            else if (grid[0, 1].Text == lastMove && grid[0, 1].Text == grid[1, 1].Text && grid[1, 1].Text == grid[2, 1].Text)
            {
                hasWon = true;
                MessageBox.Show(lastMove + " Wins!!", "Congratulations!!");
            }
            else if (grid[0, 2].Text == lastMove && grid[0, 2].Text == grid[1, 2].Text && grid[1, 2].Text == grid[2, 2].Text)
            {
                hasWon = true;
                MessageBox.Show(lastMove + " Wins!!", "Congratulations!!");
            }
            else if (grid[0, 0].Text == lastMove && grid[0, 0].Text == grid[1, 1].Text && grid[1, 1].Text == grid[2, 2].Text)
            {
                hasWon = true;
                MessageBox.Show(lastMove + " Wins!!", "Congratulations!!");
            }
            else if (grid[0, 2].Text == lastMove && grid[0, 2].Text == grid[1, 1].Text && grid[1, 1].Text == grid[2, 0].Text)
            {
                hasWon = true;
                MessageBox.Show(lastMove + " Wins!!", "Congratulations!!");
            }

            if (hasWon == true)

                this.BackColor = Color.Fuchsia;
        }

        private void ChangeSquare(Label thisLabel)
        {
            // this method will run any time the user selects a button
            // first, check if the box has already been selected and if so, make them pick again
            if (thisLabel.Text != "")
            {
                
            }
            // fill in the box appropriately and change turns
            else
            {
                // find out which player's turn it is currently
                int PlayerNumberInt = CurrentPlayer();
                // place an X for player 1 and O for player 2
                if (PlayerNumberInt == 1)
                {
                    thisLabel.Text = "X";
                }
                else if (PlayerNumberInt == 2)
                {
                    thisLabel.Text = "O";
                }
                else 
                {
                 
                  
                }
             
           
                // call method to change to the other player's turn
                changePlayers();
            }
        }


        private void ComputerMove()
        {
            // this  determines how the computer will select its move

            Random random = new Random();
            if (this.Text == "TicTacToe: One Player" ) 
            {
                bool moveFlag = false; // initially setting the flag that a move has been selected to false
                while (moveFlag == false) // until a move has been selected...
                {
                    int random1to9 = random.Next(1, 9); // pick a random number between 1 and 9, corresponding to a box
                    if (random1to9 == 1 && label1.Text == "") // check if that box is available
                    {
                        ChangeSquare(label1); // select the box
                        moveFlag = true; // change the move flag to true to exit the loop
                    }
                    else if (random1to9 == 2 && label2.Text == "")
                    {
                        ChangeSquare(label2);
                        moveFlag = true;
                    }
                    else if (random1to9 == 3 && label3.Text == "")
                    {
                        ChangeSquare(label3);
                        moveFlag = true;
                    }
                    else if (random1to9 == 4 && label4.Text == "")
                    {
                        ChangeSquare(label4);
                        moveFlag = true;
                    }
                    else if (random1to9 == 5 && label5.Text == "")
                    {
                        ChangeSquare(label5);
                        moveFlag = true;
                    }
                    else if (random1to9 == 6 && label6.Text == "")
                    {
                        ChangeSquare(label6);
                        moveFlag = true;
                    }
                    else if (random1to9 == 7 && label7.Text == "")
                    {
                        ChangeSquare(label7);
                        moveFlag = true;
                    }
                    else if (random1to9 == 8 && label8.Text == "")
                    {
                        ChangeSquare(label8);
                        moveFlag = true;
                    }
                    else if (random1to9 == 9 && label9.Text == "")
                    {
                        ChangeSquare(label9);
                        moveFlag = true;
                    }
                }
            }
        }


        
            private void label1_Click(object sender, EventArgs e)
        {
            changeSquare(0, 0);
            ChangeSquare(label1);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            changeSquare(0, 1);
            ChangeSquare(label2);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            changeSquare(0, 2);
            ChangeSquare(label3);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ChangeSquare(label4);
            changeSquare(1, 0);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            changeSquare(1, 1);
            ChangeSquare(label5);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            changeSquare(1, 2);
            ChangeSquare(label6);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            changeSquare(2, 0);
            ChangeSquare(label7);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            changeSquare(2, 1);
            ChangeSquare(label8);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            changeSquare(2, 2);
            ChangeSquare(label9);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            setupGame();
            this.BackColor = Color.Black;
            button1.Visible = true;
            button2.Visible = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


    }
}



