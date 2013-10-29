namespace Aevitas.Builder
{
    public class LunchMealBuilder : IBuilder
    {
        private readonly Meal _meal = new Meal();

        public void AddDrink()
        {
            _meal.Drink = Drink.Coffee;
        }

        public void AddMainDish()
        {
            _meal.MainDish = MainDish.Sandwich;
        }

        public void AddSideDish()
        {
            _meal.SideDish = SideDish.Fries;
        }

        public void AddSauces()
        {
            _meal.Sauce = Sauce.Mayonnaise;
        }

        public Meal GetMeal()
        {
            return _meal;
        }
    }
}
