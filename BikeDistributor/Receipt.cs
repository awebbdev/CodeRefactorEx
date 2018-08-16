using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    public class Receipt
    {

        public Receipt(Order order)
        {
            Order = order;
            BuildReceipt();
        }

        private Order Order { get; set; }
        public string Header { get; private set; }
        public List<string> OrderLines { get; private set; }
        public string SubTotal { get; private set; }
        public string TaxTotal { get; private set; }
        public string Total { get; private set; }

        private void BuildReceipt()
        {
            Header = string.Format("Order Receipt for {0}{1}", Order.Company, Environment.NewLine);
            OrderLines = new List<string>();
            foreach (var line in Order.Lines)
            {
                OrderLines.Add(string.Format("{0} x {1} {2} = {3}", line.Quantity, line.Bike.Brand, line.Bike.Model, line.LineAmount.ToString("C")));
            }
            SubTotal = string.Format("Sub-Total: {0}", Order.SubTotal.ToString("C"));
            TaxTotal = string.Format("Tax: {0}", Order.TaxAmount.ToString("C"));
            Total = string.Format("Total: {0}", Order.Total.ToString("C"));
        }

        public string PlainText()
        {
            var result = new StringBuilder(Header);
            foreach (var line in OrderLines)
            {
                result.AppendLine(string.Format("\t{0}", line));
            }            
            result.AppendLine(SubTotal);
            result.AppendLine(TaxTotal);
            result.Append(Total);
            return result.ToString();
        }

        public string Html()
        {
            var result = new StringBuilder(string.Format("<html><body><h1>{0}</h1>", Header));
            if (OrderLines.Any())
            {
                result.Append("<ul>");
                foreach (var line in OrderLines)
                {
                    result.Append(string.Format("<li>{0}</li>", line));
                }
                result.Append("</ul>");
            }
            result.Append(string.Format("<h3>{0}</h3>", SubTotal));
            result.Append(string.Format("<h3>{0}</h3>", TaxTotal));
            result.Append(string.Format("<h2>{0}</h2>", Total));
            result.Append("</body></html>");
            return result.ToString();
        }

    }
}
