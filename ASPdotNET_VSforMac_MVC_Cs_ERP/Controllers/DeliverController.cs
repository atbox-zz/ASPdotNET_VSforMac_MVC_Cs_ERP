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
    public class DeliverController : Controller
    {
        private readonly IDeliverRepository _deliverRepository;

        public DeliverController(IDeliverRepository deliverRepository)
        {
            _deliverRepository = deliverRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageindex = 1)
        {
            //每頁十筆
            var pagesize = 10;

            var delivers = _deliverRepository.PageList(pageindex, pagesize);

            ViewBag.PageCount = delivers.Item2;

            ViewBag.PageIndex = pageindex;

            return View(delivers.Item1);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DeliverViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            await _deliverRepository.AddAsync(new Deliver
            {
                Name = model.Name,
                Contact_person = model.Contact_person,
                Telphone = model.Telphone,
                Createdate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Deliver = await _deliverRepository.GetByIdAsync(Id);

            var deliverViewModel = new SupplyViewModel();

            deliverViewModel.Id = Deliver.Id;
            deliverViewModel.Name = Deliver.Name;
            deliverViewModel.Contact_person = Deliver.Contact_person;
            deliverViewModel.Telphone = Deliver.Telphone;

            return View(deliverViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DeliverViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _deliverRepository.ModifiedAsync(
                new Deliver
                {
                    Id = model.Id,
                    Name = model.Name,
                    Contact_person = model.Contact_person,
                    Telphone = model.Telphone,
                    Createdate = model.Createdate
                });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            var deliver = await _deliverRepository.GetByIdAsync(Id);

            await _deliverRepository.RemoveAsync(deliver);

            return RedirectToAction("Index");
        }
    }
}
