using System.Collections.Generic;
namespace Library
{
    public abstract class Landscape : Experience, IObserver
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
        public override void Update(IObservable observable)
        {
            if((observable as Traveler).Position == this.Position)
            {
                this.EnterTraveler(observable as Traveler);
                AssignPoints();
            }
            if (this.Travelers.Contains(observable as Traveler))
            {
                this.ExitTraveler(observable as Traveler);
            }
        }
    }
}