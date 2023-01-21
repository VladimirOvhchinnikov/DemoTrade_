using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DemoTrade_1
{
    class Sqlite
    {
        SQLiteConnection connection;
        SQLiteCommand command;


        /*Коннет к базе данных*/
        public SQLiteConnection Connection()
        {
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=usersql.db.;Version=3; FailIfMissing=False");
            connection.Open();

            return connection;
        }

        /*Закрытие коннекта*/
        public void CloseConnection()
        {
            connection.Close();
        }

        /*Поиск в базе данных по названию колонки и данным колонки*/
        public bool SearchData(string desired, string column)
        {
            connection = Connection();
            command = new SQLiteCommand(connection);
            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "SELECT * FROM user WHERE " + column + " LIKE '" + desired + "'";
            SQLiteDataReader reader = command.ExecuteReader();
            bool returnbool = reader.HasRows;
            reader.Close();
            CloseConnection();
            return returnbool;
        }

        /*Добавление юзеров в базу данный*/
        public void AddUser(User user)
        {
            SQLiteConnection connection = Connection();
            SQLiteCommand command = new SQLiteCommand(connection)
            {
                CommandText = @"INSERT INTO user(name, surname, login, password) VALUES('" + user.Name + @"', '" + user.Surname + @"', '" + user.Login + @"', '" + user.Password + @"')"
            };
            command.ExecuteNonQuery();
           // CloseConnection();
        }

        /*Поиск id пользователя по данным логина*/
        public int searchIdUser(string desired, string column)
        {
            object id = null;
            connection = Connection();
            command = new SQLiteCommand(connection)
            {
                CommandType = System.Data.CommandType.Text,

                CommandText = "SELECT * FROM user WHERE " + column + " LIKE '" + desired + "'"
            };
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                id = reader["id"];
               
            }
            reader.Close();
            CloseConnection();
            return Convert.ToInt32(id);
        }

        /*Добавление баланса новым пользователям*/
        public void addNewCashNewUser(User user) 
        {
            int iduser = searchIdUser(user.Login, "login");


            connection = Connection();
            command = new SQLiteCommand(connection);
            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "INSERT INTO cash (id_user,BTC,ETC,ZIL,ETH,USDT) VALUES ("+iduser+",0,0,0,0,10001)";
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Close();
            CloseConnection();
        }

        /*Вывод баланса пользователя из базы данных*/
        public double[] inputBalanceUser(User user)
        {
            int id = searchIdUser(user.Login, "login");
            double[] result = new double[5];


            connection = Connection();
            command = new SQLiteCommand(connection);
            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "SELECT * FROM cash WHERE id_user="+id;
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result[0] = (double)reader["BTC"];
                result[1] = (double)reader["ETC"];
                result[2] = (double)reader["ZIL"];
                result[3] = (double)reader["ETH"];
                result[4] = (double)reader["USDT"];
            }
            reader.Close();
            CloseConnection();
            return result;
        }


        /*Получние баланса по одному символу*/
        public double inputBalanceUserOneTicker(User user, string ticker)
        {
            int id = searchIdUser(user.Login, "login");
            double result = 0;

            Dictionary<string, double> resultDict = new Dictionary<string, double>();

            connection = Connection();
            command = new SQLiteCommand(connection);
            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "SELECT * FROM cash WHERE id_user=" + id;
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                resultDict.Add("BTC", (double)reader["BTC"]);
                resultDict.Add("ETC", (double)reader["ETC"]);
                resultDict.Add("ZIL", (double)reader["ZIL"]);
                resultDict.Add("ETH", (double)reader["ETH"]);
                resultDict.Add("USDT", (double)reader["USDT"]);

            }
            reader.Close();
            CloseConnection();
            return resultDict[ticker];
        }
        
        public void newBalance(string symbol, User user, string sum)
        {
            connection.Close();
            int id = searchIdUser(user.Login, "login");
            sum = sum.Replace(',', '.');
            connection.Open();
            SQLiteCommand command1 = new SQLiteCommand(connection)
            {
                CommandType = System.Data.CommandType.Text,

                CommandText = "UPDATE cash SET " + symbol + "=" + sum + " WHERE id_user = " + id
            };
            command1.ExecuteNonQuery();
            connection.Close();
        }
    }
}
