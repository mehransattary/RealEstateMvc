using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.Model
{
    public   class ZirMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "مربوط به منو")]
        public int MenuId { get; set; }

        //________________________________________________________
        [Display(Name = " نام زیرمنو ")]
        public string zirMenuName { get; set; }
        //________________________________________________________
        [Display(Name = " ای دی زیرمنو ")]
        public int? zirMenuNameId { get; set; }

        //________________________________________________________
        [Display(Name = "ترتیب نمایش")]
        public int Order { get; set; }
        //________________________________________________________
        [Display(Name = "وجودآیتم")]
        public bool Isitems { get; set; }
        //_________________________________________________________________________________
        [ForeignKey("MenuId")]
        public virtual Menu menu { get; set; }
 
    }
}
