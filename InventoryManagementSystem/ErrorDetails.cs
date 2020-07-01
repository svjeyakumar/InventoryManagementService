using System;


namespace InventoryManagementSystem
{
    public class ErrorDetails
    {
        public int Statuscode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}
