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
    public class SupplyController : Controller
    {
        private readonly ISupplyRepository _supplyRepository;
        private readonly ITitleRepository _titleRepository;

        public SupplyController(ISupplyRepository supplyRepository, ITitleRepository titleRepository)
        {
            _supplyRepository = supplyRepository;
            _titleRepository = titleRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageindex = 1)
        {
            //每頁十筆
            var pagesize = 10;

            var supplies = _supplyRepository.PageList(pageindex, pagesize);

            ViewBag.PageCount = supplies.Item2;

            ViewBag.PageIndex = pageindex;

            return View(supplies.Item1);
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

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            await _supplyRepository.AddAsync(new Supply
            {
                Name = model.Name,
                Contact_person = model.Contact_person,
                TitleId = model.Title,
                Address = model.Address,
                Postcode = model.Postcode,
                Telphone = model.Telphone,
                Fax = model.Fax,
                Creadedate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Supply = await _supplyRepository.GetByIdAsync(Id);

            var supplyViewModel = new SupplyViewModel();

            supplyViewModel.Id = Supply.Id;
            supplyViewModel.Name = Supply.Name;
            supplyViewModel.Contact_person = Supply.Contact_person;
            supplyViewModel.Title = Supply.TitleId;
            supplyViewModel.Address = Supply.Address;
            supplyViewModel.Postcode = Supply.Postcode;
            supplyViewModel.Telphone = Supply.Telphone;
            supplyViewModel.Fax = Supply.Fax;

            var titles = await _titleRepository.ListAsync();

            //取得職稱資料後送到前端
            ViewBag.Titles = titles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View(supplyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupplyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _supplyRepository.ModifiedAsync(
                new Supply
                {
                    Id = model.Id,
                    Name = model.Name,
                    Contact_person = model.Contact_person,
                    TitleId = model.Title,
                    Address = model.Telphone,
                    Postcode = model.Postcode,
                    Telphone = model.Telphone,
                    Fax = model.Fax,
                    Creadedate = model.Creadedate
                });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            var supply = await _supplyRepository.GetByIdAsync(Id);

            await _supplyRepository.RemoveAsync(supply);

            return RedirectToAction("Index");
        }
    }
}
