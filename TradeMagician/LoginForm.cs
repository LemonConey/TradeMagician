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
        public bool Success { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Success = false;
            IList<Broker> brokerList = ServerConfiguration.GetBrokers();
            broker.DisplayMember = "BrokerName";
            broker.Items.AddRange(brokerList.ToArray<Broker>());
            broker.SelectedIndex = 0;
            server.DisplayMember = "Name";

            //TODO:for test
            userName.Text = "155092";
            password.Text = "666666";
            broker.SelectedIndex = 1;
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
            LoginContext.UserName = userName.Text;
            LoginContext.Password = password.Text;
            LoginContext.BrokerInfo = broker.SelectedItem as Broker;
            LoginContext.ServerInfo = server.SelectedItem as Server;

            ApiContext.InitApiContext();

            while (ApiContext.QuoteLoginSuccess.WaitOne() && ApiContext.TradeLoginSuccess.WaitOne())
            {
                this.Success = true;
                break;
            }

            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
