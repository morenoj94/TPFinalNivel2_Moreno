using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Article
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Codigo")]
        public string Code { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Descripcion")]
        public string Desciption { get; set; }

        [DisplayName("Marca")]
        public Brand articleBrand { get; set; }

        [DisplayName("Categoria")]
        public Category articleCategory { get; set; }
        public string imageUrl { get; set; }

        [DisplayName("Precio")]
        public decimal Price { get; set; }

    }
}
