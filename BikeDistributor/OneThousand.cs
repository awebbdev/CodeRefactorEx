using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    class OneThousand : IDiscount
    {
        public Line Line { get; private set; }
        public double ThisAmount { get; private set; }

        public OneThousand(Line line, double thisAmount)
        {
            Line = line;
            ThisAmount = thisAmount;
        }

        public double ApplyDiscount()
        {
            if (Line.Quantity >= 20)
                ThisAmount += Line.Quantity * Line.Bike.Price * .9d;
            else
                ThisAmount += Line.Quantity * Line.Bike.Price;
            return ThisAmount;
        }
    }
}
