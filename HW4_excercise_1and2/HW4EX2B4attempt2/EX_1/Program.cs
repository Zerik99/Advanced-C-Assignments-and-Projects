using System;

namespace EX_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrderComboWithDrink orderComboWithDrinkObj = new ComboWithDrink();
            IOrderCombo orderComboObj = new ComboOrderService();
            IOrderFries orderFriesObj = new FriesOrderService();
            IOrderBurger orderBurgerObj = new BurgerOrderService();

            orderBurgerObj.orderBurger(2);       // only want a burger only order
            orderFriesObj.orderFries(0);            // throws an exception
            orderComboObj.orderBurger(2);
            orderComboObj.orderFries(1);
        }
    }

    interface IOrderComboWithDrink : IOrderCombo, IOrderDrink
    {

    }
    interface IOrderCombo : IOrderBurger, IOrderFries
    {


    }
    interface IOrderBurger
    {
        void orderBurger(int quantity);
    }
    interface IOrderFries
    {
        void orderFries(int fries);
    }
    interface IOrderDrink
    {
        void orderDrink(int quantity);
    }

    public class ComboWithDrink : IOrderComboWithDrink
    {
        public void orderFries(int fries)
        {
            Console.WriteLine($"Received order for {fries} Fries.");
        }
        public void orderBurger(int quantity)
        {
            Console.WriteLine($"Received order for {quantity} Burgers.");
        }
        public void orderDrink(int quantity)
        {
            Console.WriteLine($"Received order for {quantity} Drink(s).");
        }
    }
    public class FriesOrderService : IOrderFries
    {
        public void orderFries(int fries)
        {
            Console.WriteLine($"Received order for {fries} Fries.");
        }
    }
    public class ComboOrderService : IOrderCombo
    {
        public void orderFries(int fries)
        {
            Console.WriteLine($"Received order for {fries} Fries.");
        }
        public void orderBurger(int quantity)
        {
            Console.WriteLine($"Received order for {quantity} Burgers.");
        }
    }
    public class BurgerOrderService : IOrderBurger
    {
        public void orderBurger(int quantity)
        {
            Console.WriteLine($"Received order for {quantity} Burgers.");
        }
    }
}
