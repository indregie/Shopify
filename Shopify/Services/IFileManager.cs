using Shopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Services
{
    public interface IFileManager 
    {
        void WriteToJsonFile(List<ShopItem> filePath);
        List<ShopItem> ReadFromJson();
    }
}
