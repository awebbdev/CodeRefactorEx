using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    class PriceQuantity : Discount, IDiscount
    {
        public PriceQuantity(Line line, double thisAmount) : base (line, thisAmount) { }

        public double ApplyDiscount()
        {
            ThisAmount += Line.Quantity * Line.Bike.Price;
            switch (Line.Bike.Price)
            {
                case Bike.OneThousand:
                    if (Line.Quantity >= 20)
                        ThisAmount *= .9d;
                    break;
                case Bike.TwoThousand:
                    if (Line.Quantity >= 10)
                        ThisAmount *= .8d;
                    break;
                case Bike.FiveThousand:
                    if (Line.Quantity >= 5)
                        ThisAmount *= .8d;
                    break;
            }                
            return ThisAmount;
        }
    }
}
