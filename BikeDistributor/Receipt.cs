using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    class Receipt
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);

        static void Main()
        {
            string receipt = $"Brand: {Defy.Brand} \nModel: {Defy.Model}\nPrice: {Defy.Price.ToString()}";
            Console.WriteLine(receipt);
        }
    }
}
