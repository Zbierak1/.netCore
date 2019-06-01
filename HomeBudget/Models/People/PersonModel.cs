using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Models.People
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RelationName { get; set; }
        public float TotalAmount { get; set; }
    }
}
