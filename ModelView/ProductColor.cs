using CurvaStore.Models;
namespace CurvaStore.ModelView
{
    public class ProductColor
    {

        public Product? product { get; set; }
        public ColorSize? colorSize { get; set; }
        public List<Category> _categories { get; set; }

    }
}
