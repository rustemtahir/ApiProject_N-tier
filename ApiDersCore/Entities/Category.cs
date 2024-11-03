using ApiDers.Core.Entities;
using APIDers1.Core.Entities.Base;

namespace APIDers1.Core.Entities
{
    public class Category:BaseEntity
    {
        
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set;}


    }
}
