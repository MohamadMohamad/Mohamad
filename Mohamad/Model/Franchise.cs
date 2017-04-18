using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Mohamad
{
    [Database]
    public class Franchise
    {
        public string Name;
        public string Street;
        public int Number;
        public int zipcode;
        public string city;
        public string country;
        public Corporation ParentCorp;

        public int SoldHomes => Db.SQL<Transaction>("SELECT t FROM Transaction t WHERE Seller = ?", this).Count();
        public Decimal TotalCommission => Db.SQL<Decimal>("SELECT SUM(Commission) FROM Transaction WHERE Seller = ?", this).First;
        public Decimal AverageCommission => ((SoldHomes == 0) ? 0 : (TotalCommission / SoldHomes));
        public Decimal Trend => 0;
    }
}
