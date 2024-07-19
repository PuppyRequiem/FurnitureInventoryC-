namespace FurnitureWebApi.Models
{
    public class Data
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Type { get; set; }
        public int? Amount { get; set; }
        public string Group { get; set; }
    }

    public class UserInventory
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Data> Inventory { get; set; }
    }
}
