using QuantBox;
using QuantBox.XAPI;
using QuantBox.XAPI.Callback;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TradeMagician
{
    class TestCode
    {
        static void OnConnectionStatus(object sender, ConnectionStatus status, ref RspUserLoginField userLogin, int size1)
        {
            XApi api = sender as XApi;
            Console.WriteLine(api.GetApiName + " " + api.GetApiType + " " + api.GetApiVersion + " " + status + " " + userLogin.ErrorMsg());
            if (status == ConnectionStatus.Done && api.GetApiType == (ApiType.MarketData | ApiType.Level2))
            {
                api.Subscribe("IF1212;IF1211;IF1210", "");
            }
            if (status == ConnectionStatus.Done && api.GetApiType == (ApiType.Trade | ApiType.Instrument))
            {
                //api.SendOrder(1,ref null, ref null);
            }
        }
        static void OnRtnError(object sender, [In] ref ErrorField error)
        {


        }
        static bool started = false;
        static Stopwatch watch = new Stopwatch();
        static void OnRtnDepthMarketData(object sender, ref DepthMarketDataField marketData)
        {
            if (!started)
            {
                watch.Start();
                started = true;
            }
            else
            {
                watch.Stop();
                Console.WriteLine("--------------------");
                Console.WriteLine(watch.ElapsedMilliseconds);
                Console.WriteLine("--------------------");
            }
            //Debugger.Log(0, null, "CTP:C#");
            Console.Write(marketData.InstrumentID);
            Console.Write("\t");
            Console.Write(marketData.ExchangeID);
            Console.Write("\t");
            Console.WriteLine(marketData.LastPrice);
            Console.Write("\t");
            Console.Write(marketData.HighestPrice);
            Console.Write("\t");
            Console.Write(marketData.LowestPrice);
            Console.Write("\t");
            Console.WriteLine(marketData.SettlementPrice);



        }
        public static XApi quoteApi = null;
        public static void TestQuoteApi()
        {
            quoteApi = new XApi(@"QuantBox_Femas_Quote.dll");
            quoteApi.Server.Address = "tcp://117.184.207.108:6888"; //"tcp://124.74.248.150:7230";//
            quoteApi.User.UserID = "155092"; //"jk8";//
            quoteApi.User.Password = "666666"; //"111111";//
            quoteApi.Server.BrokerID = "0001"; //"0152";//
            quoteApi.Server.TopicId = 100;
            quoteApi.Server.MarketDataTopicResumeType = ResumeType.Quick;

            //quoteApi.SubscribedInstruments["S"] = new SortedSet<string>() { "IF1212;IF1211;IF1210" };
            quoteApi.OnConnectionStatus = OnConnectionStatus;
            quoteApi.OnRtnDepthMarketData = OnRtnDepthMarketData;
            quoteApi.OnRtnError = OnRtnError;
            quoteApi.Connect();
            //Thread.Sleep(1000);
            //quoteApi.SubscribeQuote("IF1212", "");//IF1211;IF1210;44
        }

        public static XApi tradeApi = null;

        public static void TestTradeApi()
        {
            tradeApi = new XApi(@"QuantBox_Femas_Trade.dll");
            tradeApi.Server.Address = "tcp://117.184.207.108:6666"; //"tcp://124.74.248.150:7230";//
            tradeApi.User.UserID = "155092"; //"jk8";//
            tradeApi.User.Password = "666666"; //"111111";//
            tradeApi.Server.BrokerID = "0001"; //"0152";//
            //tradeApi.Server.TopicId = 100;
            //tradeApi.Server.MarketDataTopicResumeType = ResumeType.Quick;
            tradeApi.Server.PrivateTopicResumeType = ResumeType.Restart;
            tradeApi.Server.PublicTopicResumeType = ResumeType.Restart;

            //quoteApi.SubscribedInstruments["S"] = new SortedSet<string>() { "IF1212;IF1211;IF1210" };
            tradeApi.OnConnectionStatus = OnConnectionStatus;
            tradeApi.OnRtnError = OnRtnError;
            tradeApi.Connect();
        }
        /*
        static void Main(string[] args)
        {
            Console.WriteLine("计时器频率: " + Stopwatch.Frequency);
            TestQuoteApi();
            //TestTradeApi();
            Console.ReadKey();
            quoteApi.Disconnect();
            //tradeApi.Disconnect();

        }
        */
    }
}
