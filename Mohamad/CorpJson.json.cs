using Starcounter;

namespace Mohamad
{
    partial class CorpJson : Json
    {

        void Handle(Input.AddCorpButton addCorpButton)
        {
            Db.Transact(() =>
            {
                Corporation corp = new Corporation();
                corp.Name = Name;
            });
        }
    }
}
