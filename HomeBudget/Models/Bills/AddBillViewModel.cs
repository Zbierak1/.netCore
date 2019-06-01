using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Models.Bills
{
    public class AddBillViewModel
    {
        public float Amount { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }
        public DateTime BillDate { get; set; }
    }
}
