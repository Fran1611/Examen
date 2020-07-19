using System.Collections.Generic;
namespace Library
{
    public class EndPosition : Experience
    {
        private EndPosition(string name, int capacity, int position) : base (name,capacity,position)
        {

        }

        private static EndPosition instance = null;  

        public static EndPosition Instance(string name, int capacity, int position)
        {   
            if (instance == null)  
            {  
                instance = new EndPosition(name,capacity,position);     
            }  
            
            return instance;  
            
        }

        public override void Update(Traveler observable)
        {
            if(observable.Position == this.Position)
            {
                if (this.Capacity > this.Travelers.Count)
                {
                    EnterTraveler(observable);
                    if (this.Capacity == this.Travelers.Count)
                    {
                        Notify();
                    }
                }
            }
        }

        public List<Traveler> WinningTraveler()
        {   
            int maxScore = 0;
            List<Traveler> winners = new List<Traveler>();

            foreach(Traveler traveler in this.Travelers)
            {
                if (traveler.Score > maxScore)
                {
                    winners.Clear();
                    maxScore = traveler.Score;
                    winners.Add(traveler);
                }
                else if(traveler.Score == maxScore)
                {
                    winners.Add(traveler);
                }
            }
            return winners;
        }

        private Road observers;
        public void AddObserver(Road observer)
        {
            observers = observer;
        }


        public void Notify()
        {
            observers.Update(this); 
        }
    }
}