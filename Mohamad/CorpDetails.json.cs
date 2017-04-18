using System;
using Starcounter;

namespace Mohamad
{
    partial class CorpDetails : Json
    {
        protected override void OnData()
        {
            base.OnData();
            UpdateFranchiseList();
        }

        void UpdateFranchiseList(string orderProperty = "Name")
        {
            Corporation corp = (Corporation)Data;
            FranchiseList = Db.SQL<Franchise>("SELECT f FROM Franchise f WHERE f.ParentCorp = ? ORDER BY f." + orderProperty, corp);

        }

        void Handle(Input.AddFranchiseButton addFranchiseButton)
        {
            Db.Transact(() =>
            {
                Corporation corp = (Corporation)Data;
                Franchise franchise = new Franchise();
                franchise.Name = FranchiseName;
                franchise.ParentCorp = corp;
            });
            UpdateFranchiseList();
        }

        void Handle(Input.HomesSortButton button)
        {
            UpdateFranchiseList("SoldHomes");
        }

        void Handle(Input.TotalCommissionSortButton button)
        {
            UpdateFranchiseList("TotalCommission");
        }

        void Handle(Input.AverageCommissionSortButton button)
        {
            UpdateFranchiseList("AverageCommission");
        }

        void Handle(Input.TrendSortButton button)
        {
            UpdateFranchiseList("Trend");
        }


    }
}
