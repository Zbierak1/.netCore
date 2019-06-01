using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Entities
{
    public class RelationEntity
    {
        public int RelationId { get; set; }
        public string Description { get; set; }
        public ICollection<PersonEntity> People { get; set; }
    }
}
