using System.Collections.Generic;

namespace Library
{
    public abstract class Station
    {

        private int position;
        public Station(string nameStation,int capacity, int position)
        {
            Capacity = capacity;
            NameStation = nameStation;
            Position = position;
        }

        public string NameStation{get;set;}
        public int Capacity {get;set;}
        public List<Player> Players = new List<Player>();
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
        // Ingreso de jugador a la estación.
        public void EnterPlayer(Player player)
        {
            if (Players.Count < Capacity)
            {
                this.Players.Add(player);
            }
        }

        // Salida de Jugador de la estación.
        public void ExitPlayer(Player player)
        {
            this.Players.Remove(player);
            this.PlayersWithPoint.Remove(player);
        }

        // Asignar puntos y monedas a jugadores en la estación.
        public abstract void AssingPointsAndCoinsToPlayer();       
    }
}