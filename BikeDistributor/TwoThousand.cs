using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    class TwoThousand : IDiscount
    {
        public Line Line { get; private set; }
        public double ThisAmount { get; private set; }

        public TwoThousand(Line line, double thisAmount)
        {
            Line = line;
            ThisAmount = thisAmount;
        }

        public double ApplyDiscount()
        {
            if (Line.Quantity >= 10)
                ThisAmount += Line.Quantity * Line.Bike.Price * .8d;
            else
                ThisAmount += Line.Quantity * Line.Bike.Price;
            return ThisAmount;
        }
    }
}
