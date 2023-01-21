using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DemoTrade_1
{
    class Registration : LogAndReg
    {
        public new void  start()
        {
            Console.Clear();
            inputWindow();
            inputData();
        }

        private void inputWindow()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            inputConsole(25, 8, "-->> Name     -->> ");
            inputConsole(25, 9, "-->> Surname  -->> ");
            inputConsole(25, 10, "-->> Login    -->> ");
            inputConsole(25, 11, "-->> Password -->> ");

            Console.ForegroundColor = ConsoleColor.Red;

            inputConsole(25, 15, "<<<Press Enter in sign>>>");

            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private void inputData()
        {
            User user = new User();

            while (true)
            {
                /*Ввод имени*/
                user.Name = EnterUserData(44, 8);

                /*Ввод фамилии*/
                user.Surname = EnterUserData(44, 9); ;

                /*Ввод логина*/
                user.Login = EnterUserData(44, 10); ;

                /*Ввод пароля*/
                user.Password = EnterUserData(44, 11);

                /*Проверка пароля на правильность ввода*/
                bool checkLogin = DataChecking.checkString(user.Login);
                bool checkPassword = DataChecking.checkString(user.Password);

                /*Если данные введены не корректно*/
                if (checkLogin == false || checkPassword == false)
                {
                    Console.WriteLine("Data is not included. Repeat input");
                    Thread.Sleep(3000);
                    inputWindow();
                }

                /*Если данные введены корректно*/
                if (checkLogin == true && checkPassword == true)
                {
                    /*Инициализация хэш класса*/
                    user = Hash.hashingUser(user);

                    /*Инициализация скл класса*/
                    Sqlite sqlite = new Sqlite();
                    sqlite.Connection();


                    /*Проверка на наличие логина в базе данных*/
                    if (sqlite.SearchData(user.Login, "login") == true)
                    {
                        Console.WriteLine("User already registerd");
                        Thread.Sleep(3000);
                        inputWindow();
                    }
                    else
                    {
                        sqlite.AddUser(user);
                        Console.WriteLine("Registration completed");
                        Thread.Sleep(3000);
                        sqlite.addNewCashNewUser(user);
                        Sign sign = new Sign();
                        sign.start();
                    }
                    sqlite.CloseConnection();

                }
            }
        }
    }
}
