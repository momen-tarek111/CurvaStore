using Microsoft.AspNetCore.Identity;

namespace CurvaStore.Models
{
    public class CurvaUser:IdentityUser
    {
        public string ?FullName { get; set; }
        public string ?Gender { get; set; }
        public DateOnly ?date { get; set; }

    }
}
