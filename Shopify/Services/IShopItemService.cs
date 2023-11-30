using Shopify.Models;

namespace Shopify.Services
{
    public interface IShopItemService
    {
        void AddItemToInventory(string name, double price, int quantity);
        ShopItem SellItem(string name, int quantity);
        void RemoveFromInventory(string itemName);
        void ShowInventory();
    }
}
