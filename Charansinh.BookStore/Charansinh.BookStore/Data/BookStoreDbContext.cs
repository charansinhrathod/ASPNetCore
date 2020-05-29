using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charansinh.BookStore.Data
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Books> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=TTI436-VM;database=Test;uid=sa;password=Tti@1234;");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
