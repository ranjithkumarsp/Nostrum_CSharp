using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;

namespace NostrumDB
{
    interface IClientDAO
    {
        bool AddClient(Client client);
        Client GetClient(string displayName);
        List<string> GetClients();
        bool UpdateClient(Client client);
        bool DeleteClient(string displayName);
    }
}
