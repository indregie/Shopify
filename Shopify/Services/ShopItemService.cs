
using Shopify.Models;
using System.Xml.Linq;

namespace Shopify.Services
{
    public class ShopItemService : IShopItemService
    {
        private List<ShopItem> _shopItems; //get item list ir get item (pagal name) metodus
        private IFileManager _fileManagerService;

        public ShopItemService(IFileManager fileManagerService)
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
            try 
            {
                _shopItems = _fileManagerService.ReadFromJson();
                if (_shopItems.Count <= 0) 
                { 
                    Console.WriteLine("Currently no items available."); 
                }
                Console.WriteLine("\n///////////////////////////////////////" +
                    "\nItems currently available in shop: ");
                foreach (var item in _shopItems)
                {
                    if (item.Quantity > 0 && item.Quantity != null)
                    {
                        Console.WriteLine($"{item.Name}: {item.Quantity} items left. The price is {item.Price} Eur.");
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
        
        public void RemoveFromInventory(string itemName)
        {
            _shopItems = _fileManagerService.ReadFromJson();
            var itemToRemove = _shopItems.Single(i => i.Name == itemName);
            _shopItems.Remove(itemToRemove);
            Console.WriteLine("Item successfully removed from inventory.");
            _fileManagerService.WriteToJsonFile(_shopItems);
        }

    }
}