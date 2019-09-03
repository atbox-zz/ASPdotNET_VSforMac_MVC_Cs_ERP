using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels
{
    public class Order_masterViewModel
    {

        public int Id { get; set; }

        [Display(Name = "客戶公司名稱")]
        public int Custom { get; set; }

        public List<Custom> CustomList { get; set; }

        [Required(ErrorMessage = "訂單日期不得為空白")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "訂單日期")]
        public DateTime Orderdate { get; set; }

        [Required(ErrorMessage = "送貨日期不得為空白")]
        [Display(Name = "送貨日期")]
        public DateTime Deliverydate { get; set; }

        [Display(Name = "貨運公司名稱")]
        public int Deliver { get; set; }

        public List<Deliver> DeliverList { get; set; }

        [Required(ErrorMessage = "運費不得為空白")]
        [Display(Name = "運費")]
        public decimal Charges { get; set; }

        [Required(ErrorMessage = "收貨人不得為空白")]
        [MaxLength(100, ErrorMessage = "不得超過100個字完")]
        [Display(Name = "收貨人")]
        public string Receiver { get; set; }

        [Required(ErrorMessage = "地址不得為空白")]
        [MaxLength(300, ErrorMessage = "不得超過300個字元")]
        [Display(Name = "地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "郵遞區號不得為空白")]
        [MaxLength(100, ErrorMessage = "不得超過100個字元")]
        [Display(Name = "郵遞區號")]
        public string Postcode { get; set; }

        [Display(Name = "員工姓名")]
        public int Employee { get; set; }

        public List<Employee> EmployeeList { get; set; }

        [Display(Name = "建立時間")]
        public DateTime Createdate { get; set; }
    }
}
