using Shop.Models.Base;

namespace Shop.Models
{
    public class Product:BaseIdentity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
    }
}
