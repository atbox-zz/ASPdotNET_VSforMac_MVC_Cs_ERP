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
    public class CustomController : Controller
    {
        private readonly ICustomRepository _customRepository;
        private readonly ITitleRepository _titleRepository;

        public CustomController(ICustomRepository customRepository, ITitleRepository titleRepository)
        {
            _customRepository = customRepository;
            _titleRepository = titleRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageindex = 1)
        {
            //每頁十筆
            var pagesize = 10;

            var customs = _customRepository.PageList(pageindex, pagesize);

            ViewBag.PageCount = customs.Item2;

            ViewBag.PageIndex = pageindex;

            return View(customs.Item1);
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
        public async Task<IActionResult> Add(CustomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            await _customRepository.AddAsync(new Custom
            {
                Name = model.Name,
                Contact_person = model.Contact_person,
                TitleId = model.Title,
                Address = model.Address,
                Postcode = model.Postcode,
                Telphone = model.Telphone,
                Fax = model.Fax,
                Createdate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Custom = await _customRepository.GetByIdAsync(Id);

            var customViewModel = new CustomViewModel();

            customViewModel.Id = Custom.Id;
            customViewModel.Name = Custom.Name;
            customViewModel.Contact_person = Custom.Contact_person;
            customViewModel.Title = Custom.TitleId;
            customViewModel.Address = Custom.Address;
            customViewModel.Postcode = Custom.Postcode;
            customViewModel.Telphone = Custom.Telphone;
            customViewModel.Fax = Custom.Fax;

            var titles = await _titleRepository.ListAsync();

            //取得職稱資料後送到前端
            ViewBag.Titles = titles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View(customViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _customRepository.ModifiedAsync(
                new Custom
                {
                    Id = model.Id,
                    Name = model.Name,
                    Contact_person = model.Contact_person,
                    TitleId = model.Title,
                    Address = model.Telphone,
                    Postcode = model.Postcode,
                    Telphone = model.Telphone,
                    Fax = model.Fax,
                    Createdate = model.Createdate
                });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            var custom = await _customRepository.GetByIdAsync(Id);

            await _customRepository.RemoveAsync(custom);

            return RedirectToAction("Index");
        }
    }
}
