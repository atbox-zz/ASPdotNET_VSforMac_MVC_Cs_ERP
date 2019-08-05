using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "員工姓名不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "員工姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "員工英文姓名不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "員工英文姓名")]
        public string Ename { get; set; }

        [Required(ErrorMessage = "員工地址不得為空白")]
        [MaxLength(300, ErrorMessage = "不可超過300個字元")]
        [Display(Name = "員工地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "員工電話不得為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "員工電話")]
        public string Telphone { get; set; }

        [Required(ErrorMessage = "員工薪資不得為空白")]
        [Display(Name = "員工薪資")]
        public decimal Salary { get; set; }

        [Display(Name = "建立時間")]
        public DateTime Createdate { get; set; }

        [Display(Name = "部門")]
        public int Department { get; set; }

        public List<Department> DepartmentList { get; set; }

        [Display(Name = "職稱")]
        public int Title { get; set; }

        public List<Title> TitleList { get; set; }
    }
}
