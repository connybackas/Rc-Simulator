namespace RcSimulator.Implementation.RcCar
{
    /// <summary>
    /// Rc Monster Truck class which extends Car
    /// Currently not containing any special properties but it the future it might
    /// </summary>
    public class MonsterTruck : Car
    {
        public MonsterTruck(Heading heading, Position position) 
        {
           this.heading = heading;
           this.position = position;
        }

        public MonsterTruck(){}
    }
}