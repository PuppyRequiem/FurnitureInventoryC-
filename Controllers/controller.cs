using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FurnitureWebApi.Models;

namespace FurnitureWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly string jsonFilePath = Path.Combine("Data", "data.json");

        [HttpGet]
        public ActionResult<IEnumerable<Data>> GetAllItems()
        {
            if (System.IO.File.Exists(jsonFilePath))
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var users = JsonConvert.DeserializeObject<List<UserInventory>>(json) ?? new List<UserInventory>();
                var items = users.SelectMany(u => u.Inventory).ToList();
                return Ok(items);
            }
            return NotFound("Data file not found.");
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Data>> GetUserItems(int userId)
        {
            if (System.IO.File.Exists(jsonFilePath))
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var users = JsonConvert.DeserializeObject<List<UserInventory>>(json) ?? new List<UserInventory>();
                var user = users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    return Ok(user.Inventory);
                }
                return NotFound("User not found.");
            }
            return NotFound("Data file not found.");
        }

        [HttpPost("{userId}")]
        public ActionResult AddItem(int userId, [FromBody] Data newItem)
        {
            if (newItem == null)
            {
                return BadRequest("Invalid item data.");
            }

            if (System.IO.File.Exists(jsonFilePath))
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var users = JsonConvert.DeserializeObject<List<UserInventory>>(json) ?? new List<UserInventory>();
                var user = users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    user.Inventory.Add(newItem);
                    System.IO.File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(users, Formatting.Indented));
                    return Ok("Item added successfully.");
                }
                return NotFound("User not found.");
            }
            return NotFound("Data file not found.");
        }

        [HttpPut("{userId}/{id}")]
        public ActionResult UpdateItem(int userId, int id, [FromBody] Data updatedItem)
        {
            if (updatedItem == null)
            {
                return BadRequest("Invalid item data.");
            }

            if (System.IO.File.Exists(jsonFilePath))
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var users = JsonConvert.DeserializeObject<List<UserInventory>>(json) ?? new List<UserInventory>();
                var user = users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    var item = user.Inventory.FirstOrDefault(i => i.Id == id);
                    if (item != null)
                    {
                        item.Product = updatedItem.Product;
                        item.Type = updatedItem.Type;
                        item.Amount = updatedItem.Amount;
                        item.Group = updatedItem.Group;

                        System.IO.File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(users, Formatting.Indented));
                        return Ok("Item updated successfully.");
                    }
                    return NotFound("Item not found.");
                }
                return NotFound("User not found.");
            }
            return NotFound("Data file not found.");
        }

        [HttpDelete("{userId}/{id}")]
        public ActionResult DeleteItem(int userId, int id)
        {
            if (System.IO.File.Exists(jsonFilePath))
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var users = JsonConvert.DeserializeObject<List<UserInventory>>(json) ?? new List<UserInventory>();
                var user = users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    var item = user.Inventory.FirstOrDefault(i => i.Id == id);
                    if (item != null)
                    {
                        user.Inventory.Remove(item);
                        System.IO.File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(users, Formatting.Indented));
                        return Ok("Item deleted successfully.");
                    }
                    return NotFound("Item not found.");
                }
                return NotFound("User not found.");
            }
            return NotFound("Data file not found.");
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Data>> SearchItems([FromQuery] string argument, [FromQuery] string searchTerm)
        {
            if (System.IO.File.Exists(jsonFilePath))
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var users = JsonConvert.DeserializeObject<List<UserInventory>>(json) ?? new List<UserInventory>();
                var items = users.SelectMany(u => u.Inventory).ToList();

                if (!string.IsNullOrEmpty(argument) && !string.IsNullOrEmpty(searchTerm))
                {
                    switch (argument)
                    {
                        case "id":
                            if (int.TryParse(searchTerm, out int parsedId))
                            {
                                items = items.Where(i => i.Id == parsedId).ToList();
                            }
                            break;
                        case "product":
                            items = items.Where(i => i.Product.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                            break;
                        case "type":
                            items = items.Where(i => i.Type.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                            break;
                        case "group":
                            items = items.Where(i => i.Group.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                            break;
                        case "amount":
                            if (int.TryParse(searchTerm, out int parsedAmount))
                            {
                                items = items.Where(i => i.Amount == parsedAmount).ToList();
                            }
                            break;
                        default:
                            return BadRequest("Invalid search argument.");
                    }

                    return Ok(items);
                }
                return BadRequest("Search argument or term is missing.");
            }
            return NotFound("Data file not found.");
        }

    }
}
