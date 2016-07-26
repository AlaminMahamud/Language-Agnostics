using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public interface Item
    {
        string Name();
        int ItemCost();
    }

    public interface Packing
    {
    }

    public abstract class Burger : Item
    {
        public virtual string Name()
        {
            return "Burger";
        }
        public virtual int ItemCost()
        {
            return 0;
        }
    }

    public abstract class ColdDrinks : Item
    {
        public virtual string Name()
        {
            return "ColdDrinks";
        }
        public virtual int ItemCost()
        {
            return 0;
        }
    }

    public class VegBurger : Burger
    {
        public override string Name()
        {
            return "Veg Burger";
        }
        public override int ItemCost()
        {
            return 10;
        }
    }

    public class NonVegBurger : Burger
    {
        public string Name()
        {
            return "Non Veg Burger";
        }
        public int ItemCost()
        {
            return 15;
        }
    }

    public class Coke : ColdDrinks
    {
        public override string Name()
        {
            return "Coke";
        }
        public override int ItemCost()
        {
            return 7;
        }
    }

    public class SevenUp : ColdDrinks
    {
        public override string Name()
        {
            return "Seven Up";
        }
        public override int ItemCost()
        {
            return 7;
        }
    }


    public class Wrapper : Packing { }

    public class Bottle : Packing { }

    public class Meal
    {
        public List<Item> Items = new List<Item>();
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void ShowItems()
        {
            foreach (Item i in Items)
            {
                Console.Write("{0} ",i.Name());
            }
            Console.WriteLine();
        }
        public int TotalCost()
        {
            int cost=0;
            foreach (Item i in Items)
            {
                cost += i.ItemCost();
            }

            Console.WriteLine(cost);

            return cost;
        } 


    }

    public class MealBuilder
    {
        public Meal PrepareVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Coke());
            return meal;
        }        
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            // This Guy only knows MealBuilder
            MealBuilder mealBuilder = new MealBuilder();

            // He Also Knows that he want's to have some sorts of Meal through the menu
            // now he wants veg burger but he does not know the name of veg Burger class
            // relax, he doesn't have to all job is done by meal builder and meal class
            // the waitress i.e mealBuilder will do the heavy job of arranging all the foods and return as a meal.


            Meal vegMeal = mealBuilder.PrepareVegMeal();
            Console.WriteLine("Preparing Vegetable Meal");
            vegMeal.ShowItems();
            Console.WriteLine("Total Costs : {0} ", vegMeal.TotalCost());
    

            // Now it's time for Non Veg;
        }
    }

}
