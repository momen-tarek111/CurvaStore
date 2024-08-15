using CurvaStore.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurvaStore.ModelView
{
	public class Editprofile
	{
		[Required]
		public string ?FullName { get; set; }
		[Required]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		public string ?Email { get; set; }
		[Required]
		[DataType (DataType.PhoneNumber)]
		public string ?PhoneNumber { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		[dateval]
		public DateTime date {  get; set; }
		[Required]
		public string ?gender {  get; set; }
        [NotMapped]
        public IFormFile? UserImage { get; set; }
        public string? Img { get; set; }

    }
}
