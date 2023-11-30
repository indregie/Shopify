using Shopify.Models;

namespace Shopify.Services
{
    public class ShopClientService
    {
        private double _balance = 20;
        private List<ShopItem> _clientItems;
        private IFileManager _fileManagerService;
        private IShopItemService _shopItemService;

        public ShopClientService(IFileManager fileManagerService, IShopItemService shopItemService)
        {
            this._fileManagerService = fileManagerService;
            this._shopItemService = shopItemService;
            _clientItems = new List<ShopItem>();
        }

        public double DisplayBalance()
        {
            return _balance;
        }

        public void TopupBalance(double topupSum)
        {
            _balance = _balance + topupSum;
            Console.WriteLine($"You succesfully added {topupSum} EUR to your balance account.\n" +
                $"Your current balance is {_balance} EUR.");
        }

        public void BuyItem(string itemToBuy, int quantityToBuy)
        {
            var item = _shopItemService.SellItem(itemToBuy, quantityToBuy);
            if (item == null)
            {
                Console.WriteLine("You cannot buy amount of items that exceeds quantity of items available.");
                return;
            }
            _clientItems.Add(new ShopItem() //copy from inventory
            {
                Name = item.Name,
                Description = item.Description,
                Tags = item.Tags,
                TagExpiry = item.TagExpiry,
                Price = item.Price,
                ItemExpiry = item.ItemExpiry,
                Quantity = quantityToBuy,
            });
            Console.WriteLine("Your buying process was successfull.");
        }

        public void ShowClientCart()
        {
            if (_clientItems.Count <= 0) 
            { 
                Console.WriteLine("You have not added any item to your cart yet.\n");
                return;
            }
            foreach (var item in _clientItems)
            {
                Console.WriteLine($"You have added {item.Name}, {item.Quantity} items, for the price of {item.Price} \n");
            }

        }
    }
}
