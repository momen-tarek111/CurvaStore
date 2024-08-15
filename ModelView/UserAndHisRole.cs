using CurvaStore.Models;
using Microsoft.AspNetCore.Identity;

namespace CurvaStore.ModelView
{
    public class UserAndHisRole
    {
        public CurvaUser ?User { get; set; }
        public List<string> ?roles { get; set; }
    }
}
