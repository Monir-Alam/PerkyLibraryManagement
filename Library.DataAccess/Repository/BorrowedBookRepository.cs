using Library.DataAccess.Repository.IRepository;
using LibraryManagement.Data;
using LibraryManagement.Model;

namespace Library.DataAccess.Repository
{
	internal class BorrowedBookRepository : Repository<BorrowedBooks>, IBorrowedBookRepository
	{
		private AppDbContext _db;
		public BorrowedBookRepository(AppDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(BorrowedBooks obj)
		{
			_db.borrowedBooks.Update(obj);
		}
	}
}