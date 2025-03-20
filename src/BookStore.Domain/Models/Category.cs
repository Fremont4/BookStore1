using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class Category: Entity
    {
        public string Name { get; set; }
        //EF Core will automatically create a foreign key for this property
        //EF relation. One to many
        public IEnumerable<Book> Books { get; set; }
    }
}
