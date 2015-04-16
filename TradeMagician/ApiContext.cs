using QuantBox;
using QuantBox.XAPI;
using QuantBox.XAPI.Callback;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TradeMagician.Api;

namespace TradeMagician
{
    class ApiContext
    {
        static ApiContext()
        {
            SubscribedContracts = new List<Contract>();
        }
        private static String QuoteApiPath = @"QuantBox_Femas_Quote.dll";
        private static String TradeApiPath = @"QuantBox_Femas_Trade.dll";
        public static XApi QuoteApi { get; set; }
        public static XApi TradeApi { get; set; }

        public static ConcurrentQueue<DepthMarketDataField> DepthMarketDataQueue = new ConcurrentQueue<DepthMarketDataField>();
        public static ConcurrentQueue<PositionField> InvestorPosition = new ConcurrentQueue<PositionField>();
        public static IList<Contract> SubscribedContracts { get; set; }
        public static ManualResetEvent QuoteLoginSuccess = new ManualResetEvent(false);
        public static ManualResetEvent TradeLoginSuccess = new ManualResetEvent(false);
        public static void InitApiContext(){
            
            CreateQuotationApi();
            CreateTraderApi();
        }

        private static void CreateQuotationApi()
        {
            QuoteApi = new XApi(QuoteApiPath);
            QuoteApi.Server.Address = "tcp://" + LoginContext.ServerInfo.MarketData;
            QuoteApi.User.UserID = LoginContext.UserName;
            QuoteApi.User.Password = LoginContext.Password;
            QuoteApi.Server.BrokerID = LoginContext.BrokerInfo.BrokerID;
            QuoteApi.Server.TopicId = LoginContext.BrokerInfo.TopicId;
            QuoteApi.Server.MarketDataTopicResumeType = ResumeType.Quick;

            //QuoteApi.SubscribedInstruments["S"] = new SortedSet<string>() { "IF1212;IF1211;IF1210" };
            QuoteApi.OnConnectionStatus = QuotationApi.OnConnectionStatus;
            QuoteApi.OnRtnDepthMarketData = QuotationApi.OnRtnDepthMarketData;
            QuoteApi.OnRtnError = QuotationApi.OnRtnError;
            QuoteApi.Connect();
        }

        private static void CreateTraderApi()
        {
            TradeApi = new XApi(TradeApiPath);
            TradeApi.Server.Address = "tcp://" + LoginContext.ServerInfo.Trading;
            TradeApi.User.UserID = LoginContext.UserName;
            TradeApi.User.Password = LoginContext.Password;
            TradeApi.Server.BrokerID = LoginContext.BrokerInfo.BrokerID;
            TradeApi.Server.PrivateTopicResumeType = ResumeType.Restart;
            TradeApi.Server.PublicTopicResumeType = ResumeType.Restart;

            //TradeApi.SubscribedInstruments["S"] = new SortedSet<string>() { "IF1212;IF1211;IF1210" };
            TradeApi.OnConnectionStatus = TraderApi.OnConnectionStatus;
            TradeApi.OnRspQryInvestorPosition = TraderApi.OnRspQryInvestorPosition;
            TradeApi.OnRtnError = TraderApi.OnRtnError;
            TradeApi.Connect();
        }

    }
}
