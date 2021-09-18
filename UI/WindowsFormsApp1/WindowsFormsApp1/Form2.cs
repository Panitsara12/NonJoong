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
    public partial class Form2 : Form
    {
        MqttClient mqttClient;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                mqttClient = new MqttClient("broker.mqttdashboard.com");
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishRecived;
                mqttClient.Subscribe(new string[] { "UI/insert/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect("UI/insert/#");

            });
        }

        private void MqttClient_MqttMsgPublishRecived(object sender, MqttMsgPublishEventArgs e)
        {

            var message = Encoding.UTF8.GetString(e.Message);
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

        private void button2_Click(object sender, EventArgs e)
        {
       
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != ""))
            {
                if ((textBox1.Text != "quantity") && (textBox6.Text != "ready") && (textBox7.Text != "not ready") && (textBox8.Text != "defet") && (textBox9.Text != "tank"))
                {
                    //var date = DateTime.Now.ToString("yyyy/MM/dd");
                    string date;
                    var yearPS = DateTime.Now.ToString("yyyy");

                    if (int.Parse(yearPS) >= 2500)
                    {
                        var year = (int.Parse(yearPS) - 543).ToString();
                        var DM = DateTime.Now.ToString("MM/dd");
                        date = year + "/" + DM;
                    }
                    else
                    {
                        date = DateTime.Now.ToString("yyyy/MM/dd");
                    }
                    if (mqttClient != null && mqttClient.IsConnected)
                    {
                        string send = textBox1.Text + ";" + textBox6.Text + ";" + textBox7.Text + ";" + textBox8.Text + ";" + textBox9.Text + ";" + date;
                        mqttClient.Publish("UI/insert/db", Encoding.UTF8.GetBytes(send));
                    }
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
