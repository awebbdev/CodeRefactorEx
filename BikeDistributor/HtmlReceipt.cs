using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    /// <summary>
    /// A class to return an HTML formatted receipt
    /// </summary>
    class HtmlReceipt : Receipt, IReceipt
    {
        public HtmlReceipt(Order order)
        {
            Order = order;
        }
        /// <summary>
        /// Builds and returns an HTML formated receipt
        /// </summary>
        /// <returns>An HTML formatted receipt</returns>
        public string PrintReceipt()
        {
            ReceiptResult.Append(string.Format("<html><body><h1>Order Receipt for {0}</h1>", Order.Company));
            PrintLines();
            ReceiptResult.Append(string.Format("<h3>Sub-Total: {0}</h3>", TotalAmount.ToString("C")));
            ReceiptResult.Append(string.Format("<h3>Tax: {0}</h3>", CalculateTax().ToString("C")));
            ReceiptResult.Append(string.Format("<h2>Total: {0}</h2>", TotalAmount.ToString("C")));
            ReceiptResult.Append("</body></html>");
            return ReceiptResult.ToString();
        }
        /// <summary>
        /// Processes each line item if any for an order and appends to the string builder object
        /// </summary>
        private void PrintLines()
        {
            if (Order.Lines.Any())
            {
                ReceiptResult.Append("<ul>");
                foreach (var line in Order.Lines)
                {
                    ReceiptResult.Append(string.Format("<li>{0} x {1} {2} = {3}</li>", line.Quantity, line.Bike.Brand, line.Bike.Model, CalculateLineTotals(line).ToString("C")));
                }
                ReceiptResult.Append("</ul>");
            }
        }
    }
}
