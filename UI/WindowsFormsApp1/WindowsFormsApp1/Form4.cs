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
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        MqttClient mqttClient;
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void Form4_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                mqttClient = new MqttClient("broker.mqttdashboard.com");
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishRecived;
                mqttClient.Subscribe(new string[] { "UI/del/db" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect("N/FFF");

            });
        }

        private void MqttClient_MqttMsgPublishRecived(object sender, MqttMsgPublishEventArgs e)
        {

            var message = Encoding.UTF8.GetString(e.Message);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox1.Text != "Lot ID")
            {
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    var send = textBox1.Text;
                    mqttClient.Publish("UI/del/db", Encoding.UTF8.GetBytes(send));
                }
                this.Close();
            }
            
        }
    }
}
