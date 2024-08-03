using CurvaStore.Models;
using Microsoft.AspNetCore.Identity;

namespace CurvaStore.ModelView
{
    public class DashBoardHomeModelView
    {
        public int numberOFProducts { get; set; }
        public int numberOfBlogs { get; set; }
        public int numberOfUsers { get; set; }
        public List<UserAndHisRole>? users = new List<UserAndHisRole>() { };
    }
}
