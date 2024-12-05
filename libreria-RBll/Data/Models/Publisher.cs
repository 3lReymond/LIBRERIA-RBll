using System.Collections.Generic;

namespace libreria_RBll.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //propiedades de navegacion
        public List<Book> Books { get; set; }
    }
}
