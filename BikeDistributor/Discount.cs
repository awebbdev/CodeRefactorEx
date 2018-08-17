namespace BikeDistributor
{
    /// <summary>
    /// Generic Discount class
    /// </summary>
    class Discount
    {
        protected Line Line { get; set; }               //Order line that contains bike, amount, and cost 
        protected double ThisAmount { get; set; }       //an initial amount to be modified based on applied discount

        public Discount(Line line, double thisAmount)
        {
            Line = line;
            ThisAmount = thisAmount;
        }
    }
}
