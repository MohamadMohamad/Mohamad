using Starcounter;
using System;

namespace Mohamad
{
    partial class AddFranchise : Json
    {
        protected override void OnData()
        {
            base.OnData();
            string parentCorpID = (string)Data;
            ParentCorp = parentCorpID;
        }

        void Handle(Input.AddFranchiseButton addFranchiseButton)
        {
            Db.Transact(() =>
            {
                Corporation corp = (Corporation)DbHelper.FromID(Convert.ToUInt64(ParentCorp));
                Franchise franchise = new Franchise();
                franchise.Name = Name;
                franchise.ParentCorp = corp;
            });
        }
    }
}
