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

        public Receipt(Order order)
        {
            Order = order;
        }

        protected double TotalAmount { get; set; }
        protected StringBuilder ReceiptResult { get; set; }
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
            PriceQuantity priceQuantity = new PriceQuantity(line, lineTotal);
            lineTotal = priceQuantity.ApplyDiscount();
            TotalAmount += lineTotal;
            return lineTotal;
        }
    }
}
