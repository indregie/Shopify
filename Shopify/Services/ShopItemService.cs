
using Shopify.Models;

namespace Shopify.Services
{
    public class ShopItemService
    {
        private List<ShopItem> _shopItems; //get item list ir get item (pagal name) metodus

        //public List<ShopItem> LoadItemList()
        //{
        //    shopItems = _shopItems;
        //    return shopItems;
        //}


        
        
        //_shopItems = fileManagerService.ReadFromJson();

        

        //foreach (var item in _inventoryItems)
        //{
        //    Console.WriteLine(item.Name);
        //}
        public void AddItemToInventory(string name, double price, int quantity)
        {
            ShopItem item = new ShopItem(name, price, quantity);
            _shopItems.Add(item);
        }
        
        

    }
}