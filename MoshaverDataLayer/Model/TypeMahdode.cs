using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MoshaverDataLayer.Model
{
    public class TypeMahdode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا{0}راواردکنید")]
        [Display(Name = "محدوده")]
        [MaxLength(50, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شود")]
        public string typemahdodename { get; set; }
    }
}
