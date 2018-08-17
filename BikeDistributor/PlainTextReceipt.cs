using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    class PlainTextReceipt : Receipt, IReceipt
    {
        public PlainTextReceipt(Order order)
        {
            Order = order;
        }

        public string PrintReceipt()
        {
            ReceiptResult.AppendLine(string.Format("Order Receipt for {0}{1}", Order.Company, Environment.NewLine));
            PrintLines();
            ReceiptResult.AppendLine(string.Format("Sub-Total: {0}", TotalAmount.ToString("C")));
            ReceiptResult.AppendLine(string.Format("Tax: {0}", CalculateTax().ToString("C")));
            ReceiptResult.Append(string.Format("Total: {0}", TotalAmount.ToString("C")));
            return ReceiptResult.ToString();
        }

        private void PrintLines()
        {
            foreach (var line in Order.Lines)
            {
                ReceiptResult.AppendLine(string.Format("\t{0} x {1} {2} = {3}", line.Quantity, line.Bike.Brand, line.Bike.Model, CalculateLineTotals(line).ToString("C")));
            }
        }
    }
}
