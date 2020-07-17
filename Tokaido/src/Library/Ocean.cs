
namespace Library
{
    public class Ocean : Landscape
    {
        public Ocean (string name, int capacity, int position) : base(name,capacity,position)
        {
        }
        public int Points{get;set;}

        public override void AssignPoints()
        {
            foreach(Traveler traveler in this.Travelers)
            {
                if (!(this.TravelersWithPoint.Contains(traveler)))
                {
                    traveler.Score = (traveler.Score + (traveler.MontainsVisited*2) + 1);
                    this.TravelersWithPoint.Add(traveler);
                    traveler.MontainsVisited += 1;
                }
            }
        }
    }
}