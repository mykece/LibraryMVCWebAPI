using HS_14_MVC.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Entities
{
    public class Category: AuditableEntity
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        public string Name { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }
}
