using BookManagement.Models;
using BookManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<Book> repo;
        public BooksController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepo<Book>();
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
        public async Task<IActionResult> Create(Book book)
        {
            await this.repo.InsertAsync(book);
            bool saved = await this.unitOfWork.SaveAsync();
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Faled to saved data");
            }
            return View(book);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await repo.GetByIdAsync(x => x.BookId == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            await this.repo.UpdateAsync(book);
            bool saved = await this.unitOfWork.SaveAsync();
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Faled to saved data");
            }
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Book book, int? id)
        {
            await this.repo.DeleteAsync(x=> x.BookId == id);
            bool saved = await this.unitOfWork.SaveAsync();
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Faled to Delete data");
            }
            return View(book);
        }
    }
}
