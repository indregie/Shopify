using Shopify.Models;
using Shopify.Services;
using System.Linq.Expressions;


IFileManager fileManagerService = new FileManagerService();
IShopItemService shopItemService = new ShopItemService(fileManagerService);
ShopClientService shopClientService = new ShopClientService(fileManagerService, shopItemService);


while (true)
{
    try
    {
        shopItemService.ShowInventory();
        Console.WriteLine("\n*********************************" +
            "\nPlease select and enter number: ");
        Console.WriteLine("1. \"Add item to the list\"\r\n" +
            "2. \"Remove item from the list\" \r\n" +
            "3. \"Show my balance account\" \r\n" +
            "4. \"Topup money to my balance account\" \r\n" +
            "5. \"Buy item\" \r\n" +
            "6. \"Display my ordered items\" \r\n" +
            "7. \"Exit\"\r\n" +
            "*********************************");

        string input = Console.ReadLine();
        int option = 0;
        if (input[0] >= '0' && input[0] <= '9')
        {
            option = int.Parse(input);
        }
        else
        {
            option = -1;
        }
        switch (option)
        {
            case 1:
                Console.WriteLine("Please specify item name:");
                var name = Console.ReadLine().ToLower().Trim();
                Console.WriteLine("Please specify item price:");
                var priceInput = Console.ReadLine();
                var price = double.Parse(priceInput.Replace('.', ','));
                Console.WriteLine("Please specify quantity of items:");
                var quantity = int.Parse(Console.ReadLine());
                shopItemService.AddItemToInventory(name, price, quantity);
                shopItemService.ShowInventory();
                Console.WriteLine("Item added");
                break;
            case 2:
                Console.WriteLine("Please specify removable item name:");
                string itemToRemove = Console.ReadLine().ToLower().Trim();
                shopItemService.RemoveFromInventory(itemToRemove);
                break;
            case 3:
                var currentBalance = shopClientService.DisplayBalance();
                Console.WriteLine($"Your current balance is: {currentBalance}");
                break;
            case 4:
                Console.WriteLine($"Please specify the amount that you want to topup:");
                var topupInput = Console.ReadLine();
                double topupSum = double.Parse(topupInput.Replace('.', ','));
                shopClientService.TopupBalance(topupSum);
                break;
            case 5:
                shopItemService.ShowInventory();
                Console.WriteLine($"\nPlease specify the item that you want to buy:");
                var itemToBuy = Console.ReadLine().ToLower().Trim();
                Console.WriteLine($"Please specify the quantity of {itemToBuy} that you want to buy");
                var quantityToBuy = int.Parse(Console.ReadLine());
                shopClientService.BuyItem(itemToBuy, quantityToBuy);
                break;
            case 6:
                shopClientService.ShowClientCart();
                break;
            case 7:
                //exit
                return;
            default:
                Console.WriteLine("Please enter number from 1 to 7.");
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

