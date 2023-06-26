using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.Model
{
    public class UsualQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //___________________________________________________
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(50,ErrorMessage ="لطفا بیشتر ازحد مجاز کلمات راواردنکنید")]
        [Display(Name = "عنوان1")]   
        public string Title { get; set; }
        //___________________________________________________
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "متن1")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        //___________________________________________________
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(50, ErrorMessage = "لطفا بیشتر ازحد مجاز کلمات راواردنکنید")]
        [Display(Name = "عنوان2")]
        public string Title2 { get; set; }
        //___________________________________________________
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "متن2")]
        [DataType(DataType.MultilineText)]
        public string Text2 { get; set; }
        //___________________________________________________
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(50, ErrorMessage = "لطفا بیشتر ازحد مجاز کلمات راواردنکنید")]
        [Display(Name = "3عنوان")]
        public string Title3 { get; set; }
        //___________________________________________________
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "متن3")]
        [DataType(DataType.MultilineText)]
        public string Text3 { get; set; }
        //___________________________________________________



    }
}
