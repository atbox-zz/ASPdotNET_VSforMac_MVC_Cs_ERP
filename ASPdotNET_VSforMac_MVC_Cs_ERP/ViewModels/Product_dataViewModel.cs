using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels
{
    public class Product_dataViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "產品不得為空的")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "產品")]
        public string Name { get; set; }

        [Display(Name = "供應商")]
        public int Supply { get; set; }
        public List<Supply> SupplyList { get; set; }

        [Display(Name = "產品類別")]
        public int Product_item { get; set; }
        public List<Product_item> Product_itemList { get; set; }

        [Required(ErrorMessage = "單位數量不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "單位數量")]
        public string Unit_quality { get; set; }

        [Required(ErrorMessage = "單價不得空白")]
        [Display(Name = "單價")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "庫存量不得空白")]
        [Display(Name = "庫存量")]
        public decimal Stock_quality { get; set; }

        [Required(ErrorMessage = "已訂購量不得空白")]
        [Display(Name = "已訂購量")]
        public decimal Order_quality { get; set; }

        [Required(ErrorMessage = "安全存量不得為空白")]
        [Display(Name = "安全存量")]
        public decimal Safe_quality { get; set; }

        [Display(Name = "建立時間")]
        public DateTime Createdate { get; set; }
    }
}
