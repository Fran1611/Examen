
namespace Library
{
    public class Mountain : Landscape
    {
        public Mountain(string name, int capacity, int position) : base(name,capacity,position)
        {
        }

        public override void AssignPoints()
        {
            foreach(Traveler traveler in this.Travelers)
            {
                if (!(this.TravelersWithPoint.Contains(traveler)))
                {
                    traveler.Score += traveler.OceansVisited + 1;
                    this.TravelersWithPoint.Add(traveler);
                    traveler.OceansVisited += 1;
                }
            }
        }  
    }
}