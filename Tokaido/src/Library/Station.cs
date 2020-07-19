using System.Collections.Generic;

namespace Library
{
    public abstract class Station : Experience
    {

        public Station(string name,int capacity, int position): base (name,capacity,position)
        {
        }
        private List<Traveler> travelersWithPoint = new List<Traveler>();
        
        public List<Traveler> TravelersWithPoint {get{return travelersWithPoint;}}

        public abstract void AssignPoints();
        
        // Salida de Jugador de la estación.
        public void ExitTraveler(Traveler traveler)
        {
            this.Travelers.Remove(traveler);
            this.TravelersWithPoint.Remove(traveler);
        }
        public override void Update(Traveler observable)
        {
            if(observable.Position == this.Position)
            {
                this.EnterTraveler(observable);
                AssignPoints();
            }
            else if (this.Travelers.Contains(observable))
            {
                this.ExitTraveler(observable);
            }
        }
    }
}