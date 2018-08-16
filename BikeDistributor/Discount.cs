using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    class Discount
    {
        protected Line Line { get; set; }
        protected double ThisAmount { get; set; }

        public Discount(Line line, double thisAmount)
        {
            Line = line;
            ThisAmount = thisAmount;
        }


    }
}
