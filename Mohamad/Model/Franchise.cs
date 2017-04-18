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
        public int ZipCode;
        public string City;
        public string Country;
        public Corporation ParentCorp;

        public int SoldHomes => Db.SQL<Transaction>("SELECT t FROM Transaction t WHERE Seller = ?", this).Count();
        public Decimal TotalCommission => Db.SQL<Decimal>("SELECT SUM(Commission) FROM Transaction WHERE Seller = ?", this).First;
        public Decimal AverageCommission => ((SoldHomes == 0) ? 0 : (TotalCommission / SoldHomes));
        public Decimal Trend => 0;
        public string Address => string.Format("{0} {1}, {2} {3}, {4}", Street, Number, ZipCode, City, Country);
        public string FranchiseID => this.GetObjectID();
    }
}
