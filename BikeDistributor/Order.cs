using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class Order
    {
        public IList<Line> Lines { get; private set; }

        public Order(string company)
        {
            Company = company;
            Lines = new List<Line>();
        }

        public string Company { get; private set; }

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
