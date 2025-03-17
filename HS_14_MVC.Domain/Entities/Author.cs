using HS_14_MVC.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Entities
{
    public class Author: AuditableEntity
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        // NAV PROP
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
