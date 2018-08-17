using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    class HtmlReceipt : Receipt, IReceipt
    {
        public HtmlReceipt(Order order)
        {
            Order = order;
        }

        public string PrintReceipt()
        {
            ReceiptResult.Append(string.Format("<html><body><h1>Order Receipt for {0}</h1>", Order.Company));
            PrintLines();
            ReceiptResult.AppendLine(string.Format("<h3>Sub-Total: {0}</h3>", TotalAmount.ToString("C")));
            ReceiptResult.AppendLine(string.Format("<h3>Tax: {0}</h3>", CalculateTax().ToString("C")));
            ReceiptResult.Append(string.Format("<h2>Total: {0}</h2>", TotalAmount.ToString("C")));
            ReceiptResult.Append("</body></html>");
            return ReceiptResult.ToString();
        }

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
