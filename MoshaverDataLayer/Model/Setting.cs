using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace MoshaverDataLayer.Model
{
     public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "نام املاک")]
        [Required(ErrorMessage = "لطفا{0}راواردکنید")]
        [MaxLength(50, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string NameStore { get; set; }
        [Display(Name = "آدرس 1")]
        [MaxLength(60, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string AddressStore1 { get; set; }
        [Display(Name = "آدرس 2")]
        [MaxLength(60, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string AddressStore2 { get; set; }
        [Display(Name = "ایمیل 1")]
        [MaxLength(30, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string EmailStore1 { get; set; }
        [Display(Name = "ایمیل2")]
        [MaxLength(30, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string EmailStore2 { get; set; }
        [Display(Name = "تلفن1")]
        [MaxLength(20, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string TellPhone1 { get; set; }
        [Display(Name = "تلفن2")]
        [MaxLength(20, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string TellPhone2 { get; set; }

        [Display(Name = "آدرس پستی")]
        [MaxLength(20, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string addressPosti { get; set; }
        [Display(Name = "زمان کار")]
        [MaxLength(60, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string WorkTime { get; set; }
        [Display(Name = "درباره ما")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string AboutMe { get; set; }
        [Display(Name = "عکس برند فوتر")]
        public string imageSrc { get; set; }
            
    }
}
