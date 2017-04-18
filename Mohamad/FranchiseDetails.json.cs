using Starcounter;

namespace Mohamad
{
    partial class FranchiseDetails : Json
    {
        void Handle(Input.SaveButton saveButton)
        {
            Transaction.Commit();
        }
    }
}
