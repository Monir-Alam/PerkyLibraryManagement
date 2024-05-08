using Library.DataAccess.Repository.IRepository;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
	public class BookController : Controller
    {
        private readonly IUnitOfWork _db;
        public BookController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Books> objBookList = _db.BookRepository.GetAll();
            return View(objBookList);
           
        }

        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Books obj)
        {
            if(ModelState.IsValid)
            {
                _db.BookRepository.Add(obj);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var bookFromDb = _db.BookRepository.Get(u => u.BookId == id);
			if (bookFromDb == null)
			{
				return NotFound();
			}
			return View(bookFromDb);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Books obj)
		{
			if (ModelState.IsValid)
			{
				_db.BookRepository.Update(obj);
				_db.Save();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
            var obj = _db.BookRepository.Get(u => u.BookId == id);
            if (obj == null || id == 0)
            {
                return NotFound();
            }

            _db.BookRepository.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}