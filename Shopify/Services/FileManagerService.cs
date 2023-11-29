using Shopify.Models;
using System.Text.Json;

namespace Shopify.Services
{
    public class FileManagerService : IFileManager<ShopItem>
    {
        //private List<ShopItem> _shopItems = new List<ShopItem>();
        private string _fileName = "C:\\Users\\Indre\\source\\repos\\Shopify2\\Shopify\\bin\\Debug\\net8.0\\ShopItems.json";

        //serialize to Json
        public void WriteToJsonFile(List<ShopItem> shopItems)
        {
            var jsonFile = JsonSerializer.Serialize(shopItems);
            File.WriteAllText(_fileName, jsonFile);
        }

        //deserialize Json
        public List<ShopItem> ReadFromJson()
        {
            string jsonString = File.ReadAllText(_fileName);
            List<ShopItem> shopItems = new List<ShopItem>();
            shopItems = JsonSerializer.Deserialize<List<ShopItem>>(jsonString);
            return shopItems;
        }





        //public void WriteToFile(List<string> items)
        //{
        //    using (StreamWriter sw = new StreamWriter("WriteFile.txt"))
        //    {
        //        foreach (var item in items)
        //        {
        //            Console.WriteLine(item.ToString());
        //            sw.WriteLine(item.ToString());
        //        }
        //    }

        //}
    }
}
