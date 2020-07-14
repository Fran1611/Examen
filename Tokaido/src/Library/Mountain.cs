
namespace Library
{
    public class Mountain : Landscape
    {
        public Mountain(int capacity)
        {
            this.Capacity = capacity;
        }

        
        public override void AssignPoints()
        {  
            foreach(Player player in this.players)
            {
                if (!(this.PlayersWithPoint.Contains(player)))
                {
                    
                    player.Score = player.Score + player.MontainsVisited*2 + 1;
                    this.PlayersWithPoint.Add(player);
                    player.MontainsVisited += 1;
                }
            }
        }
    }
}