using HomeBudget.Entities;
using System.Collections.Generic;

namespace HomeBudget.BussinesLogic
{
    public interface IPeopleService
    {
        PersonEntity AddPerson(PersonEntity person);
        void RemovePerson(int id);
        PersonEntity UpdatePerson(PersonEntity person);
        PersonEntity GetPersonById(int id);
        IEnumerable<PersonEntity> GetAllPeople();
    }
}