using System.Collections.Generic;
namespace Library
{
    public class FarmStation : Station
    {

        public FarmStation (string name,int capacity, int position, int coins) : base(name,capacity, position)
        {
            Coins = coins;
        }
        
        public int Coins{get;set;}

        public override void AssignPoints()
        {
            foreach (Traveler traveler in this.Travelers)
            {
                if (!(this.TravelersWithPoint.Contains(traveler)))
                {
                    this.TravelersWithPoint.Add(traveler);
                    
                    if (this.Coins != 0)
                    { 
                        traveler.Coins += this.Coins;
                    }
                }
            }  
        }
    }
}