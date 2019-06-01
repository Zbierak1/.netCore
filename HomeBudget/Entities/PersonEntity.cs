using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Entities
{
    public class PersonEntity
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual RelationEntity Relation { get; set; }
        public int RelationId { get; set; }
        public ICollection<BillEntity> Bills { get; set; }
    }
}
