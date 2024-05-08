using Library.DataAccess.Repository.IRepository;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
	public class AuthorController : Controller
    {
        private readonly IUnitOfWork _db;
        public AuthorController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Authors> objauthorList = _db.AuthorRepository.GetAll();
            return View(objauthorList);
           
        }

        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Authors obj)
        {
            if(ModelState.IsValid)
            {
                _db.AuthorRepository.Add(obj);
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

			var authorFromDb = _db.AuthorRepository.Get(u => u.AuthorId == id);
			if (authorFromDb == null)
			{
				return NotFound();
			}
			return View(authorFromDb);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Authors obj)
		{
			if (ModelState.IsValid)
			{
				_db.AuthorRepository.Update(obj);
				_db.Save();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
            var obj = _db.AuthorRepository.Get(u => u.AuthorId == id);
            if (obj == null || id == 0)
            {
                return NotFound();
            }

            _db.AuthorRepository.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}