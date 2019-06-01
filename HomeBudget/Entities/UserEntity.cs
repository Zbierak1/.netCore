using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudget.Entities
{
    public class UserEntity : IdentityUser
    {
        public int PersonId { get; set; }
    }
}
