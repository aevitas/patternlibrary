namespace Aevitas.Builder
{
    public static class Orders
    {
        public static Meal MakeMeal(IBuilder mealBuilder)
        {
            mealBuilder.AddDrink();
            mealBuilder.AddMainDish();
            mealBuilder.AddSauces();
            mealBuilder.AddSideDish();

            return mealBuilder.GetMeal();
        }
    }
}
