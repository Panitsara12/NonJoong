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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox3.SelectedItem != null)
                {
                    listBox2.Items.Add(comboBox3.SelectedItem);
                    int cost = 0;
                    if (comboBox2.SelectedItem == "")
                    {
                        cost = Convert.ToInt32(comboBox3.SelectedItem) * 50;
                        listBox2.Items.Add(cost);
                        listBox1.Items.Add(comboBox2.SelectedItem);
                    }
                }
    }
}
