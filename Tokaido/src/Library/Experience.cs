using System.Collections.Generic;
namespace Library
{
    public abstract class Experience
    {
        public Experience(string name, int capacity, int position)
        {
            Capacity = capacity;
            Name = name;
            Position = position;
        }

        public string Name{get;set;}
        public int Capacity {get;set;}
        private List<Traveler> travelers = new List<Traveler>();
        //private List<Traveler> travelersWithPoint = new List<Traveler>();
        
        public List<Traveler> Travelers
        {
            get{return travelers;}
            //set{travelers = value;}
        }
        /*public List<Traveler> TravelersWithPoint
        {
            get{return travelersWithPoint;}
            //set{travelersWithPoint = value;}
        }*/
        public int Position{get;set;}

        // Ingreso de jugador a la estación.
        public virtual bool EnterTraveler(Traveler traveler)
        { 
            if (Travelers.Count < Capacity)
            {
                this.Travelers.Add(traveler);
                return true;
            }
            else return false;
        }

        public abstract void AssignPoints();

        // Salida de Jugador de la estación.
        public abstract void ExitTraveler(Traveler player);

        // Se recibe la notificación de que un jugador cambio de posición.
        // Si la nueva posicion del jugador es la misma que la de la estación
        // el personaje entra en la estación
        public void Update(IObservable observable)
        {
            if((observable as Traveler).Position == this.Position)
            {
                this.EnterTraveler(observable as Traveler);
            }
            else if (this.Travelers.Contains(observable as Traveler))
            {
                this.ExitTraveler(observable as Traveler);
            }
        }
    }
}