
namespace Library
{
    public class Mountain : Landscape
    {
        public Mountain(string name, int capacity, int position) : base(name,capacity,position)
        {
        }

        public override void AssignPointsToPlayers()
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