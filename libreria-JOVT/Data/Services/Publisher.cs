using libreria_JOVT.Data.Models;
using libreria_JOVT.Data.ViewModels;

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
    }
}
