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
    }
}
