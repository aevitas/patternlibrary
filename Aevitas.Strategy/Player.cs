namespace Aevitas.Strategy
{
    public class Player
    {
        public StrategyBase CurrentStrategy { get; set; }
        public int Health = 100;

        public void TakeHit(StrategyBase bodyPart, int count)
        {
            CurrentStrategy = bodyPart;
            Health -= CurrentStrategy.CalculateDamage(count);
        }
    }
}
