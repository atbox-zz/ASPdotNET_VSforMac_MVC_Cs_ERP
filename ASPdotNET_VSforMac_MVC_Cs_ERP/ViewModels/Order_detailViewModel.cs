using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels
{
    public class Order_detailViewModel
    {
        public int Id { get; set; }

        [Display(Name = "訂單號碼")]
        public int Order_master { get; set; }
        public List<Order_master> Order_masterList { get; set; }

        [Display(Name = "產品編號")]
        public int Product_data { get; set; }
        public List<Product_data> Product_dataList { get; set; }

        [Required(ErrorMessage = "單價不得為空白")]
        [Display(Name = "單價")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "數量不得為空白")]
        [Display(Name = "數量")]
        public decimal Quality { get; set; }

        [Display(Name = "建立時間")]
        public DateTime Createdate { get; set; }
    }
}
