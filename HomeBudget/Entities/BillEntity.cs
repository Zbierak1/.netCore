using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Entities
{
    public class BillEntity
    {
        public int BillId { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }


        public PersonEntity Person { get; set; }
        public int PersonId { get; set; }
    }
}
