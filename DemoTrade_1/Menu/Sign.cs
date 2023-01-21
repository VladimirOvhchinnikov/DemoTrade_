using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DemoTrade_1.Menu;

namespace DemoTrade_1
{
    

    class Sign : LogAndReg
    {

        public User user = new User();


        public new void start()
        {
            inputWindowSig();
            inputData();
        }


        /*Вывод статичной информации для выбора действия */
        private void inputWindowSig()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            inputConsole(25, 10, "-->> Login    -->> ");
            inputConsole(25, 11, "-->> Password -->> ");

            Console.ForegroundColor = ConsoleColor.Red;

            inputConsole(25, 15, "<<<Press S in sign>>>");

            Console.ForegroundColor = ConsoleColor.Yellow;
        }


        /*Ввод данных в консоль и их проверка*/
        private void inputData()
        {

            while (true) 
            {

                /*Ввод логина*/
                user.Login = EnterUserData(44, 10);

                /*Ввод пароля*/
                user.Password = EnterUserData(44, 11); ;

                /*Проверка пароля на правильность ввода*/
                DataChecking dataChecking = new DataChecking();
                bool checkLogin = dataChecking.checkString(user.Login);
                bool checkPassword = dataChecking.checkString(user.Password);

                /*Если данные введены не корректно*/
                if (checkLogin == false || checkPassword == false)
                {
                    Console.WriteLine("Data is not included. Repeat input");
                    Thread.Sleep(3000);
                    inputWindowSig();
                }

                /*Если данные введены корректно*/
                if (checkLogin == true && checkPassword == true)
                {
                    /*Инициализация хэш класса*/
                    Hash hash = new Hash();
                    user = hash.hashingUser(user);

                    /*Инициализация скл класса*/
                    Sqlite sqlite = new Sqlite();


                    /*Поиск логина и пароля в базе данных
                      Если логин и пароль совпадает. Вход в приложение 
                     */
                    if (sqlite.SearchData(user.Login, "login") == true && sqlite.SearchData(user.Password,"password"))
                    {
                        Basic basic = new Basic(user);
                        basic.inputWindow();
                        basic.MoveMenu();
                        break;
                        
                    }
                    else
                    /*Если нет, повторный ввод данных*/
                    {
                        Console.WriteLine("wrong login or password");
                        Thread.Sleep(3000);
                        inputWindowSig();
                    }
                    sqlite.CloseConnection();
                }
            }
        
        }

       
    }
}
