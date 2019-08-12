using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels
{
    public class SupplyViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "供應商不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "供應商")]
        public string Name { get; set; }

        [Required(ErrorMessage = "連絡人不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "連絡人")]
        public string Contact_person { get; set; }

        [Display(Name = "連絡人職稱")]
        public int Title { get; set; }

        public List<Title> TitleList { get; set; }

        [Required(ErrorMessage = "地址不得為空白")]
        [MaxLength(300, ErrorMessage = "不可超過300個字元")]
        [Display(Name = "地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "郵遞區號不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "郵遞區號")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "電話不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "電話")]
        public string Telphone { get; set; }

        [Required(ErrorMessage = "傳真不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "傳真")]
        public string Fax { get; set; }

        [Display(Name = "建立時間")]
        public DateTime Creadedate { get; set; }
    }
}
