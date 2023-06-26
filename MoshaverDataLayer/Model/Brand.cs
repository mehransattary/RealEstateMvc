using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.Model
{
    public  class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //_________________________________________________________________________
        [Required(ErrorMessage = "لطفا{0}راواردکنید")]
        [MaxLength(50, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        [Display(Name = "نام برند")]
        public string Name { get; set; }
        //_________________________________________________________________________
        [Display(Name = "انتخاب تصویر")]
        public string ImgPath { get; set; }
        //_________________________________________________________________________
    }
}
