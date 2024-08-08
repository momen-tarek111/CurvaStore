using CurvaStore.Models;

namespace CurvaStore.ModelView
{
    public class WishListModelView
    {
        public List<WishList> wishLists {  get; set; }
        public int currpage { get; set; }
        public int totalPages { get; set; }
        public int? sortID { get; set; }
    }
}
