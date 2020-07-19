using System.Collections.Generic;
namespace Library
{
    public abstract class Landscape : Experience
    {
        public Landscape(string name, int capacity, int position) : base(name,capacity,position)
        {
        }

        private List<Traveler> travelersWithPoint = new List<Traveler>();
        public List<Traveler> TravelersWithPoint
        {
            get{return travelersWithPoint;}
        }
        public void ExitTraveler(Traveler traveler)
        {
            this.Travelers.Remove(traveler);
            this.TravelersWithPoint.Remove(traveler);
        }

        public abstract void AssignPoints();
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