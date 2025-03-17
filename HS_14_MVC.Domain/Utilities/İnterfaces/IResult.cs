using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Domain.Utilities.İnterfaces
{
    //IResult arayüzü, başarılı veya başarısız bir işlem sonucunu temsil eder.
    public interface IResult
    {
        //IsSuccess özelliği, işlemin başarılı olup olmadığını belirtir (true/false).
        public bool IsSuccess { get; }
        //Messages özelliği, işlem sonucuyla ilgili bilgilendirici mesajları içerir.
        public string Messages { get; }
    }
}
