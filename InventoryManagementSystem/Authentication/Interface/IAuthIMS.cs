using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Authentication.Interface
{
    public interface IAuthIMS
    {
        string Authenticate(string name, string password);
    }
}
