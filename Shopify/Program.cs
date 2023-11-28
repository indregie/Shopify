
using Shopify.Models;
using Shopify.Services;


List<string> items = new List<string>();

TagService tagService = new TagService();
ShopItemService shopItemService = new ShopItemService();

var item1 = new ShopItem()
{
    Name = "silkė",
    Description = "galima naudoti Kūčioms",
    Tag = tagService.CreateTag(1, "sūrus"),
    TagExpiry = DateTime.Now.AddDays(2),
    Price = 12.25,
    ItemExpiry = DateTime.Now.AddDays(5),
};

var item2 = new ShopItem("sausainiai", "su apelsinų įdaru", 2, 
    "saldus", DateTime.Now.AddDays(2), 0.79, DateTime.Now.AddDays(5));

var item3 = new ShopItem()
{
    Name = "sirupas",
    Description = "skiedžiamas vandeniu",
    Tag = tagService.CreateTag(1, "saldus"),
    TagExpiry = DateTime.Now.AddDays(2),
    Price = 12.25,
    ItemExpiry = DateTime.Now.AddDays(5),
};


items.Add(item1.ToString());
items.Add(item2.ToString());
items.Add(item3.ToString());


shopItemService.WriteToFile(items);


tagService.PrintUniqueTagNames();