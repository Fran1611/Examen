
namespace Library
{
    public class Ocean : Landscape
    {
        public Ocean (int capacity)
        {
            this.Capacity = capacity;
        }
        public override void AssignPoints()
        {
            foreach(Player player in this.players)
            {
                if (!(this.PlayersWithPoint.Contains(player)))
                {
                    player.Score = player.Score + 1;
                    this.PlayersWithPoint.Add(player);
                    player.OceansVisited +=1;
                }
            }
        }
    }
}