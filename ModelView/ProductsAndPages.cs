using CurvaStore.Models;

namespace CurvaStore.ModelView
{
    public class ProductsAndPages
    {
        public List<Product> products { get; set; }
        public int currentPage { get; set; }
        public int totalPages {  get; set; }
        public int ?sortId { get; set; }
        public List<WishList> wishList { get; set; }
    }
}
