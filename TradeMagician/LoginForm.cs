using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradeMagician
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            IList<Broker> brokerList = ServerConfiguration.GetBrokers();
            broker.DisplayMember = "BrokerName";
            broker.Items.AddRange(brokerList.ToArray<Broker>());
            broker.SelectedIndex = 0;
            server.DisplayMember = "Name";
        }

        private void broker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            Broker broker = box.SelectedItem as Broker;
            IList<Server> serverlist = ServerConfiguration.GetServers(broker.BrokerID);
            server.Items.Clear();
            server.Items.AddRange(serverlist.ToArray<Server>());
            server.SelectedIndex = 0;
        }

        private void login_Click(object sender, EventArgs e)
        {
            Console.WriteLine("计时器频率: " + Stopwatch.Frequency);
            TestCode.TestQuoteApi();
            //TestTradeApi();
            Console.Read();
            //quoteApi.Disconnect();
            //tradeApi.Disconnect();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
