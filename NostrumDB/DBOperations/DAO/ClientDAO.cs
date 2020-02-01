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

        public bool addClient(Client client)
        {
            int nRowsAffected = 0;
            string query = "Insert into clients values('"+client.Name+"','" + client.Phone + "','" + client.Display_Name + "','" + client.Addr1 + "','" + client.Addr2 + "','" + client.Addr3 + "','" + client.TIN_No + "','" + client.DL_No + "');";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool deleteClient(string displayName)
        {
            int nRowsAffected = 0;
            string query = "Delete from clients where Display_Name = '"+displayName+"'";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public Client getClient(string displayName)
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
                client.Addr1 = reader["Addr1"].ToString();
                client.Addr2 = reader["Addr2"].ToString();
                client.Addr3 = reader["Addr3"].ToString();
                client.TIN_No = reader["TIN_No"].ToString();
                client.DL_No = reader["DL_No"].ToString();
            }
            else
            {
                Console.WriteLine("Get Client returns 0 rows..!");
            }
            
            return client;          
        }

        public List<string> getClients()
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
                client.Addr1 = dr["Addr1"].ToString();
                client.Addr2 = dr["Addr2"].ToString();
                client.Addr3 = dr["Addr3"].ToString();                
                client.DL_No = dr["DL_No"].ToString();
                client.Phone = dr["Phone"].ToString();
                client.TIN_No = dr["TIN_No"].ToString();
                //clientNames.Add(dr["Display_Name"].ToString());
                ClientInfoList.Add(client);
            }

            return ClientInfoList;
        }

        public bool updateClient(Client client)
        {
            int nRowsAffected = 0;
            string query = "Update clients set Name = '" + client.Name + "', Phone = '" + client.Phone + "', Addr1 = '" + client.Addr1 + "', Addr2 = '" + client.Addr2 + "', Addr3 = '" + client.Addr3 + "', TIN_No = '" + client.TIN_No + "', DL_No = '" + client.DL_No + "' where Display_Name = '" + client.Display_Name + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }
    }
}
