namespace Aevitas.Builder
{
    public class BreakfastMealBuilder : IBuilder
    {
        private readonly Meal _meal = new Meal();

        public void AddDrink()
        {
            _meal.Drink = Drink.Rum;
        }

        public void AddMainDish()
        {
            _meal.MainDish = MainDish.Sausage;
        }

        public void AddSideDish()
        {
            _meal.SideDish = SideDish.Pork;
        }

        public void AddSauces()
        {
            _meal.Sauce = Sauce.Soy;
        }

        public Meal GetMeal()
        {
            return _meal;
        }
    }
}
