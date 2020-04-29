using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace NostrumDB
{
    public class StockDAO : IStockDAO
    {
        IDBInterface _dbInterface;
        public StockDAO(IDBInterface dbInterface)
        {
            _dbInterface = dbInterface;
            _dbInterface.InitializeDB();
        }

        public List<string> GetBatchNos(string name)
        {
            List<string> batchNos = new List<string>();
            string query = "Select Batch from stock where Product = '" + name + "' and qty > 0;";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach (DataRow dr in dataTable.Rows)
            {
                batchNos.Add(dr["Batch"].ToString());
            }

            return batchNos;
        }

        public int GetStockQuantity(string name, string batch)
        {
            int quantity = 0;
            Stock order = new Stock();
            string query = "Select Qty from stock where Product ='" + name + "' and Batch = '" + batch + "';";

            object obj = _dbInterface.ExecuteScalar(query);
            if (obj != null && obj != DBNull.Value)
                quantity = Convert.ToInt32(obj);

            return quantity;
        }
    }
}
