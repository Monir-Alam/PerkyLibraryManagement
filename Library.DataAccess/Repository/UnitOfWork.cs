using Library.DataAccess.Repository.IRepository;
using LibraryManagement.Data;
using LibraryManagement.Model;

namespace Library.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _db;
		public UnitOfWork(AppDbContext db)
		{
			_db = db;

			AuthorRepository = new AuthorRepository(_db);
			BookRepository = new BookRepository(_db);
			BorrowedBookRepository = new BorrowedBookRepository(_db);
			MemberRepository = new MemberRepository(_db);
		}


		public IAuthorRepository AuthorRepository { get; private set; }

		public IBookRepository BookRepository { get; private set; }

		public IBorrowedBookRepository BorrowedBookRepository { get; private set; }

		public IMemberRepository MemberRepository { get; private set; }

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}