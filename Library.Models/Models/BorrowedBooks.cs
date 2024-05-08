using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Model
{
	public class BorrowedBooks
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BorrowId { get; set; }
		public int MemberId { get; set; }
		public int BookId { get; set; }
		public DateTime BorrowDate { get; set; }
		public DateTime? ReturnDate { get; set; }
		public string? Status { get; set; }


		[ForeignKey("MemberId")]
        public Members? Members { get; set; }

		[ForeignKey("BookId")]
		public Books? Books { get; set; }
	}
}
