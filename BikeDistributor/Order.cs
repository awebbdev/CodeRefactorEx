using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class Order
    {
        private const double TaxRate = .0725d;
        private readonly IList<Line> _lines = new List<Line>();

        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; private set; }

        public void AddLine(Line line)
        {
            _lines.Add(line);
        }

        public string Receipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder(string.Format("Order Receipt for {0}{1}", Company, Environment.NewLine));
            foreach (var line in _lines)
            {
                var thisAmount = 0d;
                thisAmount = discountApplied(line, thisAmount);
                result.AppendLine(string.Format("\t{0} x {1} {2} = {3}", line.Quantity, line.Bike.Brand, line.Bike.Model, thisAmount.ToString("C")));
                totalAmount += thisAmount;
            }
            result.AppendLine(string.Format("Sub-Total: {0}", totalAmount.ToString("C")));
            var tax = totalAmount * TaxRate;
            result.AppendLine(string.Format("Tax: {0}", tax.ToString("C")));
            result.Append(string.Format("Total: {0}", (totalAmount + tax).ToString("C")));
            return result.ToString();
        }

        public string HtmlReceipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", Company));
            if (_lines.Any())
            {
                result.Append("<ul>");
                foreach (var line in _lines)
                {
                    var thisAmount = 0d;
                    thisAmount = discountApplied(line, thisAmount);
                    result.Append(string.Format("<li>{0} x {1} {2} = {3}</li>", line.Quantity, line.Bike.Brand, line.Bike.Model, thisAmount.ToString("C")));
                    totalAmount += thisAmount;
                }
                result.Append("</ul>");
            }
            result.Append(string.Format("<h3>Sub-Total: {0}</h3>", totalAmount.ToString("C")));
            var tax = totalAmount * TaxRate;
            result.Append(string.Format("<h3>Tax: {0}</h3>", tax.ToString("C")));
            result.Append(string.Format("<h2>Total: {0}</h2>", (totalAmount + tax).ToString("C")));
            result.Append("</body></html>");
            return result.ToString();
        }

        /// <summary>
        /// discountApplied - Processes the discounts selected to each order line item. 
        /// </summary>
        /// <param name="line">The order line item containing amount, price, and selected discount codes</param>
        /// <param name="thisAmount">The pre initialized 0 line subtotal value</param>
        /// <returns>Line subtotal after discounts were apoplied</returns>
        private static double discountApplied(Line line, double thisAmount)
        {
            thisAmount += line.Quantity * line.Bike.Price;
            if (line.DiscountCode.Contains(DiscountCode.None))
            { //A discount code of none should override any other codes possibly selected
                return thisAmount;
            }
            DiscountCode[] distinctDiscounts = line.DiscountCode.Distinct().ToArray();  //Remove any duplicate discount codes applied
            foreach (DiscountCode dis in distinctDiscounts)
            {
                switch (dis)
                {
                    case DiscountCode.Quantity:
                        switch (line.Bike.Price)
                        {
                            case Bike.OneThousand:
                                if (line.Quantity >= 20)
                                    thisAmount *= .9d;
                                break;
                            case Bike.TwoThousand:
                                if (line.Quantity >= 10)
                                    thisAmount *= .8d;
                                break;
                            case Bike.FiveThousand:
                                if (line.Quantity >= 5)
                                    thisAmount *= .8d;
                                break;
                        }
                        break;
                    case DiscountCode.LoyalCustomer:
                        thisAmount *= .95d;
                        break;
                    case DiscountCode.TRUser:
                        thisAmount *= .95d;
                        break;
                    case DiscountCode.ZwiftUser:
                        thisAmount *= 1.15d;
                        break;
                    default:
                        break;
                }
            }
            return thisAmount;
        }

    }
}
