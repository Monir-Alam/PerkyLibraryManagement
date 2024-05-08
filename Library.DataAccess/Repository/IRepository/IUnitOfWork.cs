namespace Library.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IAuthorRepository AuthorRepository { get; }
		IBookRepository BookRepository { get; }
		IBorrowedBookRepository BorrowedBookRepository { get; }
		IMemberRepository MemberRepository { get; }

		void Save();
	}
}
