using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Models.Crypto
{
    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int cmc_rank { get; set; }
        public DateTime last_updated { get; set; }
        public dynamic quote { get; set; }

        public float? price { get; set; }
    }
}
