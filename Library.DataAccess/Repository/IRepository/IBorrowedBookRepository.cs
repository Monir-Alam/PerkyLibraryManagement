using LibraryManagement.Model;

namespace Library.DataAccess.Repository.IRepository
{
	public interface IBorrowedBookRepository : IRepository<BorrowedBooks>
	{
		void Update(BorrowedBooks obj);
	}
}
