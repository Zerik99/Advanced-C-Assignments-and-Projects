using System;
using System.Collections.Generic;

namespace ADV_CSHARP_HW2_Unit_Testing
{
    public class HomeWork_2
    {
        static void Main(string[] args)
        {
            var appointment = new Appointment()
            {
                Name = "James",
                StartDateTime = DateTime.Now.AddHours(1),
                EndDateTime = DateTime.Now.AddHours(2),
                Price = 100D
            };

            var book = new Book()
            {
                Title = "Welcome to Advanced C#",
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
                ShippingRate = 2
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
            Console.WriteLine($"Total tax amount: {taxAmount.ToString("C")}");
            Console.WriteLine();

            var shippableItems = new List<IShippable>();
            foreach (var item in items)
            {
                if (item is IShippable)
                {
                    shippableItems.Add(item as IShippable);
                }
            }
            var shippingAmount = CalculateShipping(shippableItems);
            Console.WriteLine($"Total shipping amount: {shippingAmount.ToString("C")}");
            Console.WriteLine();

            var total = CompleteTransaction(items);

            var grandTotal = shippingAmount + taxAmount + total;
            Console.WriteLine("============");
            Console.WriteLine($"Grand Total: {grandTotal.ToString("C")}");
            Console.WriteLine();

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

        static double CompleteTransaction(List<IPurchasable> items)
        {
            var total = 0D;
            items.ForEach(p => p.Purchase());
            items.ForEach(p => total += p.Price);
            return total;
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
            Console.WriteLine($"Purchasing {Title} for {Price.ToString("C0")}.");
        }

        public double Ship()
        {
            Console.WriteLine($"    ShippingRate: {ShippingRate.ToString("C0")}");
            return ShippingRate;
        }

        public double Tax()
        {
            var tax = Price * TaxRate;
            Console.WriteLine($"    TaxRate: {TaxRate} = {tax}");
            return tax;
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
            Console.WriteLine($"Purchasing TShirt {Size} for {Price.ToString("C0")}.");
        }

        public double Ship()
        {
            Console.WriteLine($"    ShippingRate: {ShippingRate.ToString("C0")}");
            return ShippingRate;
        }

        public double Tax()
        {
            var tax = Price * TaxRate;
            Console.WriteLine($"    TaxRate: {TaxRate} = {tax}");
            return tax;
        }
    }

    public class Snack : IPurchasable
    {
        public double Price { get; set; }

        public void Purchase()
        {
            Console.WriteLine($"Purchasing a snack for {Price.ToString("C0")}.");
        }
    }

    public interface IPurchasable
    {
        double Price { get; set; }

        void Purchase();
    }

    public interface IShippable
    {
        double ShippingRate { get; set; }
        double Ship();
    }

    public interface ITaxable
    {
        double TaxRate { get; set; }
        double Tax();
    }
}
