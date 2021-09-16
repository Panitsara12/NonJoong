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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if(textBox5.Text == "")
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "quantity")
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
                textBox1.Text = "quantity";

                textBox1.ForeColor = Color.Gray;
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.TextAlign = HorizontalAlignment.Center;
            if (textBox6.Text == "ready")
            {
                textBox6.Text = "";

                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox6.TextAlign = HorizontalAlignment.Center;
            if (textBox6.Text == "")
            {
                textBox6.Text = "ready";

                textBox6.ForeColor = Color.Gray;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.TextAlign = HorizontalAlignment.Center;
            if (textBox7.Text == "not ready")
            {
                textBox7.Text = "";

                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            textBox7.TextAlign = HorizontalAlignment.Center;
            if (textBox7.Text == "")
            {
                textBox7.Text = "not ready";

                textBox7.ForeColor = Color.Gray;
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            textBox8.TextAlign = HorizontalAlignment.Center;
            if (textBox8.Text == "defet")
            {
                textBox8.Text = "";

                textBox8.ForeColor = Color.Black;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            textBox8.TextAlign = HorizontalAlignment.Center;
            if (textBox8.Text == "")
            {
                textBox8.Text = "defet";

                textBox8.ForeColor = Color.Gray;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            textBox9.TextAlign = HorizontalAlignment.Center;
            if (textBox9.Text == "tank")
            {
                textBox9.Text = "";

                textBox9.ForeColor = Color.Black;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            textBox9.TextAlign = HorizontalAlignment.Center;
            if (textBox9.Text == "")
            {
                textBox9.Text = "tank";

                textBox9.ForeColor = Color.Gray;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.TextAlign = HorizontalAlignment.Center;
        }
    }
}
