namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel) { }

        public override double FuelConsumption 
        { 
            get => base.FuelConsumption; 
            set =>  base.FuelConsumption = 8; 
        
        }

    }
}
