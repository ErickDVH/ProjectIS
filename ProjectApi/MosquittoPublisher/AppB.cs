using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace MosquittoPubAndSub
{
    public partial class AppB : Form
    {
        MqttClient mcClient = new MqttClient("127.0.0.1");
        public AppB()
        {
            InitializeComponent();
        }

        private void buttonConnectBroker_Click(object sender, EventArgs e)
        {            
            mcClient.Connect(Guid.NewGuid().ToString());
            if (!mcClient.IsConnected)
            {
                Console.WriteLine("Error connecting to lightbulb...");
                return;
            }
            MessageBox.Show("Connected!");
        }

        private void ON_Click(object sender, EventArgs e)
        {
            if (mcClient.IsConnected)
            {
                mcClient.Publish("lightbulb", Encoding.UTF8.GetBytes("on"));
                MessageBox.Show("Lightbulb is on!");
            }
        }
        
        private void OFF_Click(object sender, EventArgs e)
        {
            if (mcClient.IsConnected)
            {
                mcClient.Publish("lightbulb", Encoding.UTF8.GetBytes("off"));
                MessageBox.Show("Lightbulb is off!");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
