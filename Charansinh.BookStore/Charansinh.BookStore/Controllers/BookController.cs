using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charansinh.BookStore.Models;
using Charansinh.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;


namespace Charansinh.BookStore.Controllers
{
 
    public class BookController : Controller
    {
        private readonly BookRepository _dataSource;

        public BookController(BookRepository bookRepository)
        {
            _dataSource = bookRepository;
        }

        
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _dataSource.GetAllBooks();
            return View(data);
        }
       
        
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _dataSource.GetBook(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string BookTitle, string BookAuthor)
        {
            return _dataSource.SearchBooks(BookTitle, BookAuthor);
        }

        public ViewResult AddNewBook(bool IsSuccess = false, int bookid=0)
        {
            var bookmodel = new BookModel()
            {
                //Language = "3"
            };

            //ViewBag.Language = LanguageList().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Value.ToString()
            //});
            //var group1 = new SelectListGroup() {Name="Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2" };
            //var group3 = new SelectListGroup() { Name = "Group3" };

            //ViewBag.Language = new List<SelectListItem>()
            //{ new SelectListItem{ Text="Gujarati", Value="1" ,Group=group1},
            //new SelectListItem{ Text="Hindi", Value="2",Group=group1},
            //new SelectListItem{ Text="Sanskrit", Value="3",Group=group2},
            //new SelectListItem{ Text="DevNaagri", Value="4",Group=group2 },
            //new SelectListItem{ Text="English", Value="5",Group=group3},
            //new SelectListItem{ Text="Marathi", Value="6",Group=group3}};
            
            ViewBag.IsSuccess = IsSuccess;
            ViewBag.BookId = bookid;
            return View(bookmodel);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _dataSource.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction("AddNewBook", new { IsSuccess = true, bookid = id });
                }
            }

            //var group1 = new SelectListGroup() { Name = "Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2" };
            //var group3 = new SelectListGroup() { Name = "Group3" };

            //ViewBag.Language = new List<SelectListItem>()
            //{ new SelectListItem{ Text="Gujarati", Value="1" ,Group=group1},
            //new SelectListItem{ Text="Hindi", Value="2",Group=group1},
            //new SelectListItem{ Text="Sanskrit", Value="3",Group=group2},
            //new SelectListItem{ Text="DevNaagri", Value="4",Group=group2 },
            //new SelectListItem{ Text="English", Value="5",Group=group3},
            //new SelectListItem{ Text="Marathi", Value="6",Group=group3}};

            //ViewBag.Language = LanguageList();
            //ViewBag.IsSuccess = false;
            //ViewBag.BookId = 0;
            //ModelState.AddModelError("", "Custom error Validation 1");
            //ModelState.AddModelError("", "Custom error Validation 2");
            return View();
        }
        private SelectList LanguageList()
        {
            return new SelectList(GetLanguageList(), "Id", "Text",2);
        }
        private List<LanguageModel> GetLanguageList()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel{Id=1,Text="Gujarati"},
                new LanguageModel{Id=2,Text="Hindi"},
                new LanguageModel{Id=3,Text="Sanskrit"},
                new LanguageModel{Id=4,Text="Devnaagri"},
                new LanguageModel{Id=5,Text="English"},
                new LanguageModel{Id=6,Text="Marathi"}
            };
        }
    }

}