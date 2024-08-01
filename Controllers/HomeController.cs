using CurvaStore.DataBase;
using CurvaStore.Models;
using CurvaStore.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CurvaStore.Controllers
{
	public class HomeController(ApplicationDbContext _db) : Controller
	{
       
        public IActionResult Index()
		{
            ViewData["numOfCart"] = _db.carts.Count();
			ProductsBlogs productsBlogs = new ProductsBlogs();
			productsBlogs.products = _db.products.OrderBy(m=>m.Id).Reverse().Take(4).ToList();
            productsBlogs.blogs = _db.blogs.OrderBy(m=>m.dateTime).Reverse().Take(3).ToList();
            return View(productsBlogs);
		}
		public IActionResult About()
		{
            ViewData["numOfCart"] = _db.carts.Count();
            return View();
		}
		public IActionResult ContactUs()
		{
            ViewData["numOfCart"] = _db.carts.Count();
            return View();
		}
		public IActionResult SubmitMeassage(ContactUs Cus)
		{
            ViewData["numOfCart"] = _db.carts.Count();
            if (!ModelState.IsValid)
			{
				return View("ContactUs",Cus);
			}
			else
			{
				_db.messages.Add(Cus);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
		}
		public IActionResult Products(int id,int ?currPage, int sortId=5)
		{
            ViewData["numOfCart"] = _db.carts.Count();
            ProductsAndCategories productsAndCategories= new ProductsAndCategories();
			productsAndCategories.categories = _db.categories.ToList();
            if (currPage == null)
            {
                currPage = 1;
            }
            int skipProduct=(int)(currPage - 1)*15;
            productsAndCategories.currPage = (int)currPage;
			if(sortId == 1)
			{
                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.price).Skip(skipProduct).Take(15).ToList();
                    return View(productsAndCategories);
                }

                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.price).Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                return View(productsAndCategories);
            }
			else if(sortId == 2)
			{
                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.price).Reverse().Skip(skipProduct).Take(15).ToList();
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.price).Reverse().Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                return View(productsAndCategories);
            }
			else if(sortId==3) {

                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.Name).Skip(skipProduct).Take(15).ToList();
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.Name).Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                return View(productsAndCategories);
            }
			else if(sortId==4) {

                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.Name).Reverse().Skip(skipProduct).Take(15).ToList();
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.Name).Reverse().Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                return View(productsAndCategories);
            }
			else if (sortId==5) {
                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.Id).Reverse().Skip(skipProduct).Take(15).ToList();
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.Id).Reverse().Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                return View(productsAndCategories);
            }
			else {
                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.Id).Skip(skipProduct).Take(15).ToList();
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.Id).Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                return View(productsAndCategories);
            }
        }
        public IActionResult FilterPrice(ProductsAndCategories ?pac ,int ?currPage, int? min, int? max,int ?id)
        {
            ViewData["numOfCart"] = _db.carts.Count();
            pac.categories = _db.categories.ToList();
            if (currPage == null)
            {
                currPage = 1;
            }
            if (pac.MinPrice==0&&pac.MaxPrice==0)
            {
                pac.MinPrice = (int)min;
                pac.MaxPrice = (int)max;
                pac.id=(int)id;
            }
            pac.currPage = (int)currPage;
            int skipProduct = (int)(currPage - 1) * 15;
            if (pac.id == 0)
            {
                pac.products = _db.products.Where(m => m.price >= pac.MinPrice && m.price <= pac.MaxPrice).Skip(skipProduct).Take(15).ToList();
                pac.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.price >= pac.MinPrice && m.price <= pac.MaxPrice).Count() / 15.0);

            }
            else
            {
                pac.products = _db.products.Where(m => m.price >= pac.MinPrice && m.price <= pac.MaxPrice && m.CategoroyID == pac.id).Skip(skipProduct).Take(15).ToList();
                pac.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.price >= pac.MinPrice && m.price <= pac.MaxPrice&&m.CategoroyID==pac.id).Count() / 15.0);

            }
            return View(pac);
        }
        public IActionResult Blogs(int ?currPages)
        {
            ViewData["numOfCart"] = _db.carts.Count();
            BlogsAndPages blogsAndPagescs = new BlogsAndPages();
            if(currPages == null)
            {
                currPages = 1;
            }
            int skipBlogs= (int)(currPages-1)*12;
            blogsAndPagescs.blogs=_db.blogs.OrderBy(m=>m.dateTime).Reverse().Skip(skipBlogs).Take(12).ToList();
            blogsAndPagescs.currentPages = (int)currPages;
            blogsAndPagescs.totalPages = (int)Math.Ceiling(_db.blogs.Count() / 12.0);
            return View(blogsAndPagescs);
        }
        public IActionResult SingleBlog(int id)
        {
            ViewData["numOfCart"] = _db.carts.Count();

            return View(_db.blogs.FirstOrDefault(m => m.Id == id));
        }
        public IActionResult Offers(int ?currPage,int sortId = 5)
        {
            ViewData["numOfCart"] = _db.carts.Count();
            ProductsAndPages productsAndPagescs = new ProductsAndPages();
            productsAndPagescs.sortId = sortId;
            if (currPage == null)
            {
                currPage = 1;
            }
            int skipProducts = (int)(currPage - 1) * 20;
            productsAndPagescs.currentPage = (int)currPage;
            productsAndPagescs.totalPages = (int)Math.Ceiling(_db.products.Where(m => m.OldPrice != 0).Count()/20.0);
            if (sortId == 1)
            {
                productsAndPagescs.products = _db.products.Where(m=>m.OldPrice!=0).OrderBy(m=>m.price).Skip(skipProducts).Take(20).ToList();
            }
            else if (sortId == 2)
            {
                productsAndPagescs.products = _db.products.Where(m => m.OldPrice != 0).OrderBy(m => m.price).Reverse().Skip(skipProducts).Take(20).ToList();
            }
            else if (sortId == 3)
            {
                productsAndPagescs.products = _db.products.Where(m => m.OldPrice != 0).OrderBy(m => m.Name).Skip(skipProducts).Take(20).ToList();
            }
            else if (sortId == 4)
            {
                productsAndPagescs.products = _db.products.Where(m => m.OldPrice != 0).OrderBy(m => m.Name).Reverse().Skip(skipProducts).Take(20).ToList();
            }
            else if (sortId == 5)
            {
                productsAndPagescs.products = _db.products.Where(m => m.OldPrice != 0).OrderBy(m => m.Id).Reverse().Skip(skipProducts).Take(20).ToList();
            }
            else
            {
                productsAndPagescs.products = _db.products.Where(m => m.OldPrice != 0).OrderBy(m => m.Id).Skip(skipProducts).Take(20).ToList();
            }
            return View(productsAndPagescs);
        }
        public IActionResult SingleProduct(int id)
        {
            ViewData["numOfCart"] = _db.carts.Count();
            SingaleProductModelView ProductAndColorsAndSizes= new SingaleProductModelView();
            ProductAndColorsAndSizes.product = _db.products.Include(m=>m.category).FirstOrDefault(m => m.Id == id);
            ProductAndColorsAndSizes.colorSizes=_db.colorsAndSizes.Where(m=>m.ProductId==id).ToList();
            return View(ProductAndColorsAndSizes);
        }
        [HttpPost]
        public IActionResult AddToCart([FromBody] SingleProductInfo spi)
        {
            ViewData["numOfCart"] = _db.carts.Count();
            string usid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Cart cart=new Cart();
            cart.productId = spi.ProductId;
            cart.colorSizeId = _db.colorsAndSizes.SingleOrDefault(m => m.Size == spi.Size && m.color == spi.Color && m.ProductId == spi.ProductId).id;
            cart.QuantityOfProduct = spi.Quantity;
            cart.UserId= usid;
            Cart? cart1 = _db.carts.FirstOrDefault(m=>m.UserId==usid&&m.productId==cart.productId&&m.colorSizeId==cart.colorSizeId);
            if ( cart1!= null)
            {
                int newq = cart1.QuantityOfProduct += cart.QuantityOfProduct;
                if(newq> _db.colorsAndSizes.SingleOrDefault(m => m.id == cart.colorSizeId).Quantity)
                {
                    cart1.QuantityOfProduct = _db.colorsAndSizes.SingleOrDefault(m => m.id == cart.colorSizeId).Quantity;
                }
                else
                {
                    cart1.QuantityOfProduct = newq;
                }
                _db.carts.FirstOrDefault(m => m.UserId == usid && m.productId == cart.productId && m.colorSizeId == cart.colorSizeId).QuantityOfProduct = cart1.QuantityOfProduct;
            }
            else
            {
                cart.product = _db.products.SingleOrDefault(m => m.Id == cart.productId);
                cart.colorsize = _db.colorsAndSizes.SingleOrDefault(m => m.id == cart.colorSizeId);
                _db.carts.Add(cart);           
            }
            _db.SaveChanges();
            
            return Ok(new { success = true,});
        }
        public IActionResult RemoveFromCart(int id)
        {
            ViewData["numOfCart"] = _db.carts.Count();
            Cart cart=_db.carts.FirstOrDefault(m=>m.Id==id);
            _db.carts.Remove(cart);
            _db.SaveChanges();
            return View("Cart",_db.carts.Where(m=>m.UserId==User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(m=>m.product).Include(m=>m.colorsize).ToList());
        }
        public IActionResult ViewCart()
        {
            ViewData["numOfCart"] = _db.carts.Count();
            return View("Cart", _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(m=>m.product).Include(m=>m.colorsize).ToList());
        }
    }
}
