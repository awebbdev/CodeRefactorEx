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
