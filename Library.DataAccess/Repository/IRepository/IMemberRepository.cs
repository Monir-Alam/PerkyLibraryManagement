using LibraryManagement.Model;

namespace Library.DataAccess.Repository.IRepository
{
	public interface IMemberRepository : IRepository<Members>
	{
		void Update(Members obj);
	}
}