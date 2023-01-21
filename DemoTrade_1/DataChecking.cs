using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrade_1
{
    static class DataChecking
    {
        /*Проверка на отсуствия данных*/
        static internal bool checkNull(string str)
        {
            if (str == "")  return true;
            else return false;
        }

        /*Понижение регистра*/
        static internal string decreaseWord(string str)
        {
            return str.ToLower();
        }

        /*Проверка на отсуствия данных возварт булевого значения*/
        static internal bool checkString(string str)
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

        /*Проверка на максимальное значение суммы*/
        static internal bool maxSum(double sum, double buy) 
        {
            if (sum > buy)
            {
                return true;
            }
            return false;
        }
    }
}
