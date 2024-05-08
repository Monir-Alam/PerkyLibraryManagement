using Library.DataAccess.Repository.IRepository;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
	public class MemberController : Controller
    {
        private readonly IUnitOfWork _db;
        public MemberController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Members> objMembersList = _db.MemberRepository.GetAll();
            return View(objMembersList);
           
        }

        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Members obj)
        {
            if(ModelState.IsValid)
            {
                _db.MemberRepository.Add(obj);
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

			var membersFromDb = _db.MemberRepository.Get(u => u.MemberId == id);
			if (membersFromDb == null)
			{
				return NotFound();
			}
			return View(membersFromDb);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Members obj)
		{
			if (ModelState.IsValid)
			{
				_db.MemberRepository.Update(obj);
				_db.Save();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
            var obj = _db.MemberRepository.Get(u => u.MemberId == id);
            if (obj == null || id == 0)
            {
                return NotFound();
            }

            _db.MemberRepository.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}