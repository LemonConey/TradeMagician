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
    class TraderApi
    {


        //Initialized->Connecting->Connected->Logining->Logined->Doing->Done
        public static void OnConnectionStatus(object sender, ConnectionStatus status, ref RspUserLoginField userLogin, int size1)
        {
            XApi api = sender as XApi;

            if (status == ConnectionStatus.Done)
            {
                ApiContext.TradeLoginSuccess.Set();
            }
            
        }

        public static void OnRtnError(object sender, [In] ref ErrorField error)
        {

        }
    }
}
