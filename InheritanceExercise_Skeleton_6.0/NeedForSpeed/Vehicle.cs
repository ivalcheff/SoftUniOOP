namespace NeedForSpeed
{
    public class Vehicle
    {
        private double _fuelConsumption;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption 
        {
            get { return _fuelConsumption; } 
            set { _fuelConsumption = value;}
        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;

        }

    }
}
