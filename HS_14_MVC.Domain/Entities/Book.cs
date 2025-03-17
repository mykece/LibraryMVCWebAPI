using HS_14_MVC.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Entities
{
    public class Book: AuditableEntity
    {
        public string Name { get; set; }
        public DateTime DateOfPublish { get; set; }
        public bool IsAvailable { get; set; }

        //Nav prop

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public Guid PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
