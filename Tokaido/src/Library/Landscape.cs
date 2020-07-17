using System.Collections.Generic;
namespace Library
{
    public abstract class Landscape
    {
        public Landscape(string name, int capacity, int position)
        {
            Capacity = capacity;
            Name = name;
            Position = position;
        }
        private List<Traveler> travelers = new List<Traveler>();
        private List<Traveler> travelersWithPoint = new List<Traveler>();
        public List<Traveler> Travelers 
        {
            get{return travelers;}
            set{travelers = value;}
        }
        public List<Traveler> TravelersWithPoint
        {
            get{return travelersWithPoint;}
            set{travelersWithPoint = value;}
        }
        public int Capacity{get;set;}
        public string Name{get;set;}
        
        public int Position{get;set;}
        public abstract void AssignPointsToTravelers();

        public virtual bool EnterTraveler(Traveler traveler)
        {
            if(traveler.TravelerMove(this.Position))
            {
                if (Travelers.Count < Capacity)
                {
                    this.Travelers.Add(traveler);
                    
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public virtual void ExitTraveler(Traveler traveler)
        {
            this.Travelers.Remove(traveler);
            this.TravelersWithPoint.Remove(traveler);
        }
    }
}