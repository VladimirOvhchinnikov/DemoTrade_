using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrade_1
{
    class Parsing
    {
        //Закрытые атрибуты
        private string[] arrPriceNoClear = new string[2];
        private string[] arrPriceClear = new string[2];

        //Закрытая реализация
        private string parsePrice(string price)
        {
            /*{"symbol":"BTCUSDT","price":"17265.19000000"}*/

            arrPriceNoClear = price.Split(':');
            arrPriceClear = arrPriceNoClear[2].Split('"');

            return arrPriceClear[1];
        }

        //Открытый интерфейс
        public string getParsePrice(string price)
        {
            return parsePrice(price);
        }
    }
}
