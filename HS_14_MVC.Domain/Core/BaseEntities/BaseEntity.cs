using HS_14_MVC.Domain.Core.Interfaces;
using HS_14_MVC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Core.BaseEntities
{
    public class BaseEntity : IUpdatebleEntity
    {
        public string? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Status Status { get; set; }
    }
}
