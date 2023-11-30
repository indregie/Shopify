
using Shopify.Models;

namespace Shopify.Services
{
    public class ShopItemService : IShopItemService
    {
        private List<ShopItem> _shopItems; //get item list ir get item (pagal name) metodus
        private IFileManager<ShopItem> _fileManagerService;

        public ShopItemService(IFileManager<ShopItem> fileManagerService)
        {
           this._fileManagerService = fileManagerService;
        }

        public void AddItemToInventory(string name, double price, int quantity)
        {
            _shopItems = _fileManagerService.ReadFromJson();
            ShopItem item = new ShopItem(name, price, quantity);
            _shopItems.Add(item);
            _fileManagerService.WriteToJsonFile(_shopItems);
        }

        public void ShowInventory() 
        {
            _shopItems = _fileManagerService.ReadFromJson();
            if (_shopItems.Count < 0) { Console.WriteLine("Currently no items available."); }
            Console.WriteLine("Items currently available in inventory: ");
            foreach (var item in _shopItems)
            {
                if (item.Quantity > 0 && item.Quantity != null)
                {
                    Console.WriteLine($"{item.Name}: {item.Quantity} items left.");
                }
            }
        }

        public ShopItem SellItem (string name, int quantity) 
        {
            _shopItems = _fileManagerService.ReadFromJson();
            var itemToSell = _shopItems.Single(i => i.Name == name);
            if (itemToSell.Quantity < quantity)
            {
                return null;
            }
            itemToSell.Quantity -= quantity;
            _fileManagerService.WriteToJsonFile(_shopItems);
            

            return itemToSell;
        }
        


    }
}