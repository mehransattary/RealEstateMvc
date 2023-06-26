using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MoshaverDataLayer.Model
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //_________________________________________________________________________________
        [Required(ErrorMessage = "لطفا{0}راواردکنید")]
        [MaxLength(20, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        [Display(Name = "نام منو")]
        public string MenuName { get; set; }
        //_________________________________________________________________________________


        [Display(Name = "ترتیب نمایش")]
        public int MenuOrder { get; set; }

        //_________________________________________________________________________________
  
    

        [Display(Name = "وجودزیرمنو")]
        public bool IsMenuItems { get; set; }
        //_________________________________________________________________________________
    




    }
   
}
