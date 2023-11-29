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
        public string? Description { get; set; }
        public List<Tag>? Tags { get; set; }
        public DateTime? TagExpiry { get; set; }
        public double Price { get; set; }
        public DateTime? ItemExpiry { get; set; } 
        public int? Quantity { get; set; }

        public ShopItem(string name, string description, int tagId, string tagName, DateTime tagExpiry, double price, DateTime itemExpiry, int quantity)
        {
            this.Name = name;
            this.Description = description;
            this.Tags = new List<Tag>();
            this.Tags.Add(new Tag(){ Id = tagId, Name = tagName });
            this.TagExpiry = tagExpiry;
            this.Price = price;
            this.ItemExpiry = itemExpiry;
            this.Quantity = quantity;
        }
        public ShopItem()
        { 
            
        }

        public ShopItem(string name, double price, int quantity)
        {
            this.Name= name;
            this.Description = null;
            this.Tags = null;
            this.TagExpiry= null;
            this.Price = price;
            this.ItemExpiry= null;
            this.Quantity = quantity;
        }

        public override string ToString() //trūksta tagų listo printinimo
        {
            return $"Name: {Name}, Desc: {Description}, Tag expiry Date: {TagExpiry}," +
                $" Price: {Price}, Item expiry date: {ItemExpiry}";
        }

    }

}