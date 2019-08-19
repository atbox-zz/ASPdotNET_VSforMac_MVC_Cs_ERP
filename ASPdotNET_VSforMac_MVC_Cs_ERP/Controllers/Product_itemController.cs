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
    public class Product_itemController : Controller
    {
        private readonly IProduct_itemRepository _product_ItemRepository;

        public Product_itemController(IProduct_itemRepository product_ItemRepository)
        {
            _product_ItemRepository = product_ItemRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageindex = 1)
        {
            //每頁十筆
            var pagesize = 10;

            var product_items = _product_ItemRepository.PageList(pageindex, pagesize);

            ViewBag.PageCount = product_items.Item2;

            ViewBag.PageIndex = pageindex;

            return View(product_items.Item1);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product_itemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            await _product_ItemRepository.AddAsync(new Product_item
            {
                Name = model.Name,
                Descripcition = model.Descripcition,
                Createdate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var product_Item = await _product_ItemRepository.GetByIdAsync(Id);

            var Product_itemViewModel = new Product_itemViewModel();

            Product_itemViewModel.Id = product_Item.Id;
            Product_itemViewModel.Name = product_Item.Name;
            Product_itemViewModel.Descripcition = product_Item.Descripcition;

            return View(Product_itemViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product_itemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _product_ItemRepository.ModifiedAsync(
                new Product_item
                {
                    Id = model.Id,
                    Name = model.Name,
                    Descripcition = model.Descripcition,
                    Createdate = DateTime.Now
                }); ;

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            var product_Item = await _product_ItemRepository.GetByIdAsync(Id);

            await _product_ItemRepository.RemoveAsync(product_Item);

            return RedirectToAction("Index");
        }
    }
}
