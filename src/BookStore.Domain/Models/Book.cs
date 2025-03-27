using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class Book: Entity
    {
        //public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime PublishDate { get; set; }

        //Ef Relation
        public Category Category { get; set; }
    }
}
