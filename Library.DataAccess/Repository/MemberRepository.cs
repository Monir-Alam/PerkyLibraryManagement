using Library.DataAccess.Repository.IRepository;
using LibraryManagement.Data;
using LibraryManagement.Model;

namespace Library.DataAccess.Repository
{
	internal class MemberRepository : Repository<Members>, IMemberRepository
	{
		private AppDbContext _db;
		public MemberRepository(AppDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Members obj)
		{
			_db.members.Update(obj);
		}
	}
}