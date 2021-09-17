using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Lot ID")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
            if (textBox1.Text == "")
            {
                textBox1.Text = "Lot ID";

                textBox1.ForeColor = Color.Gray;
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "add ready")
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.Black;
            }
            textBox2.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.TextAlign = HorizontalAlignment.Center;
            if (textBox2.Text == "")
            {
                textBox2.Text = "add ready";

                textBox2.ForeColor = Color.Gray;
                textBox2.TextAlign = HorizontalAlignment.Center;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
      
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int A;
            
            if(textBox2.Text != "")
            {
                if (textBox2.Text == "add ready")
                {
                    textBox2.Text = "1";
                }
                else
                {
                    A = int.Parse(textBox2.Text) + 1;

                    textBox2.Text = A.ToString();
                }
            }
            else
            {
                textBox2.Text = "1";
            }
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int A;

            if(textBox2.Text != "")
            {
                if (textBox2.Text == "add ready")
                {
                    textBox2.Text = "0";
                    A = int.Parse(textBox2.Text) - 1;

                    textBox2.Text = A.ToString();
                }
                else
                {
                    A = int.Parse(textBox2.Text) - 1;

                    textBox2.Text = A.ToString();
                }
            }
            else
            {
                textBox2.Text = "0";
                A = int.Parse(textBox2.Text) - 1;

                textBox2.Text = A.ToString();
            }
            
           
        }
    }
}