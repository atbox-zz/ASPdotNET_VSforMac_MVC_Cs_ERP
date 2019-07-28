using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.ListAsync();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("create");
                //return BadRequest(ModelState);
            }

            await _departmentRepository.AddAsync(new Department
            {
                Name = model.Name,
                Createdate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var department = await _departmentRepository.GetByIdAsync(Id);

            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            await _departmentRepository.ModifiedAsync(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var department = await _departmentRepository.GetByIdAsync(Id);

            await _departmentRepository.RemoveAsync(department);

            return RedirectToAction("Index");
        }

    }
}
