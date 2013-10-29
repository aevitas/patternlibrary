namespace Aevitas.Builder
{
    public class MunchMealBuilder : IBuilder
    {
        private readonly Meal _meal = new Meal();

        public void AddDrink()
        {
            _meal.Drink = Drink.Soda;
        }

        public void AddMainDish()
        {
            _meal.MainDish = MainDish.Burger;
        }

        public void AddSideDish()
        {
            _meal.SideDish = SideDish.ChickenWings;
        }

        public void AddSauces()
        {
            _meal.Sauce = Sauce.Ketchup;
        }

        public Meal GetMeal()
        {
            return _meal;
        }
    }
}
