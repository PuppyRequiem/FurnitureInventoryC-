using Newtonsoft.Json;
using FurnitureWebApi.Models;
public static class GlobalVariables
{
    public static int UserID { get; set; }
    public static bool IsAdmin { get; set; }
}

class Program
{
    public static void loadingScreen()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(@"   _______/\\\\\______        __/\\\________/\\\_        __/\\\\\\\\\\\\\\\_        _____/\\\\\\\\\____ ");
        Console.WriteLine(@"    _____/\\\///\\\____        _\/\\\_____/\\\//__        _\/\\\///////////__        ___/\\\\\\\\\\\\\__       ");
        Console.WriteLine(@"     ___/\\\/__\///\\\__        _\/\\\__/\\\//_____        _\/\\\_____________        __/\\\/////////\\\_    ");
        Thread.Sleep(500);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(@"       _______/\\\\\______        __/\\\________/\\\_        __/\\\\\\\\\\\\\\\_        _____/\\\\\\\\\____ ");
        Console.WriteLine(@"        _____/\\\///\\\____        _\/\\\_____/\\\//__        _\/\\\///////////__        ___/\\\\\\\\\\\\\__       ");
        Console.WriteLine(@"         ___/\\\/__\///\\\__        _\/\\\__/\\\//_____        _\/\\\_____________        __/\\\/////////\\\_    ");
        Console.WriteLine(@"          __/\\\______\//\\\_        _\/\\\\\\//\\\_____        _\/\\\\\\\\\\\_____        _\/\\\_______\/\\\_     ");
        Console.WriteLine(@"           _\/\\\_______\/\\\_        _\/\\\//_\//\\\____        _\/\\\///////______        _\/\\\\\\\\\\\\\\\_    ");
        Console.WriteLine(@"            _\//\\\______/\\\__        _\/\\\____\//\\\___        _\/\\\_____________        _\/\\\/////////\\\_   ");
        Thread.Sleep(500);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(@"           _______/\\\\\______        __/\\\________/\\\_        __/\\\\\\\\\\\\\\\_        _____/\\\\\\\\\____ ");
        Console.WriteLine(@"            _____/\\\///\\\____        _\/\\\_____/\\\//__        _\/\\\///////////__        ___/\\\\\\\\\\\\\__       ");
        Console.WriteLine(@"             ___/\\\/__\///\\\__        _\/\\\__/\\\//_____        _\/\\\_____________        __/\\\/////////\\\_    ");
        Console.WriteLine(@"              __/\\\______\//\\\_        _\/\\\\\\//\\\_____        _\/\\\\\\\\\\\_____        _\/\\\_______\/\\\_     ");
        Console.WriteLine(@"               _\/\\\_______\/\\\_        _\/\\\//_\//\\\____        _\/\\\///////______        _\/\\\\\\\\\\\\\\\_    ");
        Console.WriteLine(@"                _\//\\\______/\\\__        _\/\\\____\//\\\___        _\/\\\_____________        _\/\\\/////////\\\_   ");
        Console.WriteLine(@"                 __\///\\\__/\\\____        _\/\\\_____\//\\\__        _\/\\\_____________        _\/\\\_______\/\\\_  ");
        Console.WriteLine(@"                  ____\///\\\\\/_____        _\/\\\______\//\\\_        _\/\\\\\\\\\\\\\\\_        _\/\\\_______\/\\\_ ");
        Console.WriteLine(@"                   ______\/////_______        _\///________\///__        _\///////////////__        _\///________\///__");
        Thread.Sleep(500);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(@"                  ______/\\\\\______        __/\\\________/\\\_        __/\\\\\\\\\\\\\\\_        _____/\\\\\\\\\____ ");
        Console.WriteLine(@"                  _____/\\\///\\\____        _\/\\\_____/\\\//__        _\/\\\///////////__        ___/\\\\\\\\\\\\\__       ");
        Console.WriteLine(@"                   ___/\\\/__\///\\\__        _\/\\\__/\\\//_____        _\/\\\_____________        __/\\\/////////\\\_    ");
        Console.WriteLine(@"                    __/\\\______\//\\\_        _\/\\\\\\//\\\_____        _\/\\\\\\\\\\\_____        _\/\\\_______\/\\\_     ");
        Console.WriteLine(@"                     _\/\\\_______\/\\\_        _\/\\\//_\//\\\____        _\/\\\///////______        _\/\\\\\\\\\\\\\\\_    ");
        Console.WriteLine(@"                      _\//\\\______/\\\__        _\/\\\____\//\\\___        _\/\\\_____________        _\/\\\/////////\\\_   ");
        Console.WriteLine(@"                        _\///\\\__/\\\____        _\/\\\_____\//\\\__        _\/\\\_____________        _\/\\\_______\/\\\_  ");
        Console.WriteLine(@"                        ____\///\\\\\/_____        _\/\\\______\//\\\_        _\/\\\\\\\\\\\\\\\_        _\/\\\_______\/\\\_ ");
        Console.WriteLine(@"                         ______\/////_______        _\///________\///__        _\///////////////__        _\///________\///__");
        Thread.Sleep(500);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(@"                              ______/\\\\\______        __/\\\________/\\\_        __/\\\\\\\\\\\\\\\_        _____/\\\\\\\\\____ ");
        Console.WriteLine(@"                              _____/\\\///\\\____        _\/\\\_____/\\\//__        _\/\\\///////////__        ___/\\\\\\\\\\\\\__       ");
        Console.WriteLine(@"                               ___/\\\/__\///\\\__        _\/\\\__/\\\//_____        _\/\\\_____________        __/\\\/////////\\\_    ");
        Console.WriteLine(@"                                __/\\\______\//\\\_        _\/\\\\\\//\\\_____        _\/\\\\\\\\\\\_____        _\/\\\_______\/\\\_     ");
        Console.WriteLine(@"                                 _\/\\\_______\/\\\_        _\/\\\//_\//\\\____        _\/\\\///////______        _\/\\\\\\\\\\\\\\\_    ");
        Console.WriteLine(@"                                  _\//\\\______/\\\__        _\/\\\____\//\\\___        _\/\\\_____________        _\/\\\/////////\\\_   ");
        Console.WriteLine(@"                                    _\///\\\__/\\\____        _\/\\\_____\//\\\__        _\/\\\_____________        _\/\\\_______\/\\\_  ");
        Console.WriteLine(@"                                    ____\///\\\\\/_____        _\/\\\______\//\\\_        _\/\\\\\\\\\\\\\\\_        _\/\\\_______\/\\\_ ");
        Console.WriteLine(@"                                     ______\/////_______        _\///________\///__        _\///////////////__        _\///________\///__");
        Thread.Sleep(500);
    }

    public static void Exit()
    {
        Console.WriteLine("\n\n\n");
        Console.WriteLine("                                                                                                                                                         ");
        Console.WriteLine("8888888 8888888888 8 8888        8          .8.          b.             8 8 8888     ,88'           `8.`8888.      ,8'     ,o888888o.     8 8888      88 ");
        Console.WriteLine("      8 8888       8 8888        8         .888.         888o.          8 8 8888    ,88'             `8.`8888.    ,8'   . 8888     `88.   8 8888      88 ");
        Console.WriteLine("      8 8888       8 8888        8        :88888.        Y88888o.       8 8 8888   ,88'               `8.`8888.  ,8'   ,8 8888       `8b  8 8888      88 ");
        Console.WriteLine("      8 8888       8 8888        8       . `88888.       .`Y888888o.    8 8 8888  ,88'                 `8.`8888.,8'    88 8888        `8b 8 8888      88 ");
        Console.WriteLine("      8 8888       8 8888        8      .8. `88888.      8o. `Y888888o. 8 8 8888 ,88'                   `8.`88888'     88 8888         88 8 8888      88 ");
        Console.WriteLine("      8 8888       8 8888        8     .8`8. `88888.     8`Y8o. `Y88888o8 8 8888 88'                     `8. 8888      88 8888         88 8 8888      88 ");
        Console.WriteLine("      8 8888       8 8888888888888    .8' `8. `88888.    8   `Y8o. `Y8888 8 888888<                       `8 8888      88 8888        ,8P 8 8888      88 ");
        Console.WriteLine("      8 8888       8 8888        8   .8'   `8. `88888.   8      `Y8o. `Y8 8 8888 `Y8.                      8 8888      `8 8888       ,8P  ` 8888     ,8P ");
        Console.WriteLine("      8 8888       8 8888        8  .888888888. `88888.  8         `Y8o.` 8 8888   `Y8.                    8 8888       ` 8888     ,88'     8888   ,d8P  ");
        Console.WriteLine("      8 8888       8 8888        8 .8'       `8. `88888. 8            `Yo 8 8888     `Y8.                  8 8888          `8888888P'        `Y88888P'   ");
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine("\t\t\t\t\t\t\t\t\tFor using our system!");
        Console.Write("\n\n\n\t\t\t\t\t\t\t\t\tPress any key to exit...");
        Console.ReadKey();
        Console.Clear();

    }
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
                loadingScreen();
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("\t\t\t\t\t\t==================================================================");
                Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
                Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
                Console.WriteLine("\t\t\t\t\t\t||\t\t Welcome to OKEA!\t\t\t\t||");
                Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
                Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
                Console.WriteLine("\t\t\t\t\t\t||\tDo you want to sign up or login?\t\t\t||");
                Console.WriteLine("\t\t\t\t\t\t||\t1.) Sign Up\t\t\t\t\t\t||");
                Console.WriteLine("\t\t\t\t\t\t||\t2.) Login\t\t\t\t\t\t||");
                Console.WriteLine("\t\t\t\t\t\t||\t3.) Exit\t\t\t\t\t\t||");
                // Console.WriteLine("\t\t\t\t\t\t==================================================================");
                Console.Write("\t\t\t\t\t\t\t#> ");
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
                        Console.Clear();
                        Console.WriteLine("\n\n\n");
                        Exit();
                        // Console.WriteLine("Exiting...");
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
                    // Console.Clear();
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine("\t\t\t\t\t\t==================================================================");
                    Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
                    Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
                    Console.WriteLine($"\t\t\t\t\t\t||\tWelcome User: {uid}\t\t\t\t\t\t||");
                    Console.WriteLine("\t\t\t\t\t\t||\tChoose an Action\t\t\t\t\t||");
                    Console.WriteLine("\t\t\t\t\t\t||\t1.) Display Inventory\t\t\t\t\t||");
                    Console.WriteLine("\t\t\t\t\t\t||\t2.) Add Items\t\t\t\t\t\t||");
                    Console.WriteLine("\t\t\t\t\t\t||\t3.) Update Item\t\t\t\t\t\t||");
                    Console.WriteLine("\t\t\t\t\t\t||\t4.) Delete Item\t\t\t\t\t\t||");
                    Console.WriteLine("\t\t\t\t\t\t||\t5.) Search Item\t\t\t\t\t\t||");
                    Console.WriteLine("\t\t\t\t\t\t||\t6.) Logout\t\t\t\t\t\t||");
                    Console.Write("\n\t\t\t\t\t\t\t#> ");
                    var choice = Console.ReadLine();

                    try
                    {
                        switch (choice)
                        {
                            case "1":  
                                await jsonActions.DisplayUserInventory(uid);     
                                break;

                            case "2":
                                Console.WriteLine("\t\t\t\t\t\tEnter the following item details you wish to add:");

                                string product;
                                do
                                {
                                    Console.Write("\t\t\t\t\t\tEnter Product: ");
                                    product = Console.ReadLine();
                                } while (string.IsNullOrWhiteSpace(product));

                                string type;
                                do
                                {
                                    Console.Write("\t\t\t\t\t\tEnter Type: ");
                                    type = Console.ReadLine();
                                } while (string.IsNullOrWhiteSpace(type));

                                int amount;
                                while (true)
                                {
                                    Console.Write("\t\t\t\t\t\tEnter Amount: ");
                                    if (int.TryParse(Console.ReadLine(), out amount) && amount >= 0) break;
                                    Console.WriteLine("\t\t\t\t\t\tInvalid amount.");
                                }


                                string group;
                                do
                                {
                                    Console.Write("\t\t\t\t\t\tEnter Group: ");
                                    group = Console.ReadLine();
                                } while (string.IsNullOrWhiteSpace(group));

                                int newId = await GetNextItemId();

                                await jsonActions.AddJSONData(uid, newId, product, type, amount, group);
                                break;


                            case "3":
                                Console.WriteLine("\n\t\t\t\t\t\tEnter ID of item to update:");
                                Console.Write("\t\t\t\t\t\t#>");
                                var updateId = int.Parse(Console.ReadLine());

                                Console.WriteLine("\n\t\t\t\t\t\tEnter new Product:");
                                Console.WriteLine("\t\t\t\t\t\tLeave Blank To Retain...");
                                Console.Write("\t\t\t\t\t\t#>");

                                var updateProduct = Console.ReadLine();

                                Console.WriteLine("\n\t\t\t\t\t\tEnter new Type:");
                                Console.WriteLine("\t\t\t\t\t\tLeave Blank To Retain...");
                                Console.Write("\t\t\t\t\t\t#>");

                                var updateType = Console.ReadLine();

                                Console.WriteLine("\n\t\t\t\t\t\tEnter new Amount:");
                                Console.WriteLine("\t\t\t\t\t\tLeave Blank To Retain...");
                                Console.Write("\t\t\t\t\t\t#>");

                                var updateAmountInput = Console.ReadLine();
                                int? updateAmount = null;
                                if (!string.IsNullOrWhiteSpace(updateAmountInput))
                                {
                                    if (int.TryParse(updateAmountInput, out var parsedAmount) && parsedAmount >= 0)
                                    {
                                        updateAmount = parsedAmount;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n\t\t\t\t\t\tInvalid amount entered.");
                                        break;
                                    }
                                }

                                Console.WriteLine("\n\t\t\t\t\t\tEnter new Group:");
                                Console.WriteLine("\t\t\t\t\t\tLeave Blank To Retain...");
                                Console.Write("\t\t\t\t\t\t#>");
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
                                Console.WriteLine("\n\t\t\t\t\t\tEnter ID of item to delete:");
                                Console.Write("\t\t\t\t\t\t#>");
                                var deleteIdStr = Console.ReadLine();
                                if (int.TryParse(deleteIdStr, out int deleteId))
                                {
                                    await jsonActions.DeleteJSONData(uid, deleteId);
                                }
                                else
                                {
                                    Console.WriteLine("\n\t\t\t\t\t\tInvalid ID format. Please enter a valid integer ID.");
                                }
                                break;

                            case "5":
                                Console.WriteLine("\n\t\t\t\t\t\t*Note: use their numeric identifiers.\n\t\t\t\t\t\tSearch Items by their: ");
                                Console.WriteLine("\t\t\t\t\t\t1.) ID");
                                Console.WriteLine("\t\t\t\t\t\t2.) Product Name");
                                Console.WriteLine("\t\t\t\t\t\t3.) Type");
                                Console.WriteLine("\t\t\t\t\t\t4.) Group");
                                Console.WriteLine("\t\t\t\t\t\t5.) Amount (less than or Greater than)");
                                Console.Write("\t\t\t\t\t\t#>");
                                var searchPreference = Console.ReadLine();
                                string argument = "";
                                string searchTerm = "";
                                switch (searchPreference)
                                {
                                    case "1":
                                        argument = "id";
                                        Console.WriteLine("\n\t\t\t\t\t\tEnter an ID to search for: ");
                                        Console.Write("\t\t\t\t\t\t#>");
                                        searchTerm = Console.ReadLine();
                                        break;
                                    case "2":
                                        argument = "product";
                                        Console.WriteLine("\n\t\t\t\t\t\tEnter a product to search for: ");
                                        Console.Write("\t\t\t\t\t\t#>");
                                        searchTerm = Console.ReadLine();
                                        break;
                                    case "3":
                                        argument = "type";
                                        Console.WriteLine("\n\t\t\t\t\t\tEnter a type to search for: ");
                                        Console.Write("\t\t\t\t\t\t#>");
                                        searchTerm = Console.ReadLine();
                                        break;
                                    case "4":
                                        argument = "group";
                                        Console.WriteLine("\n\t\t\t\t\t\tEnter a group to search for: ");
                                        Console.Write("\t\t\t\t\t\t#>");
                                        searchTerm = Console.ReadLine();
                                        break;
                                    case "5":
                                    argument = "amount";
                                    Console.WriteLine("\n\t\t\t\t\t\tEnter an amount to search for: ");
                                    while (true)
                                    {
                                        Console.Write("\t\t\t\t\t\t#>");
                                        if (int.TryParse(Console.ReadLine(), out amount) && amount >= 0) break;
                                        Console.WriteLine("\t\t\t\t\t\tInvalid amount. Please enter a non-negative integer.");
                                    }

                                    searchTerm = amount.ToString();
                                    break;

                                }
                                if (!string.IsNullOrEmpty(argument) && !string.IsNullOrEmpty(searchTerm))
                                {
                                    await jsonActions.SearchJSONDATA(argument, searchTerm);
                                }
                                break;

                            case "6":
                                Console.Write("\n\t\t\t\t\t\t\tLogging out...");
                                Thread.Sleep(1000);
                                loggedIn = false;
                                break;

                            default:
                                Console.Write("\t\t\t\t\t\tInvalid choice, please try again.");
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
        Console.Clear();
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine("\t\t\t\t\t\t==================================================================");
        Console.WriteLine("\t\t\t\t\t\t||                                                              ||");

        Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
        Console.WriteLine("\t\t\t\t\t\t||\tPlease login to access the system:\t\t\t||");

        Console.Write("\t\t\t\t\t\t||\tUsername: ");
        var username = Console.ReadLine();

        Console.Write("\t\t\t\t\t\t||\tPassword: ");
        var password = Console.ReadLine();

        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            GlobalVariables.UserID = user.UserId;
            GlobalVariables.IsAdmin = user.UserId == 3; // Assuming user with ID 3 is Admin

            Console.Write("\n\t\t\t\t\t\t\tLogin successful!");
            Thread.Sleep(1000);
            return true;
        }
        else
        {

            Console.WriteLine("\t\t\t\t\t\t||\tInvalid username or password.\t\t\t\t||");
            Console.WriteLine("\t\t\t\t\t\t==================================================================");

            Console.Write("\n\n\t\t\t\t\t\tPress any key to continue...");
            Console.ReadKey();
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
        Console.Clear();
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine("\t\t\t\t\t\t==================================================================");
        Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
        Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
        Console.WriteLine("\t\t\t\t\t\t||\tPlease enter the following details to sign up:\t\t||");

        Console.Write("\t\t\t\t\t\t||\tUsername: ");
        var username = Console.ReadLine();

        Console.Write("\t\t\t\t\t\t||\tPassword: ");
        var password = Console.ReadLine();

        var existingUser = users.FirstOrDefault(u => u.Username == username);
        if (existingUser != null)
        {
            Console.WriteLine("\t\t\t\t\t\t||                                                              ||");
            Console.WriteLine("\t\t\t\t\t\t||Username already exists. Please choose a different username.\t||");
            Console.WriteLine("\t\t\t\t\t\t==================================================================");
            Console.Write("\n\n\t\t\t\t\t\tPress any key to continue...");
            Console.ReadKey();
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
