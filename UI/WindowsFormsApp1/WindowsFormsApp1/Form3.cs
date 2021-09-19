using MySql.Data.MySqlClient;
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

    public partial class Form3 : Form
    {
        string notready;
        string ready;
        public Form3()
        {
            InitializeComponent();

        }

        MqttClient mqttClient;
        private void Form3_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                mqttClient = new MqttClient("broker.mqttdashboard.com");
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishRecived;
                mqttClient.Subscribe(new string[] { "UI/update/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect("GG");

            });
        }

        private void MqttClient_MqttMsgPublishRecived(object sender, MqttMsgPublishEventArgs e)
        {

            var message = Encoding.UTF8.GetString(e.Message);
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
            
            connect_DB();
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
        private void connect_DB()
        {
            string query = "SELECT * FROM lots";
            var con = new MySqlConnection("host = s465z7sj4pwhp7fn.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=b753i7m0218wctsc;password=tl9g3z6d7jrioh7f;database=edrbr8lt4e4qwwe1;port=3306");
            MySqlCommand cmd = new MySqlCommand(query, con);

            try
            {
                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()){
                    if(reader.GetString("id") == textBox1.Text)
                    {
                        notready = reader.GetString("not_ready_for_sale");
                        textBox2.Text = reader.GetString("ready_for_sale");
                        ready = reader.GetString("ready_for_sale");
                    }
                }

                con.Close();
            }

            catch
            {
                MessageBox.Show("ERROR");
            }

        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

            private void updateDB()
        {
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
                var ready2 = int.Parse(textBox2.Text);
                var unready = int.Parse(notready) - (int.Parse(textBox2.Text)-int.Parse(ready));

                string send = textBox1.Text + ";" + ready2 + ";" + unready + ";" + date;
                mqttClient.Publish("UI/update/db", Encoding.UTF8.GetBytes(send));
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != "add ready" && textBox1.Text != "" && textBox1.Text != "Lot ID")
            {
                updateDB();
                this.Close();
            }
        }
    }
}