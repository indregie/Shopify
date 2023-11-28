
using Shopify.Models;

namespace Shopify.Services
{
    public class ShopItemService
    {

        public void WriteToFile(List<string> items)
        {
            using (StreamWriter sw = new StreamWriter("WriteFile.txt"))
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                    sw.WriteLine(item.ToString());
                }
            }
        }
    }
}
