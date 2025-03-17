using HS_14_MVC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Core.Interfaces
{
    //IEntity arayüzü, tüm varlıkların ortak özelliklerini tanımlayarak bir standart oluşturur.
    //Bu sayede uygulamanızda varlıklar arası tutarlılık sağlanır ve bağımlılıklar daha esnek bir şekilde yönetilebilir.
    //Ayrıca, arayüzlerin kullanımı uygulamanın test edilebilirliğini artırır ve SOLID prensiplerine uygun bir yapı oluşturur.
    public interface IEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

    }
}
