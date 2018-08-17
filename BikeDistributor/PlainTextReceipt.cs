using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    /// <summary>
    /// A class to provide a plain text receipt
    /// </summary>
    class PlainTextReceipt : Receipt, IReceipt
    {
        public PlainTextReceipt(Order order)
        {
            Order = order;
        }
        /// <summary>
        /// Builds a plain text formatted receipt string
        /// </summary>
        /// <returns>A plain text Receipt string</returns>
        public string PrintReceipt()
        {
            ReceiptResult.Append(string.Format("Order Receipt for {0}{1}", Order.Company, Environment.NewLine));
            PrintLines();
            ReceiptResult.AppendLine(string.Format("Sub-Total: {0}", TotalAmount.ToString("C")));
            ReceiptResult.AppendLine(string.Format("Tax: {0}", CalculateTax().ToString("C")));
            ReceiptResult.Append(string.Format("Total: {0}", TotalAmount.ToString("C")));
            return ReceiptResult.ToString();
        }
        /// <summary>
        /// Processes each line item and adds to the string builder object
        /// </summary>
        private void PrintLines()
        {
            foreach (var line in Order.Lines)
            {
                ReceiptResult.AppendLine(string.Format("\t{0} x {1} {2} = {3}", line.Quantity, line.Bike.Brand, line.Bike.Model, CalculateLineTotals(line).ToString("C")));
            }
        }
    }
}
