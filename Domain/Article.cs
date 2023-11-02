using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class Article
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Brand articleBrand { get; set; }
        public Category articleCategory { get; set; }
        public string urlImagen { get; set; }
        public decimal Price { get; set; }
    }
}
