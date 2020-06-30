using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Repository.Interface
{
    public interface ILog
    {
        void LogInfo(string msg);
        void LogWarn(string msg);
        void LogDebug(string msg);
        void LogError(string msg);


    }
}
