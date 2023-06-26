using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoshaverhAmlak.Classes;
namespace MoshaverDataLayer.Model
{
    public class Comment
    {
        public Comment()
        {
            string DateCreate = DateTime.Now.ToString().ToShamsi();

            string Date = DateCreate.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

            string year = (Date.Substring(0, 4));
            string Month = (Date.Substring(5, 2));
            string Day = (Date.Substring(8, 2));
            string datem = year + "/" + Month + "/" + Day;
            this.Date = datem;
        }
        [Key]
        public int Id { get; set; }
        public int MelkId { get; set; }
        public int? ParentId { get; set; }
        //______________________________________________________________________
        [Required(ErrorMessage = "لطفا{0}راواردکنید")]
        [MaxLength(20, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شود")]
        [Display(Name = "نام")]
        public string Name { get; set; }
        //______________________________________________________________________
        [Required(ErrorMessage = "لطفا{0}راواردکنید")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل شما نادرست است")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "ایمیل شما نادرست است")]
        public string Email { get; set; }
        //______________________________________________________________________
        [Required(ErrorMessage = "لطفا{0}راواردکنید")]
        [Display(Name = "متن نظر")]
        [DataType(DataType.MultilineText)]
        public string TextComment { get; set; }
        //______________________________________________________________________      
        [Display(Name = "تاریخ ایجاد")]
        public string Date { get; set; }
        //______________________________________________________________________ 
        [Display(Name = "فعال")]
        public bool IsShow { get; set; }
        //______________________________________________________________________ 
        [Display(Name = "پاسخ داده شده")]
        public bool OkAnswer { get; set; }
        //______________________________________________________________________
        [Display(Name = "ترتیب")]
        public int Order { get; set; }
        //______________________________________________________________________
        [ForeignKey("MelkId")]
        public virtual Melk melk { get; set; }
        [ForeignKey("ParentId")]
        public virtual Comment Parent { get; set; }
    }
}
