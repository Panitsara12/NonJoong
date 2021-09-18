using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        MqttClient mqttClient;
        public Form4()
        {
            InitializeComponent();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox1.Text != "")
            {
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    var send = textBox1.Text;
                    mqttClient.Publish("UI/delete/db", Encoding.UTF8.GetBytes(send));
                }
            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
