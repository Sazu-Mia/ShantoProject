using BookManagement.Models;
using BookManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Controllers
{
    public class BorrowedBooksController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<BorrowedBook> repo;
        public BorrowedBooksController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepo<BorrowedBook>();
        }
        public async Task<IActionResult> Index()
        {
            var data = await repo.GetAllAsync(x=> x.Include(x=> x.Member).Include(y=> y.Book));
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BorrowedBook book)
        {
            return View(book);
        }
    }
}
