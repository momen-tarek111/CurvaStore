using CurvaStore.Models;

namespace CurvaStore.ModelView
{
    public class ProductsAndCategories
    {
        public List<Product> products { get; set; }
        public List<Category> categories { get; set; }
        public List<WishList> wishLists { get; set; }
        public int id { get; set; }
        public int sortId { get; set; }
        public int currPage { get; set; }
        public int TotalPages { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

    }
}
