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

        }

    }
}
