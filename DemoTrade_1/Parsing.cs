using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrade_1
{
    class Parsing
    {

        public string parsPrice(string price) 
        {
            /*{"symbol":"BTCUSDT","price":"17265.19000000"}*/

            string[] arr_1 = new string[2];
            string[] arr_2 = new string[2];
            arr_1 = price.Split(':');
            arr_2 = arr_1[2].Split('"');

            return arr_2[1];
        }
    }
}
