
using Shopify.Models;


List<string> items = new List<string>();

var item1 = new ShopItem()
{
    Name = "kėdė",
    Description = "su akcija, bet gera",
    Tag = "svetainės",
    TagExpiry = DateTime.Now.AddDays(2),
    Price = 12.25,
    ItemExpiry = DateTime.Now.AddDays(5),
};

var item2 = new ShopItem()
{
    Name = "sausainiai",
    Description = "su apelsinų įdaru",
    Tag = "saldus",
    TagExpiry = DateTime.Now.AddDays(2),
    Price = 0.79,
    ItemExpiry = DateTime.Now.AddDays(5),
};

items.Add(item1.ToString());
items.Add(item2.ToString());

//foreach (var item in items)
//{
//    Console.WriteLine(item.ToString());
//}

File.WriteAllLines("WriteFile.txt", items);