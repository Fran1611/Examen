using System.Collections.Generic;
namespace Library
{
    public abstract class Experience : IObserver
    {
        private int position;
        public Experience(string name, int capacity, int position)
        {
            Capacity = capacity;
            Name = name;
            Position = position;
        }

        public string Name{get;set;}
        public int Capacity {get;set;}
        private List<Traveler> travelers = new List<Traveler>();
        
        public List<Traveler> Travelers
        {
            get{return travelers;}
        }
        
        public int Position
        {
            get {return position;}
            
            set
            {
                if (value>0)
                {
                    position = value;
                }
            }
        }

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

        // Se recibe la notificación de que un jugador cambio de posición.
        public abstract void Update(IObservable observable);
      
    }
}