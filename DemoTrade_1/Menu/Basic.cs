using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DemoTrade_1.Menu
{
    class Basic : LogAndReg
    {
        User user = new User();

        public Basic(User user) 
        {
            this.user = user;
        }

        public void inputWindow()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            inputConsole(2, 1, "-->> BTC/USDT Q  |");
            inputConsole(2, 2, "                 |");
            inputConsole(2, 3, "-->> ETC/USDT W  |");
            inputConsole(2, 4, "                 |");
            inputConsole(2, 5, "-->> ZIL/USDT E  |");
            inputConsole(2, 6, "                 |");
            inputConsole(2, 7, "-->> ETH/USDT R  |");
            inputConsole(2, 8, "                 |");
            inputConsole(2, 9, "-->> USDT     T  |");


            inputConsole(25, 1, "-->> Balance BTC == ");
            inputConsole(25, 2, "                    ");
            inputConsole(25, 3, "-->> Balance ETC == ");
            inputConsole(25, 4, "                    ");
            inputConsole(25, 5, "-->> Balance ZIL == ");
            inputConsole(25, 6, "                    ");
            inputConsole(25, 7, "-->> Balance ETH == ");
            inputConsole(25, 8, "                    ");
            inputConsole(25, 9, "-->> Balance USD == ");

            inputConsole(70, 7, "Buy  B");
            inputConsole(70, 8, "******");
            inputConsole(70, 9, "Sell S");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        /*Вывод котировок монет*/
        private void inputSymbolInformation(string symbol) 
        {
            Binance binance = new Binance();
            Parsing parsing = new Parsing();
            string Price = binance.WebRequestPrice(symbol);
            inputConsole(70, 1, "Price "+ symbol + " -> ");
            inputConsole(84, 1, parsing.parsPrice(Price));
        }
        
        public void singInformation()
        {

        }

        public void MoveMenu()
        {
            Sqlite sqlite = new Sqlite();
            string symbol = "";
            while (true)
            {
                
                if(characterDefinition() == ConsoleKey.Q)
                {
                    inputSymbolInformation("BTCUSDT");
                    symbol = "BTC";
                }
                if (characterDefinition() == ConsoleKey.W)
                {
                    inputSymbolInformation("ETCUSDT");
                    symbol = "ETC";
                }
                if (characterDefinition() == ConsoleKey.E)
                {
                    inputSymbolInformation("ZILUSDT");
                    symbol = "ZIL";
                }
                if (characterDefinition() == ConsoleKey.R)
                {
                    inputSymbolInformation("ETHUSDT");
                    symbol = "ETH";
                }
                if (characterDefinition() == ConsoleKey.T)
                {
                    inputSymbolInformation("USDTRUB");
                    symbol = "USDT";
                }
                if (characterDefinition() == ConsoleKey.Y )
                {

                    sqlite.inputBalanceUser(user);
                    double[] cash = sqlite.inputBalanceUser(user);

                    inputConsole(46, 1, cash[0].ToString());
                    inputConsole(46, 3, cash[1].ToString());
                    inputConsole(46, 5, cash[2].ToString());
                    inputConsole(46, 7, cash[3].ToString());
                    inputConsole(46, 9, cash[4].ToString());
                }
                if(characterDefinition() == ConsoleKey.B)
                {
                    DataChecking dataChecking = new DataChecking();

                    inputConsole(78, 7, symbol);
                    inputConsole(70, 8, "sum-->>");
                    Console.SetCursorPosition(78, 8);
                    string sumBuy = "";

                    while (true)
                    {
                        Console.SetCursorPosition(78, 8);
                        sumBuy = Console.ReadLine();

                        BuyAndSell buyAndSell = new BuyAndSell();

                        if (dataChecking.checkNull(sumBuy)  == true)
                        {
                            inputConsole(70, 15, "Error input null");
                        } else
                        {
                            buyAndSell.buy(user,Convert.ToDouble(sumBuy), symbol);
                            inputConsole(78, 8, "                   ");
                            break;
                        }
                    }
                }
                if (characterDefinition() == ConsoleKey.S)
                {
                    DataChecking dataChecking = new DataChecking();

                    inputConsole(78, 7, symbol);
                    inputConsole(70, 8, "sum-->>");
                    Console.SetCursorPosition(78, 8);
                    string sumSell = "";

                    while (true)
                    {
                        Console.SetCursorPosition(78, 8);
                        sumSell = Console.ReadLine();

                        BuyAndSell buyAndSell = new BuyAndSell();

                        if (dataChecking.checkNull(sumSell) == true)
                        {
                            inputConsole(70, 15, "Error input null");
                        }
                        else
                        {
                            buyAndSell.sell(user, Convert.ToDouble(sumSell), symbol);
                            inputConsole(78, 8, "                   ");
                            break;
                        }
                    }
                }
            }
        }
    }
}
