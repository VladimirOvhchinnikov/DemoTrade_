using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace DemoTrade_1
{
    class SQL_NEW
    {
        //Закртытый атрибут
        private SQLiteConnection connection;
        private SQLiteCommand command;

        private const string selectFrom = "SELECT * FROM";
        private const string where = "WHERE";
        private const string like = "LIKE";
        private const string insertInto = "INSERT INTO";

        //Закрытая риализация
        private static SQLiteConnection Connection()
        {
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=usersql.db.;Version=3; FailIfMissing=False");
            connection.Open();

            return connection;
        }

        private  void CloseConnection()
        {
            connection.Close(); 
        }

        /*Поиск в базе данных по названию колонки и данным колонки*/
        private bool SearchData(string desired, string column, string table)
        {
            connection = Connection();
            command = new SQLiteCommand(connection);

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =  selectFrom + table+ where + column +  like+"'" + desired + "'";

            SQLiteDataReader reader = command.ExecuteReader();
            bool returnbool = reader.HasRows;

            reader.Close();
            CloseConnection();

            return returnbool;
        }

        private void AddUser(User user, string table)
        {
            connection = Connection();
            command = new SQLiteCommand(connection)
            {
                CommandText = insertInto+table+"(name, surname, login, password) VALUES('" + user.Name + @"', '" + user.Surname + @"', '" + user.Login + @"', '" + user.Password + @"')"
            };
            command.ExecuteNonQuery();
            CloseConnection();
        }

        private int searchIdUser(string desired, string column)
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

        public void setNewUser(User user, string table)
        {
           AddUser(user, table);
        }
        public bool getSearchData(string desired, string column,string table)
        {
            return SearchData(desired, column, table);
        }
    }
}
