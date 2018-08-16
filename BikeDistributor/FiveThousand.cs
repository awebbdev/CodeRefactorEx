using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    class FiveThousand : Discount, IDiscount
    {

        public FiveThousand(Line line, double thisAmount) : base(line, thisAmount){ }

        public double ApplyDiscount()
        {
            if (Line.Quantity >= 5)
                ThisAmount += Line.Quantity * Line.Bike.Price * .8d;
            else
                ThisAmount += Line.Quantity * Line.Bike.Price;
            return ThisAmount;
        }
    }
}
