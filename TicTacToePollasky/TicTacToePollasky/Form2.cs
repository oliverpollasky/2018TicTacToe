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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            Form1 frm = new Form1();
            frm.Text = "TicTacToe: One Player"; 
            frm.FormClosed += new FormClosedEventHandler(Form1_FormClosed); 
            frm.Show(); 
            this.Hide(); 
        }
        private void button2_Click(object sender, EventArgs e)
        {
      
            Form1 frm = new Form1();
            frm.Text = "TicTacToe: Two Players";
            frm.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            frm.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }


    }
}
