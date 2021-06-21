using System;

namespace Encapsulation_Demo
{
    class Program
    {
        /*
           * 
           * 
          Encapsulation is sometimes referred to as the first pillar
          or principle of object oriented programming.
          according to the principle of encapsulation, a class or struct 
          can specify how accessible each of its members is to code outside of the calss or struct.

          Methods and variables that are not intended to be used from the outside of the class
          or assemble can be hidden to limit the potential for coding errors or exploits. 

          used to hide the implementation details of a class/method.

           */
        static void Main(string[] args)
        {

            var car = new Car() {MyProperty = 10};
            car.Display();

        }


    }

    class Car 
    {
        private int myVar;

        public int MyProperty
        {
            
            get 
            {
                //only reveal this to 
                //users with certain rights.
                //if(user.role = "admin")

                return myVar; 
            }
                set 
            {   
                //Does this value make sense?
                //if (value<0 or > 200)
                myVar = value; 
            }
        }

        //public int myOtherVar { get; set; }

        public void Display()
        {
            var value = CreateDisplay();
            Console.WriteLine(value);
        }

        private string CreateDisplay()
        {
            return $"Car : {myVar}";
        }
    }
}
