using System.Collections.Generic;
namespace Library
{
    public class FarmStation : Station
    {

        public FarmStation (string nameStation,int capacity, int position, List<Coin> coins) : base(nameStation,capacity, position)
        {
            StationCoins = coins;
        }
        
        public List<Coin> StationCoins{get;set;}
        public override void AssingPointsAndCoinsToPlayer()
        {
            foreach (Player player in this.Players)
            {
                if (!(this.PlayersWithPoint.Contains(player)))
                {
                    this.PlayersWithPoint.Add(player);
                    
                    if (this.StationCoins != null)
                    { 
                        player.AddCoins(this.StationCoins);
                    }
                }
            }  
        }
    }
}