using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Models.Bills
{
    public class BillsListViewModel
    {
        public IList<BillModel> Bills { get; set; }
        public string Search { get; set; }
    }
}
