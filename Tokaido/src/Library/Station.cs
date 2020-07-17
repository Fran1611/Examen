using System.Collections.Generic;

namespace Library
{
    public abstract class Station : Experience, IObserver
    {

        public Station(string name,int capacity, int position): base (name,capacity,position)
        {
        }
        private List<Traveler> travelersWithPoint = new List<Traveler>();
        
        public List<Traveler> TravelersWithPoint {get{return travelersWithPoint;}}

        public override void ExitTraveler(Traveler player)
        {
            this.Travelers.Remove(player);
            this.TravelersWithPoint.Remove(player);
        }
        
        
    }
}