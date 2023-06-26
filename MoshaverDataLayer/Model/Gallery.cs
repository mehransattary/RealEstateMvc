using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.Model
{
    public class Gallery
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //____________________________________________________________________

        public int MelkId { get; set; }
        //____________________________________________________________________

        [Display(Name = "  تصویر گالری")]
        [MaxLength(300, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string ImgGalleryL { get; set; }
        //____________________________________________________________________
        [Display(Name = "  تصویر گالری")]
        [MaxLength(300, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string ImgGalleryS { get; set; }
        //____________________________________________________________________

        [Display(Name = "تصویر گالری ")]
        [MaxLength(300, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string ImgGalleryB { get; set; }
        //____________________________________________________________________

        [ForeignKey("MelkId")]
        public virtual Melk Melk { get; set; }
    }
}
