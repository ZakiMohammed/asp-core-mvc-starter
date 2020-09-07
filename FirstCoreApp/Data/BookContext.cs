using FirstCoreApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Data
{
    public class BookContext : IdentityDbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData
                (
                    new Book { Id = 1, Title = "Harry Potter 1", Author = "JK Rowling", Description = "Nonumy mazim magna eum duis id dolore tempor vero eirmod sed dolor at aliquyam ullamcorper justo duo duo takimata labore amet nihil eos eirmod elitr sed eu augue nonumy elitr eu ut lorem eos velit ea facilisi lorem justo autem eu stet consectetuer justo et ea invidunt vero amet lorem", Language = Language.English },
                    new Book { Id = 2, Title = "IT", Author = "Stephen King", Description = "Iriure doming gubergren exerci tempor quis justo in nobis exerci diam iusto dolor labore velit takimata dolor invidunt dolor vel aliquyam rebum rebum dolor ea lorem ea lorem consequat diam nonumy vel clita invidunt dolore eirmod at voluptua invidunt at erat aliquyam accusam erat tempor consetetur eos autem congue luptatum", Language = Language.German }
                );
        }
    }
}
