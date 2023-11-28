using Shopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Services
{
    public class TagService
    {
        public List<Tag> tags = new List<Tag>();

        public Tag CreateTag(int id, string name)
        {
            Tag tag = new Tag()
            {
                Id = id,
                Name = name
            };
            this.tags.Add(tag);
            return tag;
        }

        public List<string> GetUniqueTagNames()
        {
            var uniqueTagNames = tags.Select(tag => tag.Name).Distinct();
            return uniqueTagNames.ToList<string>();
        }

        public void PrintUniqueTagNames()
        {
            var uniqueTagNames = GetUniqueTagNames();
            Console.WriteLine("Unique Tag Names:");
            foreach (var name in uniqueTagNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}