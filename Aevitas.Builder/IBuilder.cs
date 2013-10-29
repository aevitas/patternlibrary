namespace Aevitas.Builder
{
    public interface IBuilder
    {
        void AddDrink();
        void AddMainDish();
        void AddSideDish();
        void AddSauces();

        Meal GetMeal();
    }
}
