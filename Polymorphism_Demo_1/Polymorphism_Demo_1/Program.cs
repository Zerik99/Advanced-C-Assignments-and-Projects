using System;

namespace Polymorphism_Demo_1
{

    /*
     Polymorphism is often referred to as the third pillar of object-oriented programming,
    after encapsulation and inheritance. Polymorphism is a Greek word that means "many-shaped" and it has two distinct aspects:

    1- At run time, objects of a derived class may be treated as objects of a base class
    in places such as method parameters and collections or arrays. When this polymorphism occurs, 
    the object's declared type is no longer identical to its run-time type.
    
    2- Base classes may define and implement virtual methods, and derived classes can override them, 
    which means they provide their own definition and implementation. At run-time, when client code calls the method, 
    the CLR looks up the run-time type of the object, and invokes that override of the virtual method. In your source code you can call a method on a 
    base class, and cause a derived class's version of the method to be executed.*/
   
    
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Automobile { Make = "Ford", Model = "Tauras", Year = 2020 };
            // car.Display();
            print(car);

            var suv = new Suv { Make = "Ford", Model = "Expidition", Year = 2019 };
            suv.DriveMachanism = "4 Wheel Drive";
            //suv.Display();
            print(suv);

            Console.ReadLine();
        }

        private static void print(Automobile auto) 
        {
            auto.Display();
        }
    }

    internal class Suv:Automobile
    {
       
        public string DriveMachanism { get; set; }

        internal override void Display()
        {
            Console.WriteLine($"suv: {Make}_{Model}_{Year}_{DriveMachanism}");
        }

       
    }

    internal class Automobile
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        internal virtual void Display()
        {
            Console.WriteLine($"car: {Make}_{Model}_{Year}");
        }
    }
}
