using APIDers1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDers.Service.DTOs.Product
{
    public class ProductGetDto
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }

        public string Image { get; set; }
        public string ImageUrl { get; set; }

        //relations
        public Category Category { get; set; }
    }
}
