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
			ProductsBlogs productsBlogs = new ProductsBlogs();
			productsBlogs.products = _db.products.OrderBy(m=>m.Id).Reverse().Take(4).ToList();
            productsBlogs.blogs = _db.blogs.OrderBy(m=>m.dateTime).Reverse().Take(3).ToList();
            productsBlogs.wishList =  _db.wishLists.Where(m=>m.UserId==User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return View(productsBlogs);
		}
		public IActionResult About()
		{
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return View();
		}
		public IActionResult ContactUs()
		{
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return View();
		}
		public IActionResult SubmitMeassage(ContactUs Cus)
		{
            if (!ModelState.IsValid)
			{
                ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                return View("ContactUs",Cus);
			}
			else
			{
				_db.messages.Add(Cus);
				_db.SaveChanges();
                ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                return RedirectToAction("Index");
			}
		}
		public IActionResult Products(int id,int ?currPage, int sortId=5)
		{
            ProductsAndCategories productsAndCategories = new ProductsAndCategories();
            productsAndCategories.wishLists = _db.wishLists.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
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
                    ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                    productsAndCategories.id = id;
                    productsAndCategories.sortId = sortId;
                    return View(productsAndCategories);
                }

                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.price).Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                return View(productsAndCategories);
            }
			else if(sortId == 2)
			{
                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.price).Reverse().Skip(skipProduct).Take(15).ToList();
                    ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                    productsAndCategories.id = id;
                    productsAndCategories.sortId = sortId;
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.price).Reverse().Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                return View(productsAndCategories);
            }
			else if(sortId==3) {

                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.Name).Skip(skipProduct).Take(15).ToList();
                    ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                    productsAndCategories.id = id;
                    productsAndCategories.sortId = sortId;
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.Name).Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                return View(productsAndCategories);
            }
			else if(sortId==4) {

                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.Name).Reverse().Skip(skipProduct).Take(15).ToList();
                    ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                    productsAndCategories.id = id;
                    productsAndCategories.sortId = sortId;
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.Name).Reverse().Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                return View(productsAndCategories);
            }
			else if (sortId==5) {
                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.Id).Reverse().Skip(skipProduct).Take(15).ToList();
                    ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                    productsAndCategories.id = id;
                    productsAndCategories.sortId = sortId;
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.Id).Reverse().Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                return View(productsAndCategories);
            }
			else {
                if (id == 0)
                {
                    productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Count() / 15.0);
                    productsAndCategories.products = _db.products.OrderBy(m => m.Id).Skip(skipProduct).Take(15).ToList();
                    ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                    productsAndCategories.id = id;
                    productsAndCategories.sortId = sortId;
                    return View(productsAndCategories);
                }
                productsAndCategories.TotalPages = (int)Math.Ceiling(_db.products.Where(m => m.CategoroyID == id).Count() / 15.0);
                productsAndCategories.products = _db.products.Where(m => m.CategoroyID == id).OrderBy(m => m.Id).Skip(skipProduct).Take(15).ToList();
                productsAndCategories.id = id;
                productsAndCategories.sortId = sortId;
                ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
                return View(productsAndCategories);
            }
        }
        public IActionResult FilterPrice(ProductsAndCategories ?pac ,int ?currPage, int? min, int? max,int ?id)
        {
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
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return View(pac);
        }
        public IActionResult Blogs(int ?currPages)
        {
            BlogsAndPages blogsAndPagescs = new BlogsAndPages();
            if(currPages == null)
            {
                currPages = 1;
            }
            int skipBlogs= (int)(currPages-1)*12;
            blogsAndPagescs.blogs=_db.blogs.OrderBy(m=>m.dateTime).Reverse().Skip(skipBlogs).Take(12).ToList();
            blogsAndPagescs.currentPages = (int)currPages;
            blogsAndPagescs.totalPages = (int)Math.Ceiling(_db.blogs.Count() / 12.0);
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return View(blogsAndPagescs);
        }
        public IActionResult SingleBlog(int id)
        {
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();

            return View(_db.blogs.FirstOrDefault(m => m.Id == id));
        }
        public IActionResult Offers(int ?currPage,int sortId = 5)
        {
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
            productsAndPagescs.wishList = _db.wishLists.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return View(productsAndPagescs);
        }
        public IActionResult SingleProduct(int id)
        {
            SingaleProductModelView ProductAndColorsAndSizes = new SingaleProductModelView();
            ProductAndColorsAndSizes.product = _db.products.Include(m=>m.category).FirstOrDefault(m => m.Id == id);
            ProductAndColorsAndSizes.colorSizes=_db.colorsAndSizes.Where(m=>m.ProductId==id).ToList();
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            ProductAndColorsAndSizes.userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(_db.wishLists.FirstOrDefault(m=>m.UserId== ProductAndColorsAndSizes.userId && m.ProductId == id) == null)
            {
                ProductAndColorsAndSizes.wishbool = false;   
            }
            else
            {
                ProductAndColorsAndSizes.wishList = _db.wishLists.FirstOrDefault(m => m.UserId == ProductAndColorsAndSizes.userId && m.ProductId == id);
                ProductAndColorsAndSizes.wishbool= true;
            }
            return View(ProductAndColorsAndSizes);
        }
        [HttpPost]
        public IActionResult AddToCart([FromBody] SingleProductInfo spi)
        {
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
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return Ok();
        }
        public IActionResult RemoveFromCart(int id)
        {
            Cart cart =_db.carts.FirstOrDefault(m=>m.Id==id);
            _db.carts.Remove(cart);
            _db.SaveChanges();
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return View("Cart",_db.carts.Where(m=>m.UserId==User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(m=>m.product).Include(m=>m.colorsize).ToList());
        }
        public IActionResult ViewCart()
        {
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return View("Cart", _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(m=>m.product).Include(m=>m.colorsize).ToList());
        }
        [HttpPost]
        public IActionResult RemoveWish ([FromBody]WishModelView wishModelView)
        {
            WishList wishList = _db.wishLists.FirstOrDefault(m => m.id == wishModelView.id);
            _db.wishLists.Remove(wishList);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult AddWish([FromBody] WishModelView wishModelView)
        {
            WishList wishList = new WishList();
            wishList.ProductId = wishModelView.ProductId;
            wishList.UserId = wishModelView.UserId;
            _db.wishLists.Add(wishList);
            _db.SaveChanges();
            return Ok(wishList.id);
        }
        public IActionResult ViewWishList(int? currPage,int sortId=5)
        {
            WishListModelView wishListModelView = new WishListModelView();
            List<WishList> wl = _db.wishLists.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(m=>m.product).ToList();
            if (currPage == null)
            {
                currPage = 1;
            }
            int skipWhishList = (int)(currPage - 1) * 20;
            wishListModelView.currpage = (int)currPage;
            wishListModelView.totalPages = (int)Math.Ceiling(_db.wishLists.Where(m => m.UserId== User.FindFirstValue(ClaimTypes.NameIdentifier)).Count() / 18.0);
            if (sortId == 1)
            {
                wishListModelView.wishLists = wl.OrderBy(m => m.product.price).Skip(skipWhishList).Take(18).ToList();
            }
            else if (sortId == 2)
            {
                wishListModelView.wishLists = wl.OrderBy(m => m.product.price).Reverse().Skip(skipWhishList).Take(18).ToList();

            }
            else if (sortId == 3)
            {
                wishListModelView.wishLists = wl.OrderBy(m => m.product.Name).Skip(skipWhishList).Take(18).ToList();

            }
            else if (sortId == 4)
            {
                wishListModelView.wishLists = wl.OrderBy(m => m.product.Name).Reverse().Skip(skipWhishList).Take(18).ToList();

            }
            else if (sortId == 5)
            {
                wishListModelView.wishLists = wl.OrderBy(m => m.id).Reverse().Skip(skipWhishList).Take(18).ToList();

            }
            else if (sortId == 6)
            {
                wishListModelView.wishLists = wl.OrderBy(m => m.id).Skip(skipWhishList).Take(18).ToList();

            }
            
            wishListModelView.sortID = sortId;
            ViewData["numOfCart"] = _db.carts.Where(m => m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();
            return View(wishListModelView);
        }
        [HttpPost]
        public IActionResult IncreaseQuantityInCart([FromBody] CartModelView cartModelView)
        {
            _db.carts.FirstOrDefault(m => m.Id == cartModelView.id).QuantityOfProduct += 1;
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult DecreaseQuantityInCart([FromBody] CartModelView cartModelView)
        {
            _db.carts.FirstOrDefault(m => m.Id == cartModelView.id).QuantityOfProduct -= 1;
            _db.SaveChanges();
            return Ok();
        }
    }
}
