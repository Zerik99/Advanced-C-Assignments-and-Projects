using System;

namespace Inheritance_Demo_2
{

    /*
    Introduce two new keywords:

    Override: the override omdifier is required to extend or modify the abstract or virtual implementation of an inherited method,
    property, indexer, or event.

    Virtual: the virtual keyword is used to modify a method, property, indexer, or evenet declaration
    and allow for it to be overridden in a derived class. 
    for example, this method can be overridden by and class that inherits it. 
    when  avirtual method is invoked,
    the runtime type of the object is checked for an overriding member.

    you cannot override a non-virtual or static method. 
    The overridden base method must be virtual, abstract, or override. 

     */


    class Program
    {
        static void Main(string[] args)
        {
            var auto = new Automobile
            {
                Make = "Ford",
                Model = "Taurus",
                Year = 2020,
            };
            auto.Drive();

            Console.WriteLine();

            var truck = new Truck()
            {
                Make = "Ford",
                Model = "F-150",
                Year = 2020,
                TowingCapacity = 1000,
            };
            Console.WriteLine();
            truck.Tow();
            truck.Drive();
            Console.WriteLine("=========================");

            DoDrive(auto);
            DoDrive(truck);

            
        }
        private static void DoDrive(Automobile a)
        {
            a.Drive();
        }
    }
    internal class Truck : Automobile
    {
        public Truck()
        {
        }

        public int TowingCapacity { get; set; }
        public int CargoSize { get; set; }

        public void Tow()
        {
            Console.WriteLine($"Now we are towing {TowingCapacity} pounds....");
        }

        public override void Drive()
        {
            Console.WriteLine($"The Truck {Year} {Make} {Model} is Hauling");
        }


    }

    internal class Automobile
    {
        public Automobile()
        {
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public virtual void Drive()
        {
            Console.WriteLine($"The {Year} {Make} {Model} is Driving. ");
        }




    }


}
