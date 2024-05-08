using Library.DataAccess.Repository.IRepository;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
	public class BorrowedBookController : Controller
    {
        private readonly IUnitOfWork _db;
        public BorrowedBookController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<BorrowedBooks> objBorrowedBookList = _db.BorrowedBookRepository.GetAll();
            return View(objBorrowedBookList);
           
        }

        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BorrowedBooks obj)
        {
            if(ModelState.IsValid)
            {
                _db.BorrowedBookRepository.Add(obj);
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

			var borrowedBookFromDb = _db.BorrowedBookRepository.Get(u => u.BorrowId == id);
			if (borrowedBookFromDb == null)
			{
				return NotFound();
			}
			return View(borrowedBookFromDb);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(BorrowedBooks obj)
		{
			if (ModelState.IsValid)
			{
				_db.BorrowedBookRepository.Update(obj);
				_db.Save();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
            var obj = _db.BorrowedBookRepository.Get(u => u.BorrowId == id);
            if (obj == null || id == 0)
            {
                return NotFound();
            }

            _db.BorrowedBookRepository.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}