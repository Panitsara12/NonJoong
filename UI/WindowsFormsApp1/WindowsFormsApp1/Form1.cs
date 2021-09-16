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
    public partial class Form1 : Form
    {
        MqttClient mqttClient;
        private readonly string btnClearText;

        public string Clear { get; private set; }
        public object Button5 { get; private set; }

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
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Task.Run(() =>
                {
                    mqttClient = new MqttClient("broker.mqttdashboard.com");
                    mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishRecived;
                    mqttClient.Subscribe(new string[] { "NonJoong/hardware/temp" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                    mqttClient.Connect("N/FFF");
                });
            });
        }

        private void MqttClient_MqttMsgPublishRecived(object sender, MqttMsgPublishEventArgs e)
        {

            var message = Encoding.UTF8.GetString(e.Message);
            textBox1.Invoke((MethodInvoker)(() => textBox1.Text =message));
            textBox2.Invoke((MethodInvoker)(() => textBox2.Text = message));
            textBox3.Invoke((MethodInvoker)(() => textBox3.Text = message));
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
