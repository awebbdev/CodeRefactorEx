using System.Linq;

namespace BikeDistributor
{
    /// <summary>
    /// 
    /// </summary>
    public enum DiscountCode
    {
        None, LoyalCustomer, TRUser, Quantity
    }
    public class Line
    {
        public Line(Bike bike, int quantity, DiscountCode[] discountCodes)
        {
            Bike = bike;
            Quantity = quantity;
            DiscountCodes = discountCodes;
            ApplyDiscount();
        }

        public Bike Bike { get; private set; }
        public int Quantity { get; private set; }
        public DiscountCode[] DiscountCodes { get; private set; }
        public double LineAmount { get; private set; } = .0d;

        /// <summary>
        /// Processes the discounts selected for the line item and sets the total to the final discounted price.
        /// </summary>
        private void ApplyDiscount()
        {
            LineAmount += Quantity * Bike.PriceList[Bike.Price];
            if (DiscountCodes.Contains(DiscountCode.None))
            { //A discount code of none should override any other codes possibly selected
                return;
            }
            foreach (DiscountCode dis in DiscountCodes)
            {
                switch (dis)
                {
                    case DiscountCode.Quantity:
                        switch (Bike.Price)
                        {
                            case Price.OneThousand:
                                if (Quantity >= 20)
                                    LineAmount *= .9d;
                                break;
                            case Price.TwoThousand:
                                if (Quantity >= 10)
                                    LineAmount *= .8d;
                                break;
                            case Price.FiveThousand:
                                if (Quantity >= 5)
                                    LineAmount *= .8d;
                                break;
                            case Price.TenThousand:
                                if (Quantity >= 3)
                                    LineAmount *= .75d;
                                break;
                        }
                        break;
                    case DiscountCode.LoyalCustomer:
                        LineAmount *= .95d;
                        break;
                    case DiscountCode.TRUser:
                        LineAmount *= .95d;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
