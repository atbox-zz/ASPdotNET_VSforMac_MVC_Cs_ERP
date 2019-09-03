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
    public class Order_masterController : Controller
    {
        private readonly ICustomRepository _customRepository;
        private readonly IDeliverRepository _deliverRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrder_masterRepository _order_MasterRepository;

        public Order_masterController(ICustomRepository customRepository, IDeliverRepository deliverRepository, IEmployeeRepository employeeRepository, IOrder_masterRepository order_MasterRepository)
        {
            _customRepository = customRepository;
            _deliverRepository = deliverRepository;
            _employeeRepository = employeeRepository;
            _order_MasterRepository = order_MasterRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(int pageindex = 1)
        {
            //每頁十筆
            var pagesize = 10;

            var order_masters = _order_MasterRepository.PageList(pageindex, pagesize);

            ViewBag.PageCount = order_masters.Item2;

            ViewBag.PageIndex = pageindex;

            return View(order_masters.Item1);
        }

        public async Task<IActionResult> Add()
        {
            var customs = await _customRepository.ListAsync();

            //取得客戶資料後送到前端
            ViewBag.Customs = customs.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            var delivers = await _deliverRepository.ListAsync();

            //取得貨運公司資料後送到前端
            ViewBag.Delivers = delivers.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            var employees = await _employeeRepository.ListAsync();

            //取得員工資料後送到前端
            ViewBag.Employees = employees.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order_masterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            await _order_MasterRepository.AddAsync(new Order_master
            {
                CustomId = model.Custom,
                Orderdate = model.Orderdate,
                Deliverydate = model.Deliverydate,
                DeliverId  = model.Deliver,
                Charges = model.Charges,
                Receiver = model.Receiver,
                Address = model.Address,
                Postcode = model.Postcode,
                EmployeeId = model.Employee,
                Createdate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var order_Master = await _order_MasterRepository.GetByIdAsync(Id);

            var Order_masterViewModel = new Order_masterViewModel();

            Order_masterViewModel.Id = order_Master.Id;
            Order_masterViewModel.Custom = order_Master.CustomId;
            Order_masterViewModel.Orderdate = order_Master.Orderdate;
            Order_masterViewModel.Deliverydate = order_Master.Deliverydate;
            Order_masterViewModel.Deliver = order_Master.DeliverId;
            Order_masterViewModel.Charges = order_Master.Charges;
            Order_masterViewModel.Receiver = order_Master.Receiver;
            Order_masterViewModel.Address = order_Master.Address;
            Order_masterViewModel.Postcode = order_Master.Postcode;
            Order_masterViewModel.Employee = order_Master.EmployeeId;

            var customs = await _customRepository.ListAsync();

            //取得客戶資料後送到前端
            ViewBag.Customs = customs.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            var delivers = await _deliverRepository.ListAsync();

            //取得貨運公司資料後送到前端
            ViewBag.Delivers = delivers.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            var employees = await _employeeRepository.ListAsync();

            //取得員工資料後送到前端
            ViewBag.Employees = employees.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View(Order_masterViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order_masterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _order_MasterRepository.ModifiedAsync(
                new Order_master
                {
                    Id = model.Id,
                    CustomId = model.Custom,
                    Orderdate = model.Orderdate,
                    Deliverydate = model.Deliverydate,
                    DeliverId = model.Deliver,
                    Charges = model.Charges,
                    Receiver = model.Receiver,
                    Address = model.Address,
                    Postcode = model.Postcode,
                    EmployeeId = model.Employee,
                    Createdate = model.Createdate
                });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            var order_Master = await _order_MasterRepository.GetByIdAsync(Id);

            await _order_MasterRepository.RemoveAsync(order_Master);

            return RedirectToAction("Index");
        }
    }
}
