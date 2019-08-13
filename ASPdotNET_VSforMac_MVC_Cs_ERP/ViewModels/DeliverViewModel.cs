using System;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels
{
    public class DeliverViewModel
    {
        [Display(Name = "貨運公司編號")]
        public int Id { get; set; }

        [Required(ErrorMessage = "貨運公司名稱不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "貨運公司名稱")]
        public string Name { get; set; }

        [Required(ErrorMessage = "連絡人不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "連絡人")]
        public string Contact_person { get; set; }

        [Required(ErrorMessage = "電話不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "電話")]
        public string Telphone { get; set; }

        [Display(Name = "建立時間")]
        public DateTime Createdate { get; set; }
    }
}
