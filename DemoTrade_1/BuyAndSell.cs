using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrade_1
{
    class BuyAndSell
    {

        public void buy(User user, double sum, string symbol)
        {
            //Подключение классов
            Sqlite sqlite = new Sqlite();
            Binance binance = new Binance();
            Parsing parsing = new Parsing();

            //баланс usdt
            double balanceUSDT = sqlite.inputBalanceUserOneTicker(user, "USDT");

            //Баланс криптовалюты
            double balanceSymbol = sqlite.inputBalanceUserOneTicker(user, symbol);

            //Новый баланс после вычета суммы
            double newbalanceUsdt = balanceUSDT - sum;

           // Цена криптовалюты  в данный момент
            string price = (parsing.parsPrice(binance.WebRequestPrice(symbol+"USDT")));

            //смена для базы данных
            price = price.Replace('.', ',');

            //Новый баланс криптовалюты
            double newbalanceSymbol = balanceSymbol + sum / double.Parse(price);

            string newbalanceSymbolstring = newbalanceSymbol.ToString().Replace(',', '.');
            string newbalanceUsdtstring = newbalanceUsdt.ToString().Replace(',', '.');
            sqlite.newBalance("USDT", user, newbalanceUsdtstring);
            sqlite.newBalance(symbol, user, newbalanceSymbolstring);
        }

        public void sell(User user, double sum, string symbol)
        {
            //Подключение классов
            Sqlite sqlite = new Sqlite();
            Binance binance = new Binance();
            Parsing parsing = new Parsing();

            //баланс usdt
            double balanceUSDT = sqlite.inputBalanceUserOneTicker(user, "USDT");

            //Баланс криптовалюты
            double balanceSymbol = sqlite.inputBalanceUserOneTicker(user, symbol);
           
            // Цена криптовалюты  в данный момент
            string price = (parsing.parsPrice(binance.WebRequestPrice(symbol + "USDT")));
            price = price.Replace('.', ',');
            //доллары от продажи
            double sellSymbol = sum * Convert.ToDouble(price);

            

            balanceUSDT = balanceUSDT + sellSymbol;

            balanceSymbol = balanceSymbol - sum;

            sqlite.newBalance("USDT", user, Convert.ToString(balanceUSDT));
            sqlite.newBalance(symbol, user, Convert.ToString(balanceSymbol));
        }
    }
}
