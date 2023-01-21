using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrade_1
{
    class LogAndReg
    {

        public void start()
        {
            inputWindowLR();
            movementMenu();
        }


        /*Вывод статичной информации для выбора действия */
        private void inputWindowLR()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            inputConsole(25, 10, "-->> Sign in");
            inputConsole(25, 11, "-->> Sign up");

            Console.ForegroundColor = ConsoleColor.Red;

            inputConsole(25, 15, "<<<Press I to enter>>>");
            inputConsole(25, 16, "<<<Press U to register>>>");
        }

        /*Проверка логина и пароля */
        protected string EnterUserData(int x, int y) 
        {
            Console.SetCursorPosition(x, y);
            return  Console.ReadLine();
        }

        /*Вывод  консольных данных */
        protected void inputConsole(int x, int y, string str) 
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
        }


        /*Определяет нажатую кнопку*/
        protected ConsoleKey characterDefinition()
        {    
            Console.SetCursorPosition(40, 20);
            Console.WriteLine("  ");
            return Console.ReadKey().Key;
        }

        /*Очищает консольное окно от нажатых неправильных клавиш*/
        private void consolePositionPointClear()
        {
            Console.SetCursorPosition(0, 17);
            Console.Write(" ");
        }

        /*Движение по меню входа и регистрации*/
        private void movementMenu()
        {
            while (true)
            {
                ConsoleKey key = characterDefinition();
                consolePositionPointClear();
                if (key == ConsoleKey.U)
                {
                    Registration registration = new Registration( );
                    registration.start();
                    break;
                }
                if (key == ConsoleKey.I)
                {
                    Sign sign = new Sign();
                    sign.start();
                    break;
                }   
            }
        }
    }
}
