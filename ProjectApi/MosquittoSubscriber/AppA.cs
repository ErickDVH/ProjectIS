using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Xml;
using System.Text;

namespace MosquittoSubscriber
{
    public partial class AppA : Form
    {
        MqttClient mClient = new MqttClient("127.0.0.1");

        public AppA()
        {
            InitializeComponent();
        }

        private void client_messageReceived(object sender, MqttMsgPublishEventArgs e)
        {
            
             XDocument xmlDoc = XDocument.Parse(e.Message);
             string xmlString = Encoding.UTF8.GetString(xmlDoc);
            // Get the value of the "value" element
            string value = xmlString.Root.Element("value").Value;

            MessageBox.Show("Received: " + value);
            

            if (value == "off")
            {
                light_on.BeginInvoke((MethodInvoker)delegate { light_on.Hide(); });
                light_off.BeginInvoke((MethodInvoker)delegate { light_off.Show(); });
            }
            if (value == "on")
            {
                light_on.BeginInvoke((MethodInvoker)delegate { light_on.Show(); });
                light_off.BeginInvoke((MethodInvoker)delegate { light_off.Hide(); });
            }

        }

        /*
        private void buttonConnSubs_Click(object sender, EventArgs e)
        {
            mClient = new MqttClient(IPAddress.Parse(textBoxBrokerDomain.Text));

            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }
            MessageBox.Show("Connected!");
            //Specify events we are interest on
            //New Msg Arrived
            mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            //Subscribe to topics
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }; //QoS – depends on the topics number
            mClient.Subscribe(mStrTopicsInfo, qosLevels);
        }
        */

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
