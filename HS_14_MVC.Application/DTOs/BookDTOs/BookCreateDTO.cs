using HS_14_MVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.DTOs.BookDTOs
{
    public class BookCreateDTO
    {
        public string Name { get; set; }
        public DateTime DateOfPublish { get; set; }
        public bool IsAvailable { get; set; }

        public Guid CategoryId { get; set; }    
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
 
    }
}
