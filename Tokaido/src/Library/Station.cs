using System.Collections.Generic;

namespace Library
{
    public abstract class Station
    {

        public Station(string name,int capacity, int position)
        {
            Capacity = capacity;
            Name = name;
            Position = position;
        }

        public string Name{get;set;}
        public int Capacity {get;set;}
        private List<Traveler> travelers = new List<Traveler>();
        private List<Traveler> travelersWithPoint = new List<Traveler>();
        
        public List<Traveler> Travelers
        {
            get{return travelers;}
            //set{travelers = value;}
        }
        public List<Traveler> TravelersWithPoint
        {
            get{return travelersWithPoint;}
            //set{travelersWithPoint = value;}
        }
        public int Position{get;set;}


        
        // Ingreso de jugador a la estación.
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

        // Salida de Jugador de la estación.
        public virtual void ExitTraveler(Traveler player)
        {
            this.Travelers.Remove(player);
            this.TravelersWithPoint.Remove(player);
        }

        // Asignar puntos y monedas a jugadores en la estación.
        public abstract void AssingPointsAndCoinsToTravelers();       
    }
}