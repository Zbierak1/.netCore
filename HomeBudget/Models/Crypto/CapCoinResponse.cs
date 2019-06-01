using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Models.Crypto
{
    public class CapCoinResponse
    {
        public Status status { get; set; }
        public IList<Datum> data { get; set; }
    }
}
