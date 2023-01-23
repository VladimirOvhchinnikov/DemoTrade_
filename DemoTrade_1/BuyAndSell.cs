using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrade_1
{
    class BuyAndSell
    {
        public void Buy(User user, double sum, string symbol)
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
            string price = (parsing.getParsePrice(binance.WebRequestPrice(symbol+"USDT")));

            //смена для базы данных
            price = price.Replace('.', ',');

            //Новый баланс криптовалюты
            double newbalanceSymbol = balanceSymbol + sum / double.Parse(price);

            //Новый баланс Символа в строковом формате 
            string newbalanceSymbolstring = newbalanceSymbol.ToString().Replace(',', '.');

            //Новый баланс USDT в строковом формате 
            string newbalanceUsdtstring = newbalanceUsdt.ToString().Replace(',', '.');

            //Запись новых данных в базу данных
            sqlite.newBalance("USDT", user, newbalanceUsdtstring);
            sqlite.newBalance(symbol, user, newbalanceSymbolstring);
        }
        public void Sell(User user, double sum, string symbol)
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
            string price = (parsing.getParsePrice(binance.WebRequestPrice(symbol + "USDT")));
            price = price.Replace('.', ',');
            //доллары от продажи
            double sellSymbol = sum * Convert.ToDouble(price);

            //Новый баланс USDT с прибавкой проданного символа
            balanceUSDT = balanceUSDT + sellSymbol;

            //Новый баланс символа полсе вычета проданного
            balanceSymbol = balanceSymbol - sum;

            //Запись новых данных в базу данных
            sqlite.newBalance("USDT", user, Convert.ToString(balanceUSDT));
            sqlite.newBalance(symbol, user, Convert.ToString(balanceSymbol));
        }
    }
}
