using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrade_1
{
    class Binance
    {
        private readonly string BinanceUrl = "https://api.binance.com";
        private readonly string BinanceApi = "/api";
        private readonly string BinanceServerVersion = "/v3";
        private readonly string BinanceTicker = "/ticker";
        private readonly string BinancePrice = "/price?";
        private readonly string BinanceSymbol = "symbol=";
        private readonly string Binance24hr = "/24hr";


        //https://api.binance.com/api/v1/ticker/24hr?


        internal string WebRequestPrice(string symbol)
        {
            WebRequest WebRequestPrice = WebRequest.Create(BinanceUrl + BinanceApi + BinanceServerVersion +
                BinanceTicker + BinancePrice + BinanceSymbol +  symbol);
            return getRequestPrice(WebRequestPrice);
        }

        internal string WebRequestProcent24hr()
        {
            WebRequest WebRequestPrice = WebRequest.Create(BinanceUrl + BinanceApi + BinanceServerVersion +
                BinanceTicker + Binance24hr);
            return getRequestPrice(WebRequestPrice);
        }

        private string getRequestPrice(WebRequest request)
        {
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sReader = new System.IO.StreamReader(stream);

            return sReader.ReadToEnd();
        }



    }
}
