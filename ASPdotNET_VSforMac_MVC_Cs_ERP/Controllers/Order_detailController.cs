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
    public class Order_detailController : Controller
    {
        private readonly IOrder_detailRepository _order_DetailRepository;
        private readonly IOrder_masterRepository _order_MasterRepository;
        private readonly IProduct_dataRepository _product_DataRepository;

        public Order_detailController(IOrder_detailRepository order_DetailRepository, IOrder_masterRepository order_MasterRepository, IProduct_dataRepository product_DataRepository)
        {
            _order_DetailRepository = order_DetailRepository;
            _order_MasterRepository = order_MasterRepository;
            _product_DataRepository = product_DataRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(int Id, int pageindex = 1)
        {
            if (TempData["AddId"] != null)
            {
                Id = (int)TempData["AddId"];
            }
            else if (TempData["EditId"] != null)
            {
                Id = (int)TempData["EditId"];
            }
            else if (TempData["RemoveId"] != null)
            {
                Id = (int)TempData["RemoveId"];
            }

            //每頁十筆
            var pagesize = 10;

            var order_Details = _order_DetailRepository.PageList(pageindex, pagesize);

            ViewBag.PageCount = order_Details.Item2;

            ViewBag.PageIndex = pageindex;

            TempData["MasterId"] = Id;

            ViewBag.Id = Id;

            return View(order_Details.Item1);
        }

        public async Task<IActionResult> Add(int Id)
        {
            int MasterId = (int)TempData["MasterId"];

            var product_Datas = await _product_DataRepository.ListAsync();

            //取得產品資料後送到前端
            ViewBag.Product_datas = product_Datas.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            var order_DetailViewModel = new Order_detailViewModel();

            order_DetailViewModel.Order_master = MasterId;

            return View(order_DetailViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order_detailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            await _order_DetailRepository.AddAsync(new Order_detail
            {
                Order_masterId = model.Order_master,
                Product_dataId = model.Product_data,
                Price = model.Price,
                Quality = model.Quality,
                Createdate = DateTime.Now
            });

            TempData["AddId"] = model.Order_master;

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var order_Detail = await _order_DetailRepository.GetByIdAsync(Id);

            var order_DetailViewModel = new Order_detailViewModel();

            order_DetailViewModel.Id = order_Detail.Id;
            order_DetailViewModel.Order_master = order_Detail.Order_masterId;
            order_DetailViewModel.Product_data = order_Detail.Product_dataId;
            order_DetailViewModel.Price = order_Detail.Price;
            order_DetailViewModel.Quality = order_Detail.Quality;
            TempData["Createdate"] = order_Detail.Createdate;

            var product_Datas = await _product_DataRepository.ListAsync();

            //取得產品資料後送到前端
            ViewBag.Product_datas = product_Datas.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View(order_DetailViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order_detailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _order_DetailRepository.ModifiedAsync(
                new Order_detail
                {
                    Id = model.Id,
                    Order_masterId = model.Order_master,
                    Product_dataId = model.Product_data,
                    Price = model.Price,
                    Quality = model.Quality,
                    Createdate = (DateTime)TempData["Createdate"]
                });

            TempData["EditId"] = model.Order_master;

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            var order_dteail = await _order_DetailRepository.GetByIdAsync(Id);

            await _order_DetailRepository.RemoveAsync(order_dteail);

            TempData["RemoveId"] = order_dteail.Order_masterId;

            return RedirectToAction("Index");
        }
    }
}
