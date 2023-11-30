using Shopify.Models;
using System.Text.Json;

namespace Shopify.Services
{
    public class FileManagerService : IFileManager
    {
        //private List<ShopItem> _shopItems = new List<ShopItem>();
        private string _fileName = "C:\\Users\\i.giedraityte\\Desktop\\repos\\Shopify\\Shopify\\bin\\Debug\\net8.0\\ShopItems.json";

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
            if (jsonString == null)
            {
                return new List<ShopItem>();
            }
            return shopItems;
        }
    }
}
