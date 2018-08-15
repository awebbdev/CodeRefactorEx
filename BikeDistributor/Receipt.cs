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
        public string[] OrderLines { get; private set; }
        public string SubTotal { get; private set; }
        public string TaxTotal { get; private set; }
        public string Total { get; private set; }

        private void BuildReceipt()
        {
            Header = string.Format("Order Receipt for {0}{1}", Order.Company, Environment.NewLine);
        }


        public string PlainText()
        {

            var result = new StringBuilder();
            foreach (var line in Order.Lines)
            {
                result.AppendLine(string.Format("\t{0} x {1} {2} = {3}", line.Quantity, line.Bike.Brand, line.Bike.Model, line.LineAmount.ToString("C")));
            }
            result.AppendLine(string.Format("Sub-Total: {0}", Order.SubTotal.ToString("C")));
            result.AppendLine(string.Format("Tax: {0}", Order.TaxAmount.ToString("C")));
            result.Append(string.Format("Total: {0}", Order.Total.ToString("C")));
            return result.ToString();
        }

        public string Html()
        {
            var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", Order.Company));
            if (Order.Lines.Any())
            {
                result.Append("<ul>");
                foreach (var line in Order.Lines)
                {
                    result.Append(string.Format("<li>{0} x {1} {2} = {3}</li>", line.Quantity, line.Bike.Brand, line.Bike.Model, line.LineAmount.ToString("C")));
                }
                result.Append("</ul>");
            }
            result.Append(string.Format("<h3>Sub-Total: {0}</h3>", Order.SubTotal.ToString("C")));
            result.Append(string.Format("<h3>Tax: {0}</h3>", Order.TaxAmount.ToString("C")));
            result.Append(string.Format("<h2>Total: {0}</h2>", Order.Total.ToString("C")));
            result.Append("</body></html>");
            return result.ToString();
        }

    }
}
