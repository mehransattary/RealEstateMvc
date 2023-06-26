using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.Model
{
    public class ItemMenu
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "مربوط به زیرمنو")]
        public int ZirmenuId { get; set; }
        //________________________________________________________
        [Display(Name = "نام آیتم")]
        public string ItemName { get; set; }
        //________________________________________________________
        [Display(Name = "ای دی آیتم")]
        public int? ItemNameId { get; set; }

        //________________________________________________________
        [Display(Name = "ترتیب نمایش")]
        public int Order { get; set; }
        //________________________________________________________

        [ForeignKey("ZirmenuId")]
        public virtual ZirMenu ZirMenu { get; set; }
        //________________________________________________________
     
    }
}
