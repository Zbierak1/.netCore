using HomeBudget.Entities;
using System.Collections.Generic;

namespace HomeBudget.BussinesLogic
{
    public interface IBillsService
    {
        BillEntity AddBill(BillEntity bill);
        BillEntity UpdateBill(BillEntity bill);
        void RemoveBill(int id);
        BillEntity GetBillById(int id);
        IEnumerable<BillEntity> GetBillsByPersonId(int id);

        IEnumerable<BillEntity> GetAllBills(string searchString = null);
    }
}