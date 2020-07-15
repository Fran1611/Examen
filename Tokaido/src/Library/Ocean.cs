
namespace Library
{
    public class Ocean : Landscape
    {
        public Ocean (string name, int capacity, int position) : base(name,capacity,position)
        {
        }
        public int Points{get;set;}
        public override void AssignPointsToPlayers()
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