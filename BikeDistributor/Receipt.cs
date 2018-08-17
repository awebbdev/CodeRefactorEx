using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    class Receipt
    {
        private const double TaxRate = .0725d;
        protected double TotalAmount { get; set; }
        protected StringBuilder ReceiptResult { get; set; } = new StringBuilder();
        protected Order Order { get; set; }

        protected double CalculateTax()
        {
            var TaxAmount = .0d;
            TaxAmount = TotalAmount * TaxRate;
            TotalAmount += TaxAmount;
            return TaxAmount;
        }

        protected double CalculateLineTotals(Line line)
        {
            var lineTotal = .0d;
            IList<IDiscount> Discounts = new List<IDiscount>();
            IDiscount priceQuantity = new PriceQuantity(line, lineTotal);
            Discounts.Add(priceQuantity);
            lineTotal = CalculateDiscounts(Discounts, lineTotal);
            TotalAmount += lineTotal;
            return lineTotal;
        }

        protected double CalculateDiscounts(IList<IDiscount> discounts, double lineTotal)
        {
            foreach (IDiscount discount in discounts)
            {
                lineTotal = discount.ApplyDiscount();
            }
            return lineTotal;
        }
    }
}
