namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double BaseCalories = 2.0;

		private readonly string toppingType;
        private readonly double weight;

        public Topping( string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public double Weight
        {
            get => weight;
            init 
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentOutOfRangeException($"{value} weight should be in the range [1..50].");
                }
                weight = value; 
            }
        }


        public string ToppingType
        {
            get => toppingType;
            init 
            { 
                if (value.ToLower() != "meat" || 
                    value.ToLower() != "veggies" ||
                    value.ToLower() != "cheese" ||
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value; 
            }
        }

        public double CalculateCaloriesPerGram()
        {
            return ToppingType.ToLower() switch
            {
                "meat" => BaseCalories * 1.2,
                "veggies" => BaseCalories * 0.8,
                "cheese" => BaseCalories * 1.1,
                "sauce" => BaseCalories * 0.9
            };
        }
    }
}
