﻿using QuantBox;
using QuantBox.XAPI;
using QuantBox.XAPI.Callback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TradeMagician.Api
{
    class QuotationApi
    {
        public static void OnConnectionStatus(object sender, ConnectionStatus status, ref RspUserLoginField userLogin, int size1)
        {
            XApi api = sender as XApi;

            if (status == ConnectionStatus.Initialized)
            {
                
            }
        }

        public static void OnRtnDepthMarketData(object sender, ref DepthMarketDataField marketData)
        {
            
        }

        public static void OnRtnError(object sender, [In] ref ErrorField error)
        {


        }
    }
}