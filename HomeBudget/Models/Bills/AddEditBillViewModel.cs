using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Models.Bills
{
    public class AddEditBillViewModel
    {
        public BillModel Bill { get; set; }
        public IList<SelectListItem> PeopleList { get; set; }
    }
}
