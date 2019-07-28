using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository;
using ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Controllers
{
    public class TitleController : Controller
    {
        private readonly ITitleRepository _titleRepository;

        public TitleController(ITitleRepository titleRepository)//(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var titles = await _titleRepository.ListAsync();
            return View(titles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TitleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "職稱不得為空白";
                return View("Add");
            }

            await _titleRepository.AddAsync(new Title
            {
                Name = model.Name,
                Createdate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var title = await _titleRepository.GetByIdAsync(Id);

            return View(title);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Title model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _titleRepository.UpdateAsync(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            var title = await _titleRepository.GetByIdAsync(Id);

            await _titleRepository.DeleteAsync(title);

            return RedirectToAction("Index");
        }
    }
}
