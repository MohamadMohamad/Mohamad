using System;
using Starcounter;

namespace Mohamad
{
    partial class CorpJson : Json
    {
        protected override void OnData()
        {
            base.OnData();
            QueryResultRows<Corporation> corps = Db.SQL<Corporation>("SELECT c FROM Corporation c");
            foreach(Corporation corp in corps)
            {
                AddCorp(corp);
            }
        }

        private void AddCorp(Corporation corp)
        {
            CorpDetails corpDetails = (CorpDetails)Self.GET("/Mohamad/partial/corp/" + corp.GetObjectID());
            this.CorpList.Add(corpDetails);
        }

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
