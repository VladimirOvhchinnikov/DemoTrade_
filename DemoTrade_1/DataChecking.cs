using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrade_1
{
    class DataChecking
    {

        internal bool checkNull(string str)
        {
            if (str == "")  return true;
            else return false;
        }

        internal string decreaseWord(string str)
        {
            return str.ToLower();
        }

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
    }
}
