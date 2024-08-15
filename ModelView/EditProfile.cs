using CurvaStore.Validation;
using System.ComponentModel.DataAnnotations;

namespace CurvaStore.ModelView
{
	public class EditProfile
	{
		[Required]
		public string FullName { get; set; }
		[Required]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType (DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }
		[Required]
		[DataType(DataType.Date)]
		[dateval]
		public DateOnly date {  get; set; }
		[Required]
		public string gender {  get; set; }

	}
}
