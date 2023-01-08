using System;

namespace DemoTrade_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 26);

            LogAndReg logAndReg = new LogAndReg();
            logAndReg.start();
        }
    }
}
