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
    public partial class Form1 : Form
    {
        MqttClient mqttClient;

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
            connect_DB();
            Task.Run(() =>
            {
                mqttClient = new MqttClient("broker.mqttdashboard.com");
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishRecived;
                mqttClient.Subscribe(new string[] { "NonJoong/hardware/temp" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect("N/FFF");

            });
            
        }

        private void MqttClient_MqttMsgPublishRecived(object sender, MqttMsgPublishEventArgs e)
        {
            
            var message = Encoding.UTF8.GetString(e.Message);
            textBox1.Invoke((MethodInvoker)(() => textBox1.Text = message));
            textBox2.Invoke((MethodInvoker)(() => textBox2.Text = message));
            textBox3.Invoke((MethodInvoker)(() => textBox3.Text = message));
           
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.TextAlign = HorizontalAlignment.Center;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.TextAlign = HorizontalAlignment.Center;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void connect_DB()
        {
            string query = "SELECT * FROM lots";
            var con = new MySqlConnection("host = s465z7sj4pwhp7fn.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=b753i7m0218wctsc;password=tl9g3z6d7jrioh7f;database=edrbr8lt4e4qwwe1;port=3306");
            MySqlCommand cmd = new MySqlCommand(query, con);

            try
            {
                con.Open();

                string viewData = "SELECT * FROM lots";
                MySqlDataAdapter adapter = new MySqlDataAdapter(viewData, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                label4.Text = "Concected";
                label4.ForeColor = Color.LightGreen;
                con.Close();

            }

            catch
            {
                label4.Text = "Disconcected";
                label4.ForeColor = Color.Red;
            }

        }



        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {

                string value = comboBox1.Text;

                Task.Run(() =>
                {
                    if (value == "1")
                    {
                        if (mqttClient != null && mqttClient.IsConnected)
                        {
                            mqttClient.Publish("NonJoong/hardware/temp", Encoding.UTF8.GetBytes("XYZ"));
                        }
                    }
                    else if (value == "2")
                    {
                        if (mqttClient != null && mqttClient.IsConnected)
                        {
                            mqttClient.Publish("NonJoong/hardware/water2", Encoding.UTF8.GetBytes("ON2"));
                        }
                    }
                    else if (value == "3")
                    {
                        if (mqttClient != null && mqttClient.IsConnected)
                        {
                            mqttClient.Publish("NonJoong/hardware/water3", Encoding.UTF8.GetBytes("ON3"));
                        }
                    }
                });
            }
        }

        public static implicit operator Form1(UpdateStatus v)
        {
            throw new NotImplementedException();
        }


        private void pictureBox9_Click(object sender, EventArgs e)
        {
            connect_DB();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            connect_DB();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}