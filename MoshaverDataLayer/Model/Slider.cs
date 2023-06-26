using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.Model
{
    public  class Slider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //___________________________________________________________________
   
        [Display(Name = "محل ذخیره عکس")]
        public string SliderIMG { get; set; }
        //___________________________________________________________________
        [Display(Name = "ملک")]
        public int MelkId { get; set; }
    }
}
