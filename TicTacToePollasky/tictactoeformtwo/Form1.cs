using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoeformtwo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this method brings up the game board in one player mode
            mainForm frm = new mainForm(); // create the main form
            frm.Text = "TicTacToe: One Player"; // change the title text to indicate one player mode
            frm.FormClosed += new FormClosedEventHandler(mainForm_FormClosed); // not really sure what this line does, grabbed it from the help file
            frm.Show(); // show the main form
            this.Hide(); // hide this splash form
        }
    }
}
