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
        /// <summary>
        /// Print a plain text receipt
        /// </summary>
        /// <returns>Plain Text Receipt String</returns>
        public string Receipt()
        {
            PlainTextReceipt plainTextReceipt = new PlainTextReceipt(this);
            return plainTextReceipt.PrintReceipt();
        }
        /// <summary>
        /// Print an HTML formatted receipt string
        /// </summary>
        /// <returns>An HTML formatted receipt string</returns>
        public string HtmlReceipt()
        {
            HtmlReceipt htmlReceipt = new HtmlReceipt(this);
            return htmlReceipt.PrintReceipt();
        } 

    }
}
