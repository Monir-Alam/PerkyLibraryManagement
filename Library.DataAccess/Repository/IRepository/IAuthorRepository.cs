using LibraryManagement.Model;

namespace Library.DataAccess.Repository.IRepository
{
	public interface IAuthorRepository : IRepository<Authors>
    {
		void Update(Authors obj);
	}
}
