using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public enum ReceiptType
    {
        PlainText, HTML
    }
    public class Order
    {
        private const double TaxRate = .0725d;

        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; private set; }
        public IList<Line> Lines { get; } = new List<Line>();
        public double TaxAmount { get; private set; } = .0d;
        public double Total { get; private set; } = .0d;
        public double SubTotal { get; private set; } = .0d;

        public void AddLine(Line line)
        {
            Lines.Add(line);
            SubTotal += line.LineAmount;
        }

        private void TotalOut()
        {
            TaxAmount += SubTotal * TaxRate;
            Total += SubTotal + TaxAmount;
        }

        public string Receipt(ReceiptType rtype)
        {
            TotalOut();
            Receipt rec = new Receipt(this);
            switch (rtype)
            {
                case ReceiptType.PlainText:
                    return rec.PlainText();
                case ReceiptType.HTML:
                    return rec.Html();
                default:
                    return "";

            }
        }


    }
}
