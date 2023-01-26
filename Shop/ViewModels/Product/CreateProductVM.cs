using Shop.Models.Base;

namespace Shop.ViewModels.Product
{
    public class CreateProductVM:BaseIdentity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public IFormFile Image { get; set; }
    }
}
