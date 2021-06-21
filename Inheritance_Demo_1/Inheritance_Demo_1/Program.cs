using System;

namespace Inheritance_Demo_1
{

    /*
     Inheritance is one of the fundamental attributes of Object oriented programming.
    it allows you to define a child class that reuses (inherits), extends, or modifies the behavior of a parent class.
    The class whose members are inherited is called the base class. 
    The class that inherits the members of the base class is called the derived class.
     */
    class Program
    {
        static void Main(string[] args)
        {
            // extending classes(Inheritance)

            var employee = new Employee();
            employee.DoWork();
            Console.WriteLine();

            // Base Class = employee
            //Base Class = Parent Class = SuperClass

            // Extended Class SoftwareDeveloper
            // Extended Class = Child Class = Subclass

            var dev = new SoftwareDeveloper();
            dev.DoWork();
            Console.WriteLine();
            dev.WriteCode();
            Console.WriteLine();

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

    internal class Truck:Automobile
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

    internal class SoftwareDeveloper : Employee
    {
        public SoftwareDeveloper()
        {
        }
        //While the child can access from the parent; 
        //the parent cannot inherit from the child. 
        public void WriteCode()
        {
            Console.WriteLine("Writing C# Code......");
        }
        

    }

    internal class Employee
    {
        public Employee()
        {

        }

        public void DoWork()
        {
            Console.WriteLine("Working");
        }
    }
}
