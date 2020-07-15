using System.Collections.Generic;
namespace Library
{
    public abstract class Landscape
    {
        private int position;
        public Landscape(string name, int capacity, int position)
        {
            Capacity = capacity;
            Name = name;
        }
        public List<Player> players = new List<Player>();
        public int Capacity{get;set;}
        public string Name{get;set;}
        public List<Player> PlayersWithPoint = new List<Player>();

        public int Position
        {
            get
            {
                return position;
            }
            
            set
            {
                if (value>0)
                {
                    position = value;                    
                }
            }
        }
        public abstract void AssignPointsToPlayers();

        public void EnterPlayer(Player traveler)
        {
            if (players.Count < Capacity)
            {
                this.players.Add(traveler);
            }
        }
        public void ExitPlayer(Player traveler)
        {
            this.players.Remove(traveler);
            this.PlayersWithPoint.Remove(traveler);
        }
    }
}