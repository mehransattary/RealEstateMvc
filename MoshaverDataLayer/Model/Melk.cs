using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MoshaverhAmlak.Classes;
using MoshaverhAmlak.Models;

namespace MoshaverDataLayer.Model
{

    public class Melk
    {
        public Melk()
        {
            string DateCreate = DateTime.Now.ToString().ToShamsi();
        
            string Date = DateCreate.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

            string year = (Date.Substring(0, 4));
            string Month = (Date.Substring(5, 2));
            string Day = (Date.Substring(8, 2));
            string datem=year + "/" + Month + "/" + Day;
            this.DateCreate = datem;



        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "شهر")]
        public int cityId { get; set; }
        //_________________________________________________________________________________

        [Display(Name = "  تصویر")]
        [MaxLength(300, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string ImgL { get; set; }
        //_________________________________________________________________________________
        [Display(Name = "تصویر")]
        [MaxLength(300, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string ImgS { get; set; }
        //_________________________________________________________________________________
        [Display(Name = "تصویر")]
        [MaxLength(300, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string ImgB { get; set; }
        //_________________________________________________________________________________
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]

        [Display(Name = "آدرس")]
        [DataType(DataType.MultilineText)]
        public string addressId { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "نوع مشتری")]
        public int typecustumerId { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "امکانات")]
        public string typeEmkanatId { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "نوع قرارداد")]
        public int typeGardadId { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "محدوده")]
        public int typeMahdodeId { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "نوع ملک")]
        public int typeMelkId { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "نوع سند")]
        public int typeSanadId { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "متراژ")]
        public int Meter { get; set; }
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "قیمت هرمتر")]
        public double PriceMeter { get; set; }

        [Display(Name = "موقعیت مکانی")]
        [MaxLength(50, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شود")]
        public string locationSN { get; set; }
        [Display(Name = "نوع اسکلت")]
        [MaxLength(50, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شود")]
        public string TypeEskelet { get; set; }
        [Display(Name = "قدمت ساخاتمان")]
        public int GedmatSakht { get; set; }
        [Display(Name = "زیربنا ")]
        public int Zirbana { get; set; }
        [Display(Name = "تعداد طبقات ")]
        public int CountTabagat { get; set; }
        [Display(Name = "شماره طبقه ")]
        public int NumberTabage { get; set; }
        [Display(Name = "واحد طبقه ")]
        public int NumberVahed { get; set; }
        [Display(Name = "قیمت کل ")]
        public double PriceAll { get; set; }
        [Display(Name = "تاریخ ایجاد ")]
        public string DateCreate { get; set; }
         [Display(Name = "املاک ویژه ")]
        public bool SpecialAmlak { get; set; }
        [Display(Name = "اتعداداتاق ")]
        public int Rooms { get; set; }
        [Display(Name = "تعداد سرویس ")]
        public int Wc { get; set; }
        [Display(Name = "نمایش ")]
        public bool IsShow { get; set; }
        [Display(Name = "نوع ثبت کننده ")]
        public int typeWriter { get; set; }
        [Display(Name = "نام کاربر ")]
        public string userId { get; set; }

        //[ForeignKey("userId")]
        //public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("cityId")]
        public virtual City city { get; set; }
   
        [ForeignKey("typecustumerId")]
        public virtual TypeCustumer typeCustumer { get; set; }
  
        [ForeignKey("typeGardadId")]
        public virtual TypeGardad typeGardad { get; set; }
        [ForeignKey("typeMahdodeId")]
        public virtual TypeMahdode typeMahdode { get; set; }
        [ForeignKey("typeMelkId")]
        public virtual TypeMelk typeMelk { get; set; }
        [ForeignKey("typeSanadId")]
        public virtual TypeSanad typeSanad { get; set; }

       
     
    }

}