using System.Collections.Generic;

namespace BikeDistributor
{
    public enum Price
    {
        OneThousand, TwoThousand, FiveThousand, TenThousand
    }
    public class Bike
    {          
        public Bike(string brand, string model, Price price)
        {
            Brand = brand;
            Model = model;
            Price = price;
            LoadPrices();
        }

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public Price Price { get; private set; }
        public IDictionary<Price, int> PriceList { get; private set; }
        
        private void LoadPrices()
        {
            PriceList = new Dictionary<Price, int>
            {
                { Price.OneThousand, 1000 },
                { Price.TwoThousand, 2000 },
                { Price.FiveThousand, 5000 },
                { Price.TenThousand, 10000 }
            };
        }
    }


}
