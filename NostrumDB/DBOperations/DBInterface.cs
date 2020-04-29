using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NostrumDB
{
    public interface IDBInterface
    {
        // DB connection stuffs
        string SERVER { get; }
        string DATABASE { get; }
        string USERNAME { get; }
        string PASSWORD { get; }

        void InitializeDB();
        int ExecuteNonQuery(string query);
        DataTable ExecuteQuery(string query);
        object ExecuteScalar(string query);
    }
}
