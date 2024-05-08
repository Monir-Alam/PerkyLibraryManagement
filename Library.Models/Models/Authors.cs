using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Model
{
	public class Authors
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorBio { get; set; }
    }
}
