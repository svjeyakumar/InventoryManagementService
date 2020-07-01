using System;

namespace InventoryManagementSystem.Authentication.Interface
{
    public interface IAuthIms
    {
        string Authenticate(string name, string password);
    }
}
