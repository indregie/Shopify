
using Shopify.Models;


List<string> items = new List<string>();

//var item1 = new ShopItem()
//{
//    Name = "silkė",
//    Description = "galima naudoti Kūčioms",
//    Tag = new Tag()
//    {
//        1,
//        "sūrus"
//    },
//    TagExpiry = DateTime.Now.AddDays(2),
//    Price = 12.25,
//    ItemExpiry = DateTime.Now.AddDays(5),
//};

var item2 = new ShopItem("sausainiai", "su apelsinų įdaru", 2, 
    "saldus", DateTime.Now.AddDays(2), 0.79, DateTime.Now.AddDays(5));

//items.Add(item1.ToString());
items.Add(item2.ToString());


using (StreamWriter sw = new StreamWriter("WriteFile.txt"))
{
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
        sw.WriteLine(item.ToString());
    }
}