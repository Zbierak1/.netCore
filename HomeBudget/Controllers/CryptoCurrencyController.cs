using System.Collections.Generic;
using System.Linq;
using HomeBudget.BussinesLogic;
using HomeBudget.Models.Crypto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeBudget.Controllers
{
    public class CryptoCurrencyController : Controller
    {
        private readonly CryptoCurrencyClient client;

        public CryptoCurrencyController(CryptoCurrencyClient client)
        {
            this.client = client;
        }
        List<string> GetConvertCurrencyList()
        {
            return new List<string> { "PLN", "USD", "EUR", "GBP", "AUD", "BRL", "CAD", "CHF", "CNY", "HKD", "IDR", "INR", "JPY", "KRW", "MXN", "RUB" };
        }

        public IActionResult Index(CryptoCurrenciesViewModel model, int pageNumber = 0)
        {
            var result = client.GetList(model.Convert, page: pageNumber);
            var newModel = new CryptoCurrenciesViewModel
            {
                CapCoinsResponse = result,
                ConvertCurrencyList = GetConvertCurrencyList().Select(s => new SelectListItem(s,s))
                    .ToList(),
                Convert = model.Convert,
                Page = pageNumber
            };

            return View(newModel);
        }
    }
}