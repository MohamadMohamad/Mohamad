using System;
using Starcounter;

namespace Mohamad
{
    class Program
    {
        static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Handle.GET("/Mohamad/start", () =>
            {
                var json = new CorpJson
                {
                    Data = null
                };

                if (Session.Current == null)
                {
                    Session.Current = new Session(SessionOptions.PatchVersioning);
                }
                json.Session = Session.Current;
                return json;
            });

            Handle.GET("/Mohamad/partial/corp/{?}", (string id) =>
            {
                var json = new CorpDetails();
                json.Data = DbHelper.FromID(DbHelper.Base64DecodeObjectID(id));
                return json;
            });

            Handle.GET("/Mohamad/franchise/{?}", (string id) =>
            {
                return Db.Scope(() =>
                {
                    var json = new FranchiseDetails();
                    json.Data = DbHelper.FromID(DbHelper.Base64DecodeObjectID(id));
                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }
                    json.Session = Session.Current;
                    return json;
                });
            });
        }
    }
}