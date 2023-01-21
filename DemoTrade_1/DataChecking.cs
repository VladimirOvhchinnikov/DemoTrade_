using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrade_1
{
    class DataChecking
    {
        /*Проверка на отсуствия данных*/
        internal bool checkNull(string str)
        {
            if (str == "")  return true;
            else return false;
        }

        /*Понижение регистра*/
        internal string decreaseWord(string str)
        {
            return str.ToLower();
        }

        /*Проверка на отсуствия данных возварт булевого значения*/
        internal bool checkString(string str)
        {

            if (checkNull(str) == true)
            {
                return false;
            }
            else
            {
                decreaseWord(str);
                return true;
            }
        }

        internal bool maxSum(double sum, double buy) 
        {
            if (sum > buy)
            {
                return true;
            }
            return false;
        }
    }
}
