using System.Collections.Generic;
namespace Library
{
    public abstract class Landscape
    {
        public List<Player> players = new List<Player>();
        public int Capacity{get;set;}
        public List<Player> PlayersWithPoint = new List<Player>();

        public abstract void AssignPoints();

        public void AddPlayer(Player player)
        {
            if (players.Count < Capacity)
            {
                this.players.Add(player);
            }
        }
        public void RemovePlayer(Player player)
        {
            this.players.Remove(player);
            this.PlayersWithPoint.Remove(player);
        }
    }
}