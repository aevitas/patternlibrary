namespace Aevitas.Builder
{
    public class Meal
    {
        public MainDish MainDish { get; set; }
        public Sauce Sauce { get; set; }
        public Drink Drink { get; set; }
        public SideDish SideDish { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Main dish: {0} - Side dish: {1} - Drink: {2} - Sauce: {3}", MainDish, SideDish, Drink,
                Sauce);
        }
    }

    public enum Drink
    {
        Soda,
        Milkshake,
        Coffee,
        Rum
    }

    public enum MainDish
    {
        Burger,
        Sandwich,
        Hotdog,
        Pancake,
        Sausage
    }

    public enum Sauce
    {
        Mayonnaise,
        Ketchup,
        Barbecue,
        Soy
    }

    public enum SideDish
    {
        Fries,
        ChickenWings,
        Pork
    }
}
