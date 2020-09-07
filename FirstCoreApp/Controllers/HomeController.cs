using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreApp.Data;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IBookRepository repository;
        
        public HomeController(IBookRepository repository)
        {
            this.repository = repository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var books = repository.GetBooks();

            ViewBag.Message = "Book List";
            ViewData["Count"] = books.Count;

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = repository.GetBook(id);

            if (book == null)
            {
                return View("BookNotFound", id);
            }

            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.AddBook(book);
                ViewBag.IsAdded = true;
            }
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult GetData()
        {
            throw new Exception("Some Exception");
        }

        public IActionResult Delete(int? id)
        {
            var book = repository.GetBook(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = repository.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
