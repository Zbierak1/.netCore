using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HomeBudget.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.BussinesLogic
{
    public class PeopleService : IPeopleService
    {
        private readonly ApplicationDbContext _dbContext;

        public PeopleService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public PersonEntity AddPerson(PersonEntity person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonEntity> GetAllPeople()
        {
            return _dbContext.People
                .AsQueryable()
                .Include(x => x.Relation)
                .Include(x => x.Bills)
                .ToList();
        }

        public PersonEntity GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovePerson(int id)
        {
            throw new NotImplementedException();
        }

        public PersonEntity UpdatePerson(PersonEntity person)
        {
            throw new NotImplementedException();
        }
    }
}
