using DVHNETMVC3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace DVHNETMVC3.Controllers
{
    public class ProductController : Controller
    {
        
            private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Quần Áo" },
            new Category { Id = 2, Name = "Túi xách" },
            new Category { Id = 3, Name = "Đồng hồ" },
            new Category { Id = 4, Name = "Tivi" },
            new Category { Id = 5, Name = "Tủ lạnh" },
            new Category { Id = 6, Name = "Máy bơm" },
            new Category { Id = 7, Name = "Quạt điện" },
            new Category { Id = 8, Name = "Lò sưởi" }
        };

        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Bộ đồ bơi cho trẻ em nam", Image = "/shopping.webp", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = "Lorem ipsum dolor sit amet...", Status = true, CreatedAt = new DateTime(2021, 07, 15, 12, 0, 0) },
            new Product { Id = 2, Name = "Bộ đồ bơi cho trẻ em nữ", Image = "/images.jpg", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = "Mô tả đồ bơi nữ...", Status = true, CreatedAt = DateTime.Now },
            new Product { Id = 3, Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi", Image = "/shopping (1).webp", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = "Mô tả đồ bơi 3-5 tuổi...", Status = true, CreatedAt = DateTime.Now },
            new Product { Id = 4, Name = "Bộ đồ bơi cho trẻ em thời trang", Image = "/shopping (2).webp", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = "Mô tả đồ bơi thời trang...", Status = true, CreatedAt = DateTime.Now },
            new Product { Id = 5, Name = "Túi thời trang mẫu mới 2021", Image = "/images (1).jpg", Price = 50000, SalePrice = 35000, CategoryId = 2, Description = "Mô tả túi xách 2021...", Status = true, CreatedAt = DateTime.Now },
            new Product { Id = 6, Name = "Túi thời trang da cá sấu", Image = "/images (2).jpg", Price = 50000, SalePrice = 35000, CategoryId = 2, Description = "Mô tả túi da cá sấu...", Status = true, CreatedAt = DateTime.Now }
        };
        // Đổi Route từ /Product thành /san-pham
        [Route("san-pham")]
        public IActionResult Product(int? categoryId)
        {
            // Truyền danh sách Categories qua ViewBag để vẽ menu bên trái
            ViewBag.Categories = categories;

            var result = products.AsQueryable();

            // Nếu người dùng click vào danh mục bên trái
            if (categoryId.HasValue)
            {
                result = result.Where(p => p.CategoryId == categoryId.Value);
            }

            return View(result.ToList());
        }

        // Trang Chi tiết sản phẩm
        [Route("san-pham/chi-tiet/{id}")]
        public IActionResult Detail(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        }
    }
