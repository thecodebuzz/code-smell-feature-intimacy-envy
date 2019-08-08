using System;

namespace ConsoleApp3
{
    class FeatureEnvy
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Bad
    {
        class Item
        {
            public bool IsOutOfStock;
            public decimal Price;
            public decimal Tax;
            public bool IsOnSale;
            public decimal SaleDiscount;
        }

        class Basket
        {
            decimal GetTotalPrice(Item i)
            {
                //Item class instances is being used multiple time in another instance of class
                //There are total 4 count of occurr instances 
                if (i.IsOutOfStock) //1 
                    throw new Exception("Item ${i} is out of stock.");
                var price = i.Price + i.Tax;//2
                if (i.IsOnSale)//3
                    price = price - i.SaleDiscount * price;//4
                return price;
            }
        }
    }

    class Good
    {
        class Item
        {
            public bool IsOutOfStock;
            public decimal Price;
            public decimal Tax;
            public bool IsOnSale;
            public decimal SaleDiscount;

            decimal GetTotalPrice(Item i)
            {
                if (i.IsOutOfStock)
                    throw new Exception("Item ${i} is out of stock.");
                var price = i.Price + i.Tax;
                if (i.IsOnSale)
                    price = price - i.SaleDiscount * price;
                return price;
            }
        }
    }



}
namespace FeatureEnvySmell
{

    class ContactInfo
    {
        public string GetStreetName()
        {
            return "Medison Square";
        }
        public string GetCity()
        {
            return "NewYork";
        }
        public string GetState()
        {
            return "NY";
        }
    }

    class User
    {
        private ContactInfo _contactInfo;
        User(ContactInfo contactInfo)
        {
            _contactInfo = contactInfo;
        }
        public string GetFullAddress(ContactInfo info)
        {
            string city = info.GetCity();//1
            string state = info.GetState();//2
            string streetName = info.GetStreetName();//3
            return streetName + ";" + city + ";" + state;
        }

    }

}

namespace FeatureEnvySmellResolved
{

    class ContactInfo
    {
        public string GetStreetName()
        {
            return "Medison Square";
        }
        public string GetCity()
        {
            return "Newyork";
        }
        public string GetState()
        {
            return "CT";
        }
        public string GetFullAddress(ContactInfo info)
        {
            string city = info.GetCity();//1
            string state = info.GetState();//2
            string streetName = info.GetStreetName();//3
            return streetName + ";" + city + ";" + state;
        }
    }

    class User
    {
        private ContactInfo _contactInfo;
        User(ContactInfo contactInfo)
        {
            _contactInfo = contactInfo;
        }
    }

}
