using LibraryManagement.Model;

namespace Library.DataAccess.Repository.IRepository
{
	public interface IBookRepository : IRepository<Books>
	{
		void Update(Books obj);
	}
}
