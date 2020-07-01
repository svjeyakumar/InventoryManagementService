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
