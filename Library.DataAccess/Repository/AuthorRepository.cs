using Library.DataAccess.Repository.IRepository;
using LibraryManagement.Data;
using LibraryManagement.Model;

namespace Library.DataAccess.Repository
{
    public class AuthorRepository : Repository<Authors>, IAuthorRepository
    {
        private AppDbContext _db;
        public AuthorRepository(AppDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Authors obj)
        {
            _db.authors.Update(obj);
        }
    }
}