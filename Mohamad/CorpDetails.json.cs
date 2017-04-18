using System;
using Starcounter;

namespace Mohamad
{
    partial class CorpDetails : Json
    {
        protected override void OnData()
        {
            base.OnData();
            Corporation corp = (Corporation)Data;
            FranchiseList = Db.SQL<Franchise>("SELECT f FROM Franchise f WHERE ParentCorp = ?", corp);
            IncludeAddFranchise(corp);
        }

        private void IncludeAddFranchise(Corporation corp)
        {
            AddFranchise addFranchise = (AddFranchise)Self.GET(string.Format("/Mohamad/partial/corp/{0}/addfranchise", corp.GetObjectID()));
            AddFranchiseSection = addFranchise;
        }
    }
}
