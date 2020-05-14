using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Entity;

namespace NostrumDB
{
    public class ClientDAO : IClientDAO
    {
        IDBInterface _dbInterface;
        public ClientDAO(IDBInterface dbInterface)
        {
            _dbInterface = dbInterface;
            _dbInterface.InitializeDB();
        }

        public bool AddClient(Client client)
        {
            int nRowsAffected = 0;
            string query = "Insert into clients values('"+client.Name+"','" + client.Phone + "','" + client.Display_Name + "','" + client.Address + "','" + client.TIN_No + "','" + client.DL_No + "','" + client.Type + "');";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool DeleteClient(string displayName)
        {
            int nRowsAffected = 0;
            string query = "Delete from clients where Display_Name = '"+displayName+"'";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public Client GetClient(string displayName)
        {
            Client client = new Client();
            string query = "Select * from clients where Display_Name = '" + displayName + "'";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                DataRow reader = dataTable.Rows[0];
                client.Name = reader["Name"].ToString();
                client.Phone = reader["Phone"].ToString();
                client.Display_Name = reader["Display_Name"].ToString();
                client.Address = reader["Address"].ToString();
                client.TIN_No = reader["TIN_No"].ToString();
                client.DL_No = reader["DL_No"].ToString();
                client.Type = reader["Type"].ToString();
            }
            else
            {
                Console.WriteLine("Get Client returns 0 rows..!");
            }
            
            return client;          
        }

        public List<string> GetClients()
        {
            List<string> clientNames = new List<string>();
            string query = "Select Display_Name from clients;";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach(DataRow dr in dataTable.Rows)
            {
                clientNames.Add(dr["Display_Name"].ToString());
            }

            return clientNames;
        }

        public List<Client> GetClientInfo()
        {
            List<Client> ClientInfoList = new List<Client>();
            Client client = new Client();
            string query = "Select * from clients;";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach (DataRow dr in dataTable.Rows)
            {
                client.Name = dr["Name"].ToString();
                client.Display_Name = dr["Display_Name"].ToString();
                client.Address = dr["Address"].ToString();
                client.DL_No = dr["DL_No"].ToString();
                client.Phone = dr["Phone"].ToString();
                client.TIN_No = dr["TIN_No"].ToString();
                client.Type = dr["Type"].ToString();
                //clientNames.Add(dr["Display_Name"].ToString());
                ClientInfoList.Add(client);
            }

            return ClientInfoList;
        }

        public bool UpdateClient(Client client)
        {
            int nRowsAffected = 0;
            string query = "Update clients set Name = '" + client.Name + "', Phone = '" + client.Phone + "', Address = '" + client.Address + "', TIN_No = '" + client.TIN_No + "', DL_No = '" + client.DL_No + "', Type = '" + client.Type + "' where Display_Name = '" + client.Display_Name + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }
    }
}
