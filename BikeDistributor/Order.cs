using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class Order
    {
        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; private set; }
        public IList<Line> Lines { get; private set; } = new List<Line>();

        public void AddLine(Line line)
        {
            Lines.Add(line);
        }

        public string Receipt()
        {
            PlainTextReceipt plainTextReceipt = new PlainTextReceipt(this);
            return plainTextReceipt.PrintReceipt();
        }

        public string HtmlReceipt()
        {
            HtmlReceipt htmlReceipt = new HtmlReceipt(this);
            return htmlReceipt.PrintReceipt();
        } 

    }
}
