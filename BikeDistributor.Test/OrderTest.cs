using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class OrderTest
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", Price.OneThousand);
        private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", Price.TwoThousand);
        private readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", Price.FiveThousand);

        [TestMethod]
        public void ReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1, new DiscountCode[] { DiscountCode.TRUser }));
            Assert.AreEqual(ResultStatementOneDefy, order.Receipt(ReceiptType.PlainText));
        }

        private const string ResultStatementOneDefy = @"Order Receipt for Anywhere Bike Shop
	1 x Giant Defy 1 = $950.00
Sub-Total: $950.00
Tax: $68.88
Total: $1,018.88";

        [TestMethod]
        public void ReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1, new DiscountCode[]{ DiscountCode.LoyalCustomer }));
            Assert.AreEqual(ResultStatementOneElite, order.Receipt(ReceiptType.PlainText));
        }

        private const string ResultStatementOneElite = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized Venge Elite = $1,900.00
Sub-Total: $1,900.00
Tax: $137.75
Total: $2,037.75";

        [TestMethod]
        public void ReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1, new DiscountCode[] { DiscountCode.None }));
            Assert.AreEqual(ResultStatementOneDuraAce, order.Receipt(ReceiptType.PlainText));
        }

        private const string ResultStatementOneDuraAce = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized S-Works Venge Dura-Ace = $5,000.00
Sub-Total: $5,000.00
Tax: $362.50
Total: $5,362.50";

        [TestMethod]
        public void ReceiptFiveDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 5, new DiscountCode[] { DiscountCode.Quantity, DiscountCode.LoyalCustomer }));
            Assert.AreEqual(ResultStatementFiveDuraAce, order.Receipt(ReceiptType.PlainText));
        }

        private const string ResultStatementFiveDuraAce = @"Order Receipt for Anywhere Bike Shop
	5 x Specialized S-Works Venge Dura-Ace = $19,000.00
Sub-Total: $19,000.00
Tax: $1,377.50
Total: $20,377.50";

        [TestMethod]
        public void ReceiptMultipleBikes()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1, new DiscountCode[] { DiscountCode.LoyalCustomer }));
            order.AddLine(new Line(Elite, 1, new DiscountCode[] { DiscountCode.LoyalCustomer }));
            Assert.AreEqual(ResultStatementMultipleBikes, order.Receipt(ReceiptType.PlainText));
        }

        private const string ResultStatementMultipleBikes = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized S-Works Venge Dura-Ace = $4,750.00
	1 x Specialized Venge Elite = $1,900.00
Sub-Total: $6,650.00
Tax: $482.13
Total: $7,132.13";

        [TestMethod]
        public void HtmlReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1, new DiscountCode[] { DiscountCode.LoyalCustomer }));
            Assert.AreEqual(HtmlResultStatementOneDefy, order.Receipt(ReceiptType.HTML));
        }

        private const string HtmlResultStatementOneDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $950.00</li></ul><h3>Sub-Total: $950.00</h3><h3>Tax: $68.88</h3><h2>Total: $1,018.88</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1, new DiscountCode[] { DiscountCode.None }));
            Assert.AreEqual(HtmlResultStatementOneElite, order.Receipt(ReceiptType.HTML));
        }

        private const string HtmlResultStatementOneElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1, new DiscountCode[] { }));
            Assert.AreEqual(HtmlResultStatementOneDuraAce, order.Receipt(ReceiptType.HTML));
        }

        private const string HtmlResultStatementOneDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>";    
    }
}


