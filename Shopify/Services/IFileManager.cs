using Shopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Services
{
    public interface IFileManager<T> 
    {
        void WriteToJsonFile(List<T> filePath);
        List<T> ReadFromJson();
    }
}
