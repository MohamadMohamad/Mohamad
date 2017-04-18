using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Mohamad
{
    [Database]
    public class Transaction
    {
        public DateTime Date;
        public Decimal Price;
        public Decimal Commission;
        public string Address;
        public Franchise Seller;

        public string DateString => this.Date.ToString("yyyy-MM-dd");
    }
}
