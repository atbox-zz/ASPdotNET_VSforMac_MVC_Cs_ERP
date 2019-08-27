using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Controllers
{
    public class Product_dataController : Controller
    {
        //private readonly ISupplyRepository _supplyRepository;
        //private readonly ITitleRepository _titleRepository;
        private readonly IProduct_dataRepository _product_DataRepository;
        private readonly IProduct_itemRepository _product_ItemRepository;
        private readonly ISupplyRepository _supplyRepository;

        public Product_dataController(IProduct_dataRepository product_DataRepository, IProduct_itemRepository product_ItemRepository, ISupplyRepository supplyRepository)
        {
            _product_DataRepository = product_DataRepository;
            _product_ItemRepository = product_ItemRepository;
            _supplyRepository = supplyRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageindex = 1)
        {
            //每頁十筆
            var pagesize = 10;

            var product_Datas = _product_DataRepository.PageList(pageindex, pagesize);

            ViewBag.PageCount = product_Datas.Item2;

            ViewBag.PageIndex = pageindex;

            return View(product_Datas.Item1);
        }

        public async Task<IActionResult> Add()
        {
            var supplys = await _supplyRepository.ListAsync();

            //取得職稱資料後送到前端
            ViewBag.Supplys = supplys.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            var product_items = await _product_ItemRepository.ListAsync();

            ViewBag.product_Items = product_items.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product_dataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            await _product_DataRepository.AddAsync(new Product_data
            {
                Name = model.Name,
                SupplyId = model.Supply,
                Product_itemId = model.Product_item,
                Unit_quality = model.Unit_quality,
                Price = model.Price,
                Stock_quality = model.Stock_quality,
                Order_quality = model.Order_quality,
                Safe_quality = model.Safe_quality,
                Createdate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var product_Data = await _product_DataRepository.GetByIdAsync(Id);

            var produdt_dataViewModel = new Product_dataViewModel();

            produdt_dataViewModel.Id = product_Data.Id;
            produdt_dataViewModel.Name = product_Data.Name;
            produdt_dataViewModel.Supply = product_Data.SupplyId;
            produdt_dataViewModel.Product_item = product_Data.Product_itemId;
            produdt_dataViewModel.Unit_quality = product_Data.Unit_quality;
            produdt_dataViewModel.Price = product_Data.Price;
            produdt_dataViewModel.Stock_quality = product_Data.Stock_quality;
            produdt_dataViewModel.Order_quality = product_Data.Order_quality;
            produdt_dataViewModel.Safe_quality = product_Data.Safe_quality;
            produdt_dataViewModel.Createdate = product_Data.Createdate;

            var supplys = await _supplyRepository.ListAsync();

            //取得供應商資料後送到前端
            ViewBag.Supplys = supplys.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            var product_Items = await _product_ItemRepository.ListAsync();

            //取得產品類別資料後送到前端
            ViewBag.Product_Items = product_Items.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View(produdt_dataViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product_dataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _product_DataRepository.ModifiedAsync(
                new Product_data
                {
                    Id = model.Id,
                    Name = model.Name,
                    SupplyId = model.Supply,
                    Product_itemId = model.Product_item,
                    Unit_quality = model.Unit_quality,
                    Price = model.Price,
                    Stock_quality = model.Stock_quality,
                    Order_quality = model.Order_quality,
                    Safe_quality = model.Safe_quality,
                    Createdate = model.Createdate
                });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            var product_Data = await _product_DataRepository.GetByIdAsync(Id);

            await _product_DataRepository.RemoveAsync(product_Data);

            return RedirectToAction("Index");
        }
    }
}
