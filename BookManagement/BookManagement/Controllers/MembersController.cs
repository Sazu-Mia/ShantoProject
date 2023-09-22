using BookManagement.Models;
using BookManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class MembersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<Member> repo;
        public MembersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepo<Member>();
        }
        public async Task<IActionResult> Index()
        {
            var data = await repo.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            await this.repo.InsertAsync(member);
            bool saved = await this.unitOfWork.SaveAsync();
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Faled to saved data");
            }
            return View(member);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await repo.GetByIdAsync(x => x.MemberId == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Member member)
        {
            await this.repo.UpdateAsync(member);
            bool saved = await this.unitOfWork.SaveAsync();
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Faled to saved data");
            }
            return View(member);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Member member, int? id)
        {
            await this.repo.DeleteAsync(x => x.MemberId == id);
            bool saved = await this.unitOfWork.SaveAsync();
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Faled to Delete data");
            }
            return View(member);
        }
    }
}
