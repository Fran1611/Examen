using System.Collections.Generic;
namespace Library
{
    public class FarmStation : Station
    {

        public FarmStation (string nameStation,int capacity, int points, List<Coin> coins) : base(nameStation,capacity,points,coins)
        {
        }
        

        public override void AssingPointsAndCoinsToPlayer()
        {
            foreach (Player player in this.Players)
            {
                if (!(this.PlayersWithPoint.Contains(player)))
                {
                    this.PlayersWithPoint.Add(player);
                    player.Score += (this.StationPoints);
                    if (this.Coins != null)
                    { 
                        player.AddCoins(this.Coins);
                    }
                }
            }  
        }
    }
}