
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
            Console.WriteLine("Items currently in inventory");
            foreach (var item in _shopItems)
            {
                Console.WriteLine(item.Name);
            }
        }
        


    }
}