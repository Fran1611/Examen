using System.Collections.Generic;
namespace Library
{
    public class ThermalWaterStation : Station
    {
        public ThermalWaterStation (string name,int capacity, int position, int points) : base(name,capacity,position)
        {
            Points = points;
        }   
        
        public int Points {get;set;}
        public override void AssignPoints()
        {
            foreach (Traveler traveler in this.Travelers)
            {
                if (!(this.TravelersWithPoint.Contains(traveler)))
                {
                    this.TravelersWithPoint.Add(traveler);
                    traveler.Score += (this.Points);
                }
            }  
        }
    }
}
