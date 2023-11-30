using Shopify.Models;

namespace Shopify.Services
{
    public interface IFileManager 
    {
        void WriteToJsonFile(List<ShopItem> filePath);
        List<ShopItem> ReadFromJson();
    }
}
