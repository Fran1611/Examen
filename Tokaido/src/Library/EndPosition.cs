using System.Collections.Generic;
namespace Library
{
    public class EndPosition : Experience
    {
        public EndPosition(string name, int capacity, int position) : base (name,capacity,position)
        {

        }

        public override void Update(IObservable observable)
        {
            if((observable as Traveler).Position == this.Position)
            {
                this.EnterTraveler(observable as Traveler);
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
    }
}