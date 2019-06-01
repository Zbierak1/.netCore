using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Models.Crypto
{
    public class CryptoCurrenciesViewModel
    {
        public CapCoinResponse CapCoinsResponse { get; set; }
        public List<SelectListItem> ConvertCurrencyList { get; set; }

        public string Convert { get; set; } = "PLN";
        public int Page { get; set; }
    }
}
