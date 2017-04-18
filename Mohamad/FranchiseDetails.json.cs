using Starcounter;
using System;

namespace Mohamad
{
    partial class FranchiseDetails : Json
    {
        public string HomeAddress => string.Format("{0} {1}, {2} {3}, {4}", HomeStreet, HomeNumber, HomeZipCode, HomeCity, HomeCountry);

        protected override void OnData()
        {
            base.OnData();
            UpdateTransactionsList();
        }

        void UpdateTransactionsList()
        {
            Franchise franchise = (Franchise)Data;
            TransactionsList = Db.SQL<Transaction>("SELECT t FROM Transaction t WHERE Seller = ?", franchise);
        }

        void Handle(Input.SaveButton saveButton)
        {
            Transaction.Commit();
        }

        void Handle(Input.RegisterHomeButton registerButton)
        {
            Db.Transact(() =>
            {
                Franchise franchise = (Franchise)Data;
                Transaction transaction = new Transaction();
                transaction.Date = Convert.ToDateTime(HomeDate);
                transaction.Commission = HomeCommission;
                transaction.Price = HomePrice;
                transaction.Seller = franchise;
                transaction.Address = HomeAddress;
            });
            UpdateTransactionsList();
        }
    }
}
