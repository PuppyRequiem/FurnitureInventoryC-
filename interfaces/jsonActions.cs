using FurnitureWebApi.Controllers;
using FurnitureWebApi.Models;
using Newtonsoft.Json;

public class JsonActions
{
    private readonly HttpClient _client;

    public JsonActions(HttpClient client)
    {
        _client = client;
    }

    public async Task DisplayJSONData()
    {
        try
        {
            Console.WriteLine("Fetching data...");

            var response = await _client.GetAsync("/api/items");
            response.EnsureSuccessStatusCode();
            var items = await response.Content.ReadFromJsonAsync<List<UserInventory>>();

            foreach (var user in items)
            {
                Console.WriteLine($"User ID: {user.UserId}, Username: {user.Username}");
                Console.WriteLine("Inventory:");
                foreach (var item in user.Inventory)
                {
                    Console.WriteLine("====================================\n");
                    Console.WriteLine($"ID\t:\t{item.Id}");
                    Console.WriteLine($"PRODUCT\t:\t{item.Product}");
                    Console.WriteLine($"TYPE\t:\t{item.Type}");
                    Console.WriteLine($"AMOUNT\t:\t{item.Amount}");
                    Console.WriteLine($"GROUP\t:\t{item.Group}\n");
                }
                Console.WriteLine("====================================");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
    }

    public async Task DisplayUserInventory(int userId)
    {
        try
        {
            Console.WriteLine($"\n\t\t\t\t\t\tFetching inventory for user ID: {userId}...");

            var response = await _client.GetAsync($"/api/items/user/{userId}");
            response.EnsureSuccessStatusCode();
            var items = await response.Content.ReadFromJsonAsync<List<Data>>();

            if (items != null && items.Count > 0)
            {
                Console.WriteLine($"\t\t\t\t\t\tInventory for User ID {userId}:");
                foreach (var item in items)
                {
                    Console.WriteLine("\t\t\t\t\t\t====================================\n");
                    Console.WriteLine($"\t\t\t\t\t\tID\t:\t{item.Id}");
                    Console.WriteLine($"\t\t\t\t\t\tPRODUCT\t:\t{item.Product}");
                    Console.WriteLine($"\t\t\t\t\t\tTYPE\t:\t{item.Type}");
                    Console.WriteLine($"\t\t\t\t\t\tAMOUNT\t:\t{item.Amount}");
                    Console.WriteLine($"\t\t\t\t\t\tGROUP\t:\t{item.Group}\n");
                }
                Console.WriteLine("\t\t\t\t\t\t====================================");
            }
            else
            {
                Console.WriteLine($"\t\t\t\t\t\tUser ID {userId} has no items in inventory.");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
    }

    public async Task AddJSONData(int userID, int Id, string product, string type, int amount, string group)
    {
        try
        {
            string jsonFilePath = Path.Combine("Data", "data.json");

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("User data file not found. Creating a new one...");
                File.WriteAllText(jsonFilePath, "[]");
            }

            var jsonData = File.ReadAllText(jsonFilePath);
            var users = JsonConvert.DeserializeObject<List<UserInventory>>(jsonData) ?? new List<UserInventory>();

            var user = users.FirstOrDefault(u => u.UserId == userID);

            if (user == null)
            {
                user = new UserInventory
                {
                    UserId = userID,
                    Inventory = new List<Data>()
                };
                users.Add(user);
            }

            // Calculate the next item ID
            int newId = GetNextItemId(users);

            var newItem = new Data
            {
                Id = newId,
                Product = product,
                Type = type,
                Amount = amount,
                Group = group
            };

            user.Inventory.Add(newItem);

            var updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(jsonFilePath, updatedJson);

            Console.WriteLine($"\t\t\t\t\t\tItem added successfully with ID: {newId} to User ID: {userID}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error adding data: {e.Message}");
        }
    }

    private int GetNextItemId(List<UserInventory> users)
    {
        // Find the maximum item ID across all users
        int maxId = users.SelectMany(u => u.Inventory).Max(i => i.Id);

        // Increment the maximum ID to get the next available ID
        return maxId + 1;
    }


    public async Task UpdateJSONData(int userID, int itemId, Data updatedItem)
    {
        try
        {
            string jsonFilePath = Path.Combine("Data", "data.json");

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("User data file not found.");
                return;
            }

            var jsonData = await File.ReadAllTextAsync(jsonFilePath);
            var users = JsonConvert.DeserializeObject<List<UserInventory>>(jsonData) ?? new List<UserInventory>();
            
            var user = users.FirstOrDefault(u => u.UserId == userID);
            
            var itemToUpdate = user.Inventory.FirstOrDefault(item => item.Id == itemId);

            if (itemToUpdate == null)
            {
                Console.WriteLine($"\t\t\t\t\t\tItem with ID {itemId} not found in User ID {userID}'s inventory.");
                return;
            }

            if (user == null || user.Inventory == null)
            {
                Console.WriteLine($"User ID {userID} or inventory not found.");
                return;
            }

            // Update item details if the provided updatedItem fields are not null or empty
            if (!string.IsNullOrEmpty(updatedItem.Product))
            {
                itemToUpdate.Product = updatedItem.Product;
            }
            if (!string.IsNullOrEmpty(updatedItem.Type))
            {
                itemToUpdate.Type = updatedItem.Type;
            }
            if (updatedItem.Amount.HasValue)
            {
                itemToUpdate.Amount = updatedItem.Amount.Value;
            }
            if (!string.IsNullOrEmpty(updatedItem.Group))
            {
                itemToUpdate.Group = updatedItem.Group;
            }

            // Save changes to file
            var updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            await File.WriteAllTextAsync(jsonFilePath, updatedJson);

            Console.WriteLine($"Item with ID {itemId} updated successfully for User ID {userID}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error updating item: {e.Message}");
        }
    }

    public async Task DeleteJSONData(int userID, int itemId)
    {
        try
        {
            string jsonFilePath = Path.Combine("Data", "data.json");

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("User data file not found.");
                return;
            }

            var jsonData = File.ReadAllText(jsonFilePath);
            var users = JsonConvert.DeserializeObject<List<UserInventory>>(jsonData) ?? new List<UserInventory>();

            var user = users.FirstOrDefault(u => u.UserId == userID);

            if (user == null || user.Inventory == null)
            {
                Console.WriteLine($"\t\t\t\t\t\tUser ID {userID} or inventory not found.");
                return;
            }

            var itemToDelete = user.Inventory.FirstOrDefault(item => item.Id == itemId);

            if (itemToDelete == null)
            {
                Console.WriteLine($"\t\t\t\t\t\tItem with ID {itemId} not found in User ID {userID}'s inventory.");
                return;
            }

            // Remove item from inventory
            user.Inventory.Remove(itemToDelete);

            // Save changes to file
            var updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(jsonFilePath, updatedJson);

            Console.WriteLine($"\t\t\t\t\t\tItem with ID {itemId} deleted successfully for User ID {userID}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\t\t\t\t\t\tError deleting item: {e.Message}");
        }
    }

    public async Task<UserInventory> GetUserInventory(int userId)
    {
        try
        {
            var response = await _client.GetAsync($"/api/items/user/{userId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserInventory>();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
    }

    public async Task UpdateUserInventory(int userId, UserInventory updatedUserInventory)
    {
        try
        {
            var response = await _client.PutAsJsonAsync($"/api/items/user/{userId}", updatedUserInventory);
            response.EnsureSuccessStatusCode();
            Console.WriteLine($"User inventory updated successfully for User ID: {userId}");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
    }

    public async Task SearchJSONDATA(string argument, string searchTerm)
    {
        try
        {
            var response = await _client.GetAsync($"/api/items/search?argument={argument}&searchTerm={searchTerm}");
            response.EnsureSuccessStatusCode();
            var items = await response.Content.ReadFromJsonAsync<List<Data>>();

            if (items != null && items.Count > 0)
            {
                Console.WriteLine($"\t\t\t\t\t\tSearch results for {argument} = {searchTerm}:");
                foreach (var item in items)
                {
                    Console.WriteLine("\t\t\t\t\t\t====================================\n");
                    Console.WriteLine($"\t\t\t\t\t\tID\t:\t{item.Id}");
                    Console.WriteLine($"\t\t\t\t\t\tPRODUCT\t:\t{item.Product}");
                    Console.WriteLine($"\t\t\t\t\t\tTYPE\t:\t{item.Type}");
                    Console.WriteLine($"\t\t\t\t\t\tAMOUNT\t:\t{item.Amount}");
                    Console.WriteLine($"\t\t\t\t\t\tGROUP\t:\t{item.Group}\n");
                }
                Console.WriteLine("\t\t\t\t\t\t====================================");
            }
            else
            {
                Console.WriteLine($"\t\t\t\t\t\tNo items found for {argument} = {searchTerm}");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
    }

}
