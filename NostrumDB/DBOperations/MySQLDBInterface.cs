using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace NostrumDB
{
    public class MySQLDBInterface : IDBInterface
    {
        private const string _server = "localhost";
        private const string _database = "nostrumex";
        private const string _username = "root";
        private const string _password = "1234";

        private static MySqlConnection _dbConn;

        public MySqlConnection ConnectionObj
        {
            get
            {
                return _dbConn;
            }
        }
        public string DATABASE
        {
            get
            {
                return _database;
            }
        }

        public string PASSWORD
        {
            get
            {
                return _password;
            }
        }

        public string SERVER
        {
            get
            {
                return _server;
            }
        }

        public string USERNAME
        {
            get
            {
                return _username;
            }
        }

        public void InitializeDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = USERNAME;
            builder.Password = PASSWORD;
            builder.Database = DATABASE;

            string connString = builder.ToString();

            builder = null;

            Console.WriteLine(connString);

            _dbConn = new MySqlConnection(connString);
        }

        public int ExecuteNonQuery(string query)
        {
            int nRowsAffected = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, ConnectionObj);
                ConnectionObj.Open();
                nRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                ConnectionObj.Close();
            }
            return nRowsAffected;
        }
        public DataTable ExecuteQuery(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                ConnectionObj.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, ConnectionObj);
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                ConnectionObj.Close();
            }
        }

        public double ExecuteScalar(string query)
        {
            double val = 0;
            try
            {
                ConnectionObj.Open();
                MySqlCommand cmd = new MySqlCommand(query, ConnectionObj);
                object obj = cmd.ExecuteScalar();
                if(obj != null && obj != DBNull.Value)
                {
                    val = Convert.ToDouble(obj);
                }
                
                cmd.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ConnectionObj.Close();
            }
            return val;
        }
    }
}
