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
    public partial class GG : Form
    {
        MqttClient mqttClient;
        public GG()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                mqttClient = new MqttClient("broker.mqttdashboard.com");
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                mqttClient.Subscribe(new string[] { "insertDB/student/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect("GGEZ");

            });
        }

        private void MqttClient_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);
            listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(message)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string senders = "insertDB/student/insert";
            if (senders != "")
            {
                Task.Run(() =>
                {
                    if (mqttClient != null && mqttClient.IsConnected)
                    {
                        mqttClient.Publish(senders, Encoding.UTF8.GetBytes(textBox2.Text));
                    }
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string reveiver = textBox3.Text;
            string reveiver = "insertDB/student/#";
            if (reveiver != "")
            {
                Task.Run(() =>
                {
                    mqttClient = new MqttClient("broker.mqttdashboard.com");
                    mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                    mqttClient.Subscribe(new string[] { reveiver }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                    mqttClient.Connect("GGEZ");
                });
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string senders = "insertDB/student/update";
            if (senders != "") 
            {
                Task.Run(() =>
                {
                    if (mqttClient != null && mqttClient.IsConnected)
                    {
                        string nextstep = textBox2.Text + "," + textBox4.Text;
                        mqttClient.Publish(senders, Encoding.UTF8.GetBytes(nextstep));
                    }
                });
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
