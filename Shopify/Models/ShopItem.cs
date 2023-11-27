using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Models
{
    public class ShopItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public DateTime TagExpiry { get; set; }
        public double Price { get; set; }
        public DateTime ItemExpiry { get; set; }



        public override string ToString()
        {
            return $"Name: {Name} Desc: {Description} Tag: {Tag} Expiry Date: {TagExpiry}" +
                $" Price: {Price} Item expiry date: {ItemExpiry}";
        }




    }
}
