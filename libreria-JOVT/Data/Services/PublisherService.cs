using libreria_JOVT.Data.Models;
using libreria_JOVT.Data.ViewModels;
using System.Linq;

namespace libreria_JOVT.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        //metodo para que nos permita agregar un nuevo editor a la BD
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Titulo,
                    BookAuthors = n.book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
            return _publisherData;
        }
    }
}
