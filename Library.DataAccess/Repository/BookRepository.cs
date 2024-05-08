using Library.DataAccess.Repository.IRepository;
using LibraryManagement.Data;
using LibraryManagement.Model;

namespace Library.DataAccess.Repository
{
	internal class BookRepository : Repository<Books>, IBookRepository
	{
		private AppDbContext _db;
		public BookRepository(AppDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Books obj)
		{
			_db.books.Update(obj);
		}
	}
}
