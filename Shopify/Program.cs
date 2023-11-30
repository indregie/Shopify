using Shopify.Models;
using Shopify.Services;
using System.Linq.Expressions;


//List<ShopItem> shopItems = new List<ShopItem>();

FileManagerService fileManagerService = new FileManagerService();
ShopItemService shopItemService = new ShopItemService(fileManagerService);
ShopClientService shopClientService = new ShopClientService(fileManagerService, shopItemService);



//try catch ir galimai iskelti i papildoma servisa 

    while (true)
    {
    try
    {
        Console.WriteLine("\n Please select and enter number: ");
        Console.WriteLine("1. \"Add item to the list\"\r\n" +
            "2. \"Remove item from the list\" \r\n" +
            "3. \"Show my balance account\" \r\n" +
            "4. \"Topup money to my balance account\" \r\n" +
            "5. \"Buy item\" \r\n" +
            "6.\"Display items\" \r\n" +
            "7. \"Exit\"\r\n");

        var option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
                Console.WriteLine("Please specify item name:");
                var name = Console.ReadLine();
                Console.WriteLine("Please specify item price:");
                var price = double.Parse(Console.ReadLine());
                Console.WriteLine("Please specify quantity of items:");
                var quantity = int.Parse(Console.ReadLine());
                shopItemService.AddItemToInventory(name, price, quantity);
                shopItemService.ShowInventory();
                Console.WriteLine("Item added");
                break;
            case 2:
                Console.WriteLine("Please specify removable item name:");
                var toRemove = Console.ReadLine();
                //shopItemService.AddItemToInventory(name, price, quantity);
                break;
            case 3:
                var currentBalance = shopClientService.DisplayBalance();
                Console.WriteLine($"Your current balance is: {currentBalance}");
                break;
            case 4:
                Console.WriteLine($"Please specify the amount that you want to topup:");
                double topupSum = double.Parse(Console.ReadLine());
                shopClientService.TopupBalance(topupSum);
                break;
            case 5:
                shopItemService.ShowInventory();
                Console.WriteLine($"Please specify the item that you want to buy:");
                var itemToBuy = Console.ReadLine();
                Console.WriteLine($"Please specify the quantity of {itemToBuy} that you want to buy");
                var quantityToBuy = int.Parse(Console.ReadLine());
                shopClientService.BuyItem(itemToBuy, quantityToBuy);
                break;
            case 6:
                Console.WriteLine($"Here are all items that you added to cart:");
                //shopItemService.AddItemToInventory(name, price, quantity);
                break;
            case 7:
                //exit
                return;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

