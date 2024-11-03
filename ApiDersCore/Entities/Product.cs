using APIDers1.Core.Entities;
using APIDers1.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDers.Core.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Double  Price { get; set; }

        public string Image { get; set; }
        public string ImageUrl {  get; set; }

        //relations
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
