using System.Collections.Generic;

namespace libreria_JOVT.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        //propiedades de navegacion
        public List<Book_Author> book_Authors { get; set; }
    }
}
