using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TradeMagician
{
    class Broker
    {
        public String BrokerID { get; set; }
        public String BrokerName { get; set; }
        public String BrokerEName { get; set; }
        //public String BrokerType { get; set; }
    }

    class Server
    {
        public Server()
        {
            Trading = new List<String>();
            MarketData = new List<String>();
        }
        public String Name { get; set; }
        public IList<String> Trading { get; set; }
        public IList<String> MarketData { get; set; }

    }

    class ServerConfiguration
    {
        private static XmlDocument GetServerConfigFile()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"Config\Servers.xml");
            return xml;
        }
        public static IList<Broker> GetBrokers()
        {
            XmlDocument xml = GetServerConfigFile();
            XmlNodeList nodeList = xml.SelectNodes(@"/root/broker");
            IList<Broker> brokerList = new List<Broker>();
            foreach (var node in nodeList)
            {
                var element = node as XmlElement;
                var broker = new Broker();
                broker.BrokerID = element.GetAttribute("BrokerID");
                broker.BrokerName = element.GetAttribute("BrokerName");
                broker.BrokerEName = element.GetAttribute("BrokerEName");
                brokerList.Add(broker);
            }
            return brokerList;
        }

        public static IList<Server> GetServers(String brokerID)
        {
            XmlDocument xml = GetServerConfigFile();
            IList<Server> servers = new List<Server>();
            String path = string.Format(@"/root/broker[@BrokerID='{0}']/Servers/Server", brokerID);
            XmlNodeList serverNodeList = xml.SelectNodes(path);
            foreach (var serverNode in serverNodeList)
            {
                
                XmlElement serverEl = serverNode as XmlElement;
                Server server = new Server();
                server.Name = serverEl.SelectSingleNode(@"Name").InnerText;
                XmlNodeList tradingItemsNodes = serverEl.SelectNodes(@"Trading/item");
                foreach (XmlNode tradingItemNode in tradingItemsNodes)
                {
                    server.Trading.Add(tradingItemNode.InnerText);
                }

                XmlNodeList marketDataNodes = serverEl.SelectNodes(@"MarketData/item");
                foreach (XmlNode marketDataNode in marketDataNodes)
                {
                    server.MarketData.Add(marketDataNode.InnerText);
                }
                servers.Add(server);
                
            }
            return servers;
        }
    }
}
