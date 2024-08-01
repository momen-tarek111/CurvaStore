using CurvaStore.Models;

namespace CurvaStore.ModelView
{
    public class BlogsAndPages
    {
        public List<Blog> blogs {  get; set; }
        public int totalPages { get; set; }
        public int currentPages {  get; set; }
    }
}
