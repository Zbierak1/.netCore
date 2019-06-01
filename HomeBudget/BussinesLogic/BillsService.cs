using System;
using System.Collections.Generic;
using System.Linq;
using HomeBudget.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.BussinesLogic
{
    public class BillsService : IBillsService
    {
        private readonly ApplicationDbContext dbContext;

        public BillsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public BillEntity AddBill(BillEntity bill)
        {
            dbContext.Add(bill);
            dbContext.SaveChanges();

            return bill;
        }

        public IEnumerable<BillEntity> GetAllBills(string searchString = null)
        {
            var bills = dbContext.Bills
                    .Include(x => x.Person)
                    .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                bills = bills.Where(s => s.Description.ToLower().Contains(searchString.ToLower()) ||
                s.Person.Name.ToLower().Contains(searchString.ToLower()) ||
                s.Amount.ToString().ToLower().Contains(searchString.ToLower()));
            }

            return bills.ToList();
        }

        public BillEntity GetBillById(int id)
        {
            var bill = dbContext.Bills
                    .Include(x => x.Person)
                    .AsQueryable().FirstOrDefault(x => x.BillId == id);

            return bill;
        }

        public IEnumerable<BillEntity> GetBillsByPersonId(int id)
        {
            var list = dbContext.Bills.AsQueryable().Where(x => x.PersonId == id);

            return list;
        }

        public void RemoveBill(int id)
        {
            var bill = dbContext.Bills.AsQueryable().FirstOrDefault(x => x.BillId == id);
            if (bill == null)
                return;

            dbContext.Bills.Remove(bill);
            dbContext.SaveChanges();

        }

        public BillEntity UpdateBill(BillEntity bill)
        {
            var billToUpdate = dbContext.Bills.AsQueryable().FirstOrDefault(x => x.BillId == bill.BillId);

            if (billToUpdate == null)
                return null;

            billToUpdate.Amount = bill.Amount;
            billToUpdate.ModifiedBy = bill.ModifiedBy;
            billToUpdate.ModifiedDate = DateTime.Now;
            billToUpdate.PersonId = bill.PersonId;
            billToUpdate.Description = bill.Description;
            dbContext.SaveChanges();

            return billToUpdate;
        }
    }
}
