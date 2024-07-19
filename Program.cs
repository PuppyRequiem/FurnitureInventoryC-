using Newtonsoft.Json;
using FurnitureWebApi.Models;
public static class GlobalVariables
{
    public static int UserID { get; set; }
    public static bool IsAdmin { get; set; }
}

class Program
{
    private static JsonActions jsonActions;

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var client = new HttpClient { BaseAddress = new Uri("http://localhost:5107") };

        jsonActions = new JsonActions(client); // Initialize JsonActions

        bool loggedIn = false;
        var webHostTask = host.RunAsync(); // Run the web host in a separate task

        // Wait for the web host to start
        await Task.Delay(1000); // Adjust delay as needed

        while (true)
        {
            if (!loggedIn)
            {
                Console.WriteLine("Do you want to sign up or login?\n1.) Sign Up\n2.) Login\n3.) Exit");
                Console.Write("#> ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (SignUp())
                        {
                            loggedIn = true;
                            GlobalVariables.UserID = GetLastUserId();
                        }
                        break;
                    case "2":
                        loggedIn = Login();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            if (loggedIn)
            {
                int uid = GlobalVariables.UserID; // Set uid after login
                bool isAdmin = GlobalVariables.IsAdmin; // Set isAdmin after login

                while (loggedIn)
                {
                    Console.WriteLine($"Welcome User: {uid}");
                    Console.WriteLine("Choose an Action");
                    Console.WriteLine("1.) Display");
                    Console.WriteLine("2.) Add Items");
                    Console.WriteLine("3.) Update Item");
                    Console.WriteLine("4.) Delete Item");
                    Console.WriteLine("5.) Search Item");
                    Console.WriteLine("6.) Logout");
                    Console.Write("#> ");
                    var choice = Console.ReadLine();

                    try
                    {
                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("1.) Display All Inventory (Are you Admin?)\n2.) Display My Inventory");
                                Console.Write("#> ");
                                var displayChoice = Console.ReadLine();
                                switch (displayChoice)
                                {
                                    case "1":
                                        if (isAdmin)
                                            await jsonActions.DisplayJSONData();
                                        else
                                            Console.WriteLine("You are not an Admin!");
                                        break;
                                    case "2":
                                        await jsonActions.DisplayUserInventory(uid);
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice.");
                                        break;
                                }
                                break;

                            case "2":
                                Console.WriteLine("Enter the following item details you wish to add:");

                                Console.Write("Enter Product: ");
                                var product = Console.ReadLine();

                                Console.Write("Enter Type: ");
                                var type = Console.ReadLine();

                                Console.Write("Enter Amount: ");
                                var amount = int.Parse(Console.ReadLine());

                                Console.Write("Enter Group: ");
                                var group = Console.ReadLine();

                                int newId = await GetNextItemId();

                                await jsonActions.AddJSONData(uid, newId, product, type, amount, group);
                                break;

                            case "3":
                                Console.WriteLine("Enter ID of item to update:");
                                var updateId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter new Product:");
                                Console.WriteLine("Leave Blank To Retain...");
                                var updateProduct = Console.ReadLine();

                                Console.WriteLine("Enter new Type:");
                                Console.WriteLine("Leave Blank To Retain...");
                                var updateType = Console.ReadLine();

                                Console.WriteLine("Enter new Amount:");
                                Console.WriteLine("Leave Blank To Retain...");
                                var updateAmountInput = Console.ReadLine();
                                decimal? updateAmount = null;
                                if (!string.IsNullOrWhiteSpace(updateAmountInput))
                                {
                                    if (decimal.TryParse(updateAmountInput, out var parsedAmount))
                                    {
                                        updateAmount = parsedAmount;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid amount entered. Please enter a valid number.");
                                        break;
                                    }
                                }

                                Console.WriteLine("Enter new Group:");
                                Console.WriteLine("Leave Blank To Retain...");
                                var updateGroup = Console.ReadLine();

                                var updatedItem = new Data
                                {
                                    Id = updateId,
                                    Product = updateProduct,
                                    Type = updateType,
                                    Amount = updateAmount,
                                    Group = updateGroup
                                };

                                await jsonActions.UpdateJSONData(uid, updateId, updatedItem);
                                break;


                            case "4":
                                Console.WriteLine("Enter ID of item to delete:");
                                var deleteIdStr = Console.ReadLine();
                                if (int.TryParse(deleteIdStr, out int deleteId))
                                {
                                    await jsonActions.DeleteJSONData(uid, deleteId);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID format. Please enter a valid integer ID.");
                                }
                                break;

                            case "5":
                                Console.WriteLine("*Note: use their numeric identifiers.\nSearch Items by their: ");
                                Console.WriteLine("1.) ID");
                                Console.WriteLine("2.) Product Name");
                                Console.WriteLine("3.) Type");
                                Console.WriteLine("4.) Group");
                                Console.WriteLine("5.) Amount (less than or Greater than)");
                                var searchPreference = Console.ReadLine();
                                string argument = "";
                                string searchTerm = "";
                                switch (searchPreference)
                                {
                                    case "1":
                                        argument = "id";
                                        Console.WriteLine("Enter an ID to search for: ");
                                        searchTerm = Console.ReadLine();
                                        break;
                                    case "2":
                                        argument = "product";
                                        Console.WriteLine("Enter a product to search for: ");
                                        searchTerm = Console.ReadLine();
                                        break;
                                    case "3":
                                        argument = "type";
                                        Console.WriteLine("Enter a type to search for: ");
                                        searchTerm = Console.ReadLine();
                                        break;
                                    case "4":
                                        argument = "group";
                                        Console.WriteLine("Enter a group to search for: ");
                                        searchTerm = Console.ReadLine();
                                        break;
                                    case "5":
                                        argument = "amount";
                                        Console.WriteLine("Enter an amount to search for: ");
                                        searchTerm = Console.ReadLine();
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Choice.");
                                        break;
                                }
                                if (!string.IsNullOrEmpty(argument) && !string.IsNullOrEmpty(searchTerm))
                                {
                                    await jsonActions.SearchJSONDATA(argument, searchTerm);
                                }
                                break;

                            case "6":
                                Console.WriteLine("Logging out...");
                                loggedIn = false;
                                break;

                            default:
                                Console.WriteLine("Invalid choice, please try again.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
        }
    }

    static bool Login()
    {
        string jsonFilePath = Path.Combine("Data", "data.json");

        if (!File.Exists(jsonFilePath))
        {
            Console.WriteLine("User data file not found.");
            return false;
        }

        var users = JsonConvert.DeserializeObject<List<UserInventory>>(File.ReadAllText(jsonFilePath));

        Console.WriteLine("Please login to access the system:");

        Console.Write("Username: ");
        var username = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            GlobalVariables.UserID = user.UserId;
            GlobalVariables.IsAdmin = user.UserId == 3; // Assuming user with ID 3 is Admin

            Console.WriteLine("Login successful!");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
            return false;
        }
    }

    static bool SignUp()
    {
        string jsonFilePath = Path.Combine("Data", "data.json");

        if (!File.Exists(jsonFilePath))
        {
            Console.WriteLine("User data file not found. Creating a new one...");
            File.WriteAllText(jsonFilePath, "[]");
        }

        var users = JsonConvert.DeserializeObject<List<UserInventory>>(File.ReadAllText(jsonFilePath));

        Console.WriteLine("Please enter the following details to sign up:");

        Console.Write("Username: ");
        var username = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        var existingUser = users.FirstOrDefault(u => u.Username == username);
        if (existingUser != null)
        {
            Console.WriteLine("Username already exists. Please choose a different username.");
            return false;
        }

        var newUser = new UserInventory
        {
            UserId = users.Count > 0 ? users.Max(u => u.UserId) + 1 : 1, // Auto-increment UserId
            Username = username,
            Password = password,
            Inventory = new List<Data>()
        };

        users.Add(newUser);
        File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(users, Formatting.Indented));

        Console.WriteLine("Sign-up successful! You can now log in with your new account.");
        return true;
    }

    static int GetLastUserId()
    {
        string jsonFilePath = Path.Combine("Data", "data.json");

        if (!File.Exists(jsonFilePath))
        {
            return 0; // No users yet
        }

        var users = JsonConvert.DeserializeObject<List<UserInventory>>(File.ReadAllText(jsonFilePath));
        return users.Any() ? users.Max(u => u.UserId) : 0;
    }

    static async Task<int> GetNextItemId()
    {
        string jsonFilePath = Path.Combine("Data", "data.json");

        if (!File.Exists(jsonFilePath))
        {
            return 1; // Start with ID 1 if no items exist yet
        }

        var users = JsonConvert.DeserializeObject<List<UserInventory>>(File.ReadAllText(jsonFilePath));
        var allItems = users.SelectMany(u => u.Inventory);

        // Calculate the next item ID
        int nextId = allItems.Any() ? allItems.Max(i => i.Id) + 1 : 1;

        return nextId;
    }
}
