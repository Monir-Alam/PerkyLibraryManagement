using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Model
{
	public class Books
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
        public int AvailabeCopies { get; set; }
        public int TotalCopies { get; set; }

		[ForeignKey("AuthorId")]
		public Authors? Authors { get; set; }
	}
}
