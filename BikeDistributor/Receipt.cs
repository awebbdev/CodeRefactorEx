using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    /// <summary>
    /// A generic Receipt class to be derived from for receipt types
    /// </summary>
    class Receipt
    {
        private const double TaxRate = .0725d;                                          //A set tax rate to be applied to the subtotal
        protected double TotalAmount { get; set; }                                      //The total amount that is added to by each line item and tax aount
        protected StringBuilder ReceiptResult { get; set; } = new StringBuilder();      //The returned receipt string
        protected Order Order { get; set; }                                             // The order object the receipt is printing

        /// <summary>
        /// Calculates and set the tax amount and total amout with tax
        /// </summary>
        /// <returns>The amount of tax charged</returns>
        protected double CalculateTax()
        {
            var TaxAmount = .0d;
            TaxAmount = TotalAmount * TaxRate;
            TotalAmount += TaxAmount;
            return TaxAmount;
        }
        /// <summary>
        /// Calculate line totals, applies line discounts, and incriments Total 
        /// </summary>
        /// <param name="line">An order line</param>
        /// <returns>The total value of the order line</returns>
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
        /// <summary>
        /// Applies the discounts provided to the line total
        /// </summary>
        /// <param name="discounts">List of discount interfaces to apply to the line total</param>
        /// <param name="lineTotal">The line total before discount application</param>
        /// <returns>Line total after discount application</returns>
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
