using System;
using System.Collections.Generic;

namespace HW1_exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var appointment = new Appointment()
            {
                Name = "Bob",
                StartDateTime = DateTime.Now.AddHours(1),
                EndDateTime = DateTime.Now.AddHours(2),
                Price = 100D
            };

            var book = new Book()
            {
                Title = "How to Implement Interfaces",
                Price = 50D,
                TaxRate = 0.0825D,
                ShippingRate = 5D

            };

            var snack = new Snack()
            {
                Price = 2D
            };

            var tshirt = new TShirt()
            {
                Size = "2X",
                Price = 25D,
                TaxRate = 0.0625D,
                ShippingRate = 2D,
                
            };
            

            var items = new List<IPurchasable>();
            items.Add(appointment);
            items.Add(book);
            items.Add(snack);
            items.Add(tshirt);
            

            var taxableItems = new List<ITaxable>();
            foreach (var item in items)
            {
                if (item is ITaxable)
                {
                    taxableItems.Add(item as ITaxable);
                }
            }
            var taxAmount = CalculateTax(taxableItems);
            Console.WriteLine($"Total tax amount: {taxAmount.ToString("C2")}");
            Console.WriteLine("=================");
            var shippableItems = new List<IShippable>();
            foreach (var item in items) 
            {
                if (item is IShippable) 
                {
                    shippableItems.Add(item as IShippable);
                }
            }

            var totalShipping = CalculateShipping(shippableItems);
            Console.WriteLine($"Total Shipping: {totalShipping.ToString("C2")}");
            Console.WriteLine("=================");
            CompleteTransaction(items);

            var grandTotal = tshirt.Price + book.Price + snack.Price + appointment.Price + taxAmount + totalShipping;

            Console.WriteLine("=================");
            Console.WriteLine($"Grand Total:{grandTotal.ToString("C2")} ");

            Console.ReadLine();
        }


        static double CalculateTax(List<ITaxable> items)
        {
            double tax = 0D;

            foreach (var item in items)
            {
                tax += item.Tax();
            }

            return tax;

        }

        static double CalculateShipping(List<IShippable> items)
        {
            double shipping = 0D;

            foreach (var item in items)
            {
                shipping += item.Ship();
            }

            return shipping;
        }

        static void CompleteTransaction(List<IPurchasable> items)
        {
            items.ForEach(p => p.Purchase());
        }
    }

    

    public class Appointment : IPurchasable
    {
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double Price { get; set; }

        public void Purchase()
        {
            Console.WriteLine($"Payment for Appointment for {Name} from {StartDateTime} to {EndDateTime} for {Price.ToString("C0")}.");
        }
    }

    public class Book : IPurchasable, ITaxable, IShippable
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public double TaxRate { get; set; }
        public double ShippingRate { get; set; }

        public void Purchase()
        {
            Console.WriteLine($"    Purchasing {Title} for {Price.ToString("C0")}.");
        }

        public double Tax()
        {
            var tax = Price * TaxRate;
            Console.WriteLine($"    TaxRate: {TaxRate} = {tax}");
            return tax;
        }
        public double Ship()
        {
            var shipping = ShippingRate;
            Console.WriteLine($"    Shipping Rate: ${ShippingRate}");
            return shipping;
        }
    }

    public class TShirt : IPurchasable, ITaxable, IShippable
    {
        public double Price { get; set; }
        public string Size { get; set; }
        public double TaxRate { get; set; }
        public double ShippingRate { get; set; }
       



        public void Purchase()
        {
            Console.WriteLine($"    Purchasing TShirt {Size} for {Price.ToString("C0")}.");
        }

        public double Tax()
        {
            var tax = Price * TaxRate;
            Console.WriteLine($"    TaxRate: {TaxRate} = {tax}");
            return tax;
        }

        public double Ship()
        {
            var shipping = ShippingRate;
            Console.WriteLine($"    Shipping Rate: ${ShippingRate}");
            return shipping;
        }
    }

    public class Snack : IPurchasable
    {
        public double Price { get; set; }

        public void Purchase()
        {
            Console.WriteLine($"    Purchasing a snack for {Price.ToString("C0")}.");
        }
    }
   
    interface IPurchasable
    {
        double Price { get; set; }

        void Purchase();
    }

    interface IShippable
    {
        double ShippingRate { get; set; }
        double Ship();
        
    }

    interface ITaxable
    {
        double TaxRate { get; set; }
        double Tax();
    }

    

}
