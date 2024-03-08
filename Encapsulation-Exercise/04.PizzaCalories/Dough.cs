using System.Data;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double BaseCalories = 2.0;
		private readonly string flourType;
		private string bakingTechnique;
		private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            init
            {
                if (value.ToLower() != "white" || value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                if (value.ToLower() != "chewy" ||
                    value.ToLower() != "crispy" ||
                    value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentOutOfRangeException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public double CaloriesPerGram 
		{
			get
			{
				double calsPerGram = BaseCalories;

				if (flourType.ToLower() == "white")
				{
					calsPerGram *= 1.5;
				}				

                if (bakingTechnique.ToLower() == "crispy")
                {
                    calsPerGram *= 0.9;
                }
                else if (bakingTechnique.ToLower() == "chewy")
                {
                    calsPerGram *= 1.1;
                }               
				return calsPerGram;
            }
		}


    }
}
