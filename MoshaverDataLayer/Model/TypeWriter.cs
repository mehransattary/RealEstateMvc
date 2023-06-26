using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.Model
{
    public  enum TypeWriter
    {
        [Display(Name = "مدیر")]
        مدیر =1,
               [Display(Name = "مشتزی")]
            مشتری =2
    }
}
