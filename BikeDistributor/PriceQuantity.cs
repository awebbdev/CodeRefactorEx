namespace BikeDistributor
{
    /// <summary>
    /// A discount derived class that applies a discount based on price and quantity purchased
    /// </summary>
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
