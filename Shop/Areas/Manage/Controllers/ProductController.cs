using Shop.DAL;
using Shop.Models;
using Shop.Extesion;
using Shop.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        public AppDbContext _context;
        public IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProductVM productVM)
        {
            IFormFile file = productVM.Image;
            string result = file?.ChangeValidate("image/", 300);
            if (result.Length > 0)
            {
                ModelState.AddModelError("ImageUrl", result);
            }
            Product product = new Product
            {
                Name = productVM.Name,
                Price = productVM.Price,
                ImageUrl = file.SaveFile(Path.Combine(_env.WebRootPath, "assets", "img", "product"))
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            Product product = _context.Products.Find(id);
            if (product == null) return NotFound();
            product.ImageUrl.DeleteFile(_env.WebRootPath, "assets/img/product");
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
