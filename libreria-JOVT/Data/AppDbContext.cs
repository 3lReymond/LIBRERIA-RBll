using libreria_JOVT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace libreria_JOVT.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(B => B.book)
                .WithMany(ba => ba.book_Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(B => B.Author)
                .WithMany(ba => ba.book_Authors)
                .HasForeignKey(bi => bi.AuthorId);
        }
        //utilizamos este metodo para obtener y enviar datos a la BD
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
}
