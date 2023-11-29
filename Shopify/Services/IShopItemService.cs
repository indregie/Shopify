using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Services
{
    public interface IShopItemService
    {
        void AddItemToInventory(string name, double price, int quantity);
    }
}
