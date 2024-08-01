using CurvaStore.DataBase;
using CurvaStore.Models;
using CurvaStore.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace CurvaStore.Controllers
{
    public class DashBoardController : Controller
    {
        
        private static ProductColor productColor=new ProductColor();
        
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hosting;

        
        public DashBoardController(ApplicationDbContext db, IHostingEnvironment hosting)
        {
            _db = db;
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            productColor._categories = _db.categories.ToList();
            return View(productColor);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductColor productColor)
        {
            ModelState.Remove("_categories");
            if (!ModelState.IsValid)
            {
                productColor._categories = _db.categories.ToList();
                return View(productColor);
            }
            else
            {
                
                if (_db.products.FirstOrDefault(x => x.code == productColor.product.code) == null)
                {
                    if (productColor.product.ProductImage != null)
                    {
                        string imgfolder = Path.Combine(_hosting.WebRootPath, "images");
                        string imgpath = Path.Combine(imgfolder, productColor.product.ProductImage.FileName);
                        productColor.product.ProductImage.CopyTo(new FileStream(imgpath, FileMode.Create));
                        productColor.product.Img = productColor.product.ProductImage.FileName;
                    }
                    _db.products.Add(productColor.product);
                    _db.SaveChanges();
                }
                else
                {
                    productColor.product.Id = _db.products.FirstOrDefault(x => x.code == productColor.product.code).Id;
                }
                productColor.colorSize.ProductId = productColor.product.Id;
                productColor.colorSize.Size.ToUpper();
                bool check = false;
                foreach (var item in (_db.colorsAndSizes.Where(m => m.ProductId == productColor.colorSize.ProductId).ToList()))
                {
                    if (item.color == productColor.colorSize.color && item.Size.ToUpper() == productColor.colorSize.Size)
                    {
                        check = true;
                        _db.colorsAndSizes.FirstOrDefault(m => m.id == item.id).Quantity += productColor.colorSize.Quantity;
                        _db.SaveChanges();
                        break;
                    }
                }
                if (!check)
                {
                    if (_db.colorsAndSizes.Count() == 0)
                    {
                        productColor.colorSize.id = 1;
                    }
                    else
                    {
                        productColor.colorSize.id = _db.colorsAndSizes.OrderBy(m => m.id).Last().id + 1;
                    }
                    _db.colorsAndSizes.Add(productColor.colorSize);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }  
        }
        public IActionResult ViewProducts()
        {
            ProductsAndColors productsAndColors=new ProductsAndColors();
            productsAndColors.products = _db.products.Include(p=>p.category).ToList();
            productsAndColors.colorSizes = _db.colorsAndSizes.ToList();
            return View(productsAndColors);
        }
        public IActionResult EditProduct(int id)
        {
            ProductColor productColor = new ProductColor();
            productColor.colorSize=_db.colorsAndSizes.FirstOrDefault(x => x.id == id);
            productColor.product = _db.products.FirstOrDefault(x => x.Id == productColor.colorSize.ProductId);
            productColor._categories = _db.categories.ToList();
            return View(productColor);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductColor pc)
        {

            ModelState.Remove("_categories");
            if (pc.product.ProductImage == null)
            {
                ModelState.Remove("product.ProductImage");
            }
            if (!ModelState.IsValid)
            { 
                
                pc._categories = _db.categories.ToList();
                return View(pc);
            }
            else
            {
                ProductColor productColor = new ProductColor();
                productColor.product = _db.products.FirstOrDefault(x => x.Id == pc.product.Id);
                if (pc.product.ProductImage != null)
                {
                    string imgfolder = Path.Combine(_hosting.WebRootPath, "images");
                    string imgpath = Path.Combine(imgfolder, pc.product.ProductImage.FileName);
                    pc.product.ProductImage.CopyTo(new FileStream(imgpath, FileMode.Create));
                    productColor.product.Img = pc.product.ProductImage.FileName;
                    productColor.product.ProductImage = pc.product.ProductImage;
                }
                productColor.product.code = pc.product.code;
                productColor.product.price = pc.product.price;
                productColor.product.OldPrice = pc.product.OldPrice;
                productColor.product.Name = pc.product.Name;
                productColor.product.BrandName = pc.product.BrandName;
                productColor.product.ClubName = pc.product.ClubName;
                productColor.product.Season = pc.product.Season;
                productColor.product.InStock = pc.product.InStock;
                productColor.product.CategoroyID = pc.product.CategoroyID;
                productColor.product.Description = pc.product.Description;
                _db.SaveChanges();
                pc.colorSize.Size.ToUpper();
                bool check = false;
                foreach (var item in (_db.colorsAndSizes.Where(m => m.ProductId == pc.colorSize.ProductId).ToList()))
                {
                    if (item.color == pc.colorSize.color && item.Size.ToUpper() == pc.colorSize.Size)
                    {
                        check = true;
                        _db.colorsAndSizes.FirstOrDefault(m => m.id == item.id).Quantity += pc.colorSize.Quantity;
                        _db.SaveChanges();
                    }
                }
                if (!check)
                {
                    productColor.colorSize = _db.colorsAndSizes.FirstOrDefault(x => x.id == pc.colorSize.id);
                    productColor.colorSize.Size = pc.colorSize.Size;
                    productColor.colorSize.Quantity = pc.colorSize.Quantity;
                    productColor.colorSize.color = pc.colorSize.color;
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteProduct(int id)
        {
            ColorSize cs=_db.colorsAndSizes.FirstOrDefault(y => y.id == id);
            int ID = cs.ProductId;
            _db.colorsAndSizes.Remove(cs);
            _db.SaveChanges();
            if (_db.colorsAndSizes.FirstOrDefault(x => x.ProductId == ID) == null)
            {
                Product p=_db.products.FirstOrDefault(x => x.Id == ID);
                _db.products.Remove(p);
                _db.SaveChanges();
            }
            return RedirectToAction("ViewProducts");
        }
        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            if (!ModelState.IsValid&&ModelState.First().Value.RawValue!=null)
            {
                return View(blog);
            }
            else
            {
                if (blog.BlogImage != null)
                {
                    string imgfolder = Path.Combine(_hosting.WebRootPath, "images");
                    string imgpath = Path.Combine(imgfolder, blog.BlogImage.FileName);
                    blog.BlogImage.CopyTo(new FileStream(imgpath, FileMode.Create));
                    blog.Img = blog.BlogImage.FileName;
                }
                _db.blogs.Add(blog);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public IActionResult ViewBlogs()
        {
            return View(_db.blogs.ToList());
        }
        public IActionResult EditBlog(int id)
        {
            Blog blog = _db.blogs.FirstOrDefault(x => x.Id == id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            if (!ModelState.IsValid && ModelState.GetValueOrDefault("Img").RawValue!=null)
            {
                return View(blog);
            }
            else
            {
                Blog b = _db.blogs.FirstOrDefault(x => x.Id == blog.Id);
                if (blog.BlogImage != null)
                {
                    string imgfolder = Path.Combine(_hosting.WebRootPath, "images");
                    string imgpath = Path.Combine(imgfolder, blog.BlogImage.FileName);
                    blog.BlogImage.CopyTo(new FileStream(imgpath, FileMode.Create));
                    b.Img = blog.BlogImage.FileName;
                }
                b.Tittle = blog.Tittle;
                b.dateTime = blog.dateTime;
                b.Description = blog.Description;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }   
        }
        public IActionResult DeleteBlog(int id)
        {
            Blog b = _db.blogs.FirstOrDefault(x => x.Id == id);
            _db.blogs.Remove(b);
            _db.SaveChanges();
            return RedirectToAction("ViewBlogs");
        }
       
    }
}
