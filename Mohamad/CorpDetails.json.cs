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
        
        void UpdateFranchiseList()
        {
            Corporation corp = (Corporation)Data;
            FranchiseList = Db.SQL<Franchise>("SELECT f FROM Franchise f WHERE ParentCorp = ?", corp);
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
    }
}
