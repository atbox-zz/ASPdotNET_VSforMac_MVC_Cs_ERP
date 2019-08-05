using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITitleRepository _titleRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, ITitleRepository titleRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _titleRepository = titleRepository;
            _departmentRepository = departmentRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageindex = 1)
        {
            //每頁十筆
            var pagesize = 10;

            var employees = _employeeRepository.PageList(pageindex, pagesize);

            ViewBag.PageCount = employees.Item2;

            ViewBag.PageIndex = pageindex;

            return View(employees.Item1);
        }

        public async Task<IActionResult> Add()
        {
            var titles = await _titleRepository.ListAsync();

            //取得職稱資料後送到前端
            ViewBag.Titles = titles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            var departments = await _departmentRepository.ListAsync();

            //取得部門資料後送到前端
            ViewBag.Department = departments.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            await _employeeRepository.AddAsync(new Employee
            {
                Name = model.Name,
                Ename = model.Ename,
                Address = model.Address,
                Telphone = model.Telphone,
                Salary = model.Salary,
                TitleId = model.Title,
                DepartmentId = model.Department,
                Createdate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Employee = await _employeeRepository.GetByIdAsync(Id);

            var employeeViewModel = new EmployeeViewModel();

            employeeViewModel.Id = Employee.Id;
            employeeViewModel.Name = Employee.Name;
            employeeViewModel.Ename = Employee.Ename;
            employeeViewModel.Address = Employee.Address;
            employeeViewModel.Telphone = Employee.Telphone;
            employeeViewModel.Salary = Employee.Salary;
            employeeViewModel.Title = Employee.TitleId;
            employeeViewModel.Department = Employee.DepartmentId;
            
            var titles = await _titleRepository.ListAsync();

            //取得職稱資料後送到前端
            ViewBag.Titles = titles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            var departments = await _departmentRepository.ListAsync();

            //取得部門資料後送到前端
            ViewBag.Department = departments.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View(employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employeeRepository.ModifiedAsync(
                new Employee
                {
                    Id = model.Id,
                    Name = model.Name,
                    Ename = model.Ename,
                    Address = model.Address,
                    Telphone = model.Telphone,
                    Salary = model.Salary,
                    Createdate = model.Createdate,
                    DepartmentId = model.Department,
                    TitleId = model.Title
                });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            var employee = await _employeeRepository.GetByIdAsync(Id);

            await _employeeRepository.RemoveAsync(employee);

            return RedirectToAction("Index");
        }
    }
}
