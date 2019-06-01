using System;
using System.Globalization;
using System.Linq;
using HomeBudget.BussinesLogic;
using HomeBudget.Entities;
using HomeBudget.Models.Bills;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeBudget.Controllers
{
    //Atrybut 
    [Authorize]
    public class BillsController : Controller
    {
        private readonly IBillsService _billsService;
        private readonly IPeopleService _peopleService;

        public BillsController(IBillsService billsService, IPeopleService peopleService)
        {
            this._billsService = billsService;
            this._peopleService = peopleService;
        }

        public IActionResult BillsList(string search = null)
        {
            var bills = _billsService.GetAllBills(search);

            var billsModel = bills.Select(s => new BillModel
            {
                Amount = s.Amount.ToString(CultureInfo.InvariantCulture),
                BillDate = s.BillDate,
                Description = s.Description,
                PersonName = s.Person.Name,
                Id = s.BillId
            }).ToList();

            return View(new BillsListViewModel { Bills = billsModel, Search = search });
        }
        [HttpGet]
        public IActionResult AddEditBill(int id)
        {
            var bill = _billsService.GetBillById(id);
            var viewModel = new AddEditBillViewModel
            {
                PeopleList = _peopleService.GetAllPeople()
                    .Select(s => new SelectListItem(s.Name, s.PersonId.ToString()))
                    .ToList()
            };

            viewModel.Bill = bill != null ? new BillModel
            {
                Id = bill.BillId,
                Amount = bill.Amount.ToString(CultureInfo.InvariantCulture),
                BillDate = bill.BillDate,
                Description = bill.Description,
                PersonId = bill.PersonId,
                PersonName = bill.Person.Name
            } : new BillModel();


            return PartialView("_AddEditBill", viewModel);
        }
        public IActionResult AddBill(AddEditBillViewModel model)
        {
            if (model != null && model.Bill != null && ModelState.IsValid)
            {
                if (float.TryParse(model.Bill.Amount.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out var amount))
                {
                    var entity = new BillEntity
                    {
                        CreatedBy = HttpContext.User.Identity.Name,
                        CreatedDate = DateTime.Now,
                        Description = model.Bill.Description,
                        PersonId = model.Bill.PersonId,
                        Amount = amount,
                        BillDate = model.Bill.BillDate.Value,
                        BillId = model.Bill.Id
                    };
                    if (entity.BillId > 0)
                    {
                        _billsService.UpdateBill(entity);
                    }
                    else
                    {
                        _billsService.AddBill(entity);
                    }
                }
            }

            return RedirectToAction(nameof(BillsList));
        }

        public IActionResult DeleteBill(int id)
        {
            if (id > 0)
            {
                _billsService.RemoveBill(id);
            }
            return RedirectToAction(nameof(BillsList));
        }


        public IActionResult GetAllBills()
        {
            _billsService.GetAllBills();


            return View();
        }
    }
}