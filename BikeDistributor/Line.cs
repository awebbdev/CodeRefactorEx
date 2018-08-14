namespace BikeDistributor
{
    public enum DiscountCode
    {
        None, LoyalCustomer, TRUser, ZwiftUser, Quantity
    }
    public class Line
    {
        public Line(Bike bike, int quantity, DiscountCode[] discountCode)
        {
            Bike = bike;
            Quantity = quantity;
            DiscountCode = discountCode;
        }

        public Bike Bike { get; private set; }
        public int Quantity { get; private set; }
        public DiscountCode[] DiscountCode { get; set; }
    }
}
