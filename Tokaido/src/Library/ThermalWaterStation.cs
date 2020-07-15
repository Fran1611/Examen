using System.Collections.Generic;
namespace Library
{
    public class ThermalWaterStation : Station
    {
        public ThermalWaterStation (string nameStation,int capacity, int position, int points) : base(nameStation,capacity,position)
        {
            StationPoints = points;
        }   
        
        public int StationPoints {get;set;}
        public override void AssingPointsAndCoinsToPlayer()
        {
            foreach (Player player in this.Players)
            {
                if (!(this.PlayersWithPoint.Contains(player)))
                {
                    this.PlayersWithPoint.Add(player);
                    player.Score += (this.StationPoints);
                }
            }  
        }
    }
}
