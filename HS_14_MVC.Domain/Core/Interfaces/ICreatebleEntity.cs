using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Core.Interfaces
{
    //ICreatebleEntity arayüzü, varlıkların yaratılma bilgilerini standartlaştırarak uygulamanızdaki veri tutarlılığını ve yönetilebilirliğini artırır.
    //IEntity arayüzünden türediği için, temel kimlik ve durum bilgilerini de içerir.
    //Bu arayüz, SOLID prensiplerine uygun olarak tasarlanmıştır ve varlıkların genişletilmesine olanak tanır.
    public interface ICreatebleEntity : IEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
