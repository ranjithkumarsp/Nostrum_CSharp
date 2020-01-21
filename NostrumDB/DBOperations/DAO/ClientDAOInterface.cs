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
        bool addClient(Client client);
        Client getClient(string displayName);
        List<string> getClients();
        bool updateClient(Client client);
        bool deleteClient(string displayName);
    }
}
