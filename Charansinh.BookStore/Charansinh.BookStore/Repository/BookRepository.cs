using Charansinh.BookStore.Data;
using Charansinh.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charansinh.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreDbContext bookStoreDbContext;

        public BookRepository(BookStoreDbContext bookStoreDbContext)
        {
            this.bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var NewBook = new Books()
            {
                Author = bookModel.Author,
                Title = bookModel.Title,
                Description = bookModel.Description,
                Language = bookModel.Language,
                TotalPages = bookModel.TotalPages.HasValue ? bookModel.TotalPages.Value : 0,
                CreatedOn = DateTime.UtcNow
            };
            await bookStoreDbContext.Books.AddAsync(NewBook);
            await bookStoreDbContext.SaveChangesAsync();

            return NewBook.ID;
        }
        private List<BookModel> dataSource()
        {
            return new List<BookModel>() {
            new BookModel(){ ID=1,Title="C#",Author="Charan", Description="This is C# book description.", Category="Programming",Language="English",TotalPages=324},
            new BookModel(){ ID=2,Title="VB",Author="Rudra", Description="This is VB book description.", Category="Programming",Language="Hindi",TotalPages=435},
            new BookModel(){ ID=3,Title="Dot Net Core",Author="Rudra", Description="This is Dot Net Core book description.", Category="Technology",Language="English",TotalPages=151},
            new BookModel(){ ID=4,Title="Entity Framework",Author="XYZ", Description="This is Entity Framework book description.", Category="Framework",Language="Gujarati",TotalPages=251},
            new BookModel(){ ID=5,Title="Web API",Author="Charansinh", Description="This is Web API book description.", Category="Web",Language="Punjabi",TotalPages=123},
            new BookModel(){ ID=6,Title="gRPC",Author="Rudrapratap", Description="This is gRPC book description.", Category="Communication",Language="English",TotalPages=456}
            };
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            List<BookModel> books = new List<BookModel>();
            var AllBooks = await bookStoreDbContext.Books.ToListAsync();
            if (AllBooks?.Any() == true)
            {
                foreach (var book in AllBooks)
                {
                    books.Add(
                        new BookModel()
                        {
                            Author = book.Author,
                            Title = book.Title,
                            ID = book.ID,
                            Description = book.Description,
                            TotalPages = book.TotalPages,
                            Category = book.Category,
                            Language = book.Language
                        });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBook(int id)
        {
            var book = await bookStoreDbContext.Books.FindAsync(id);
            if (book != null)
            {
                var bookdetail = new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    ID = book.ID,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    Category = book.Category,
                    Language = book.Language
                };

                return bookdetail;
            }
            return null;
        }
        public List<BookModel> SearchBooks(string BookTitle, string BookAuthor)
        {
            return dataSource().Where(x => x.Title.Contains(BookTitle) || x.Author.Contains(BookAuthor)).ToList();
        }

        
    }
}
