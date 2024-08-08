using CurvaStore.Models;

namespace CurvaStore.ModelView
{
    public class SingaleProductModelView
    {
        public Product product {  get; set; }
        public List<ColorSize> colorSizes { get; set; }
        public string ?userId { get; set; }
        public bool wishbool {  get; set; }
        public WishList wishList { get; set; }
    }
}
