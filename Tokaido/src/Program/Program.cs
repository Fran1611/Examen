using System;
using System.Collections.Generic;
using Library;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Mountain mountainOne = new Mountain(2);
            Mountain mountainTwo = new Mountain(1);

            Ocean oceanOne = new Ocean(3);
            Ocean oceanTwo = new Ocean(4);
            Ocean oceanThree = new Ocean(1);

            Station stationOne = new Station(TypeOfStation.ThermalWater,2,3,null);
            Coin coin1 = new Coin(TypeOfCoin.SimpleCoin);
            Coin coin2 = new Coin(TypeOfCoin.SimpleCoin);
            Coin coin3 = new Coin(TypeOfCoin.SimpleCoin);
            List<Coin> coinsList = new List<Coin>{coin1,coin2,coin3};
            Station stationTwo = new Station(TypeOfStation.Farm,3,0,coinsList);

            Traveler fran = new Traveler("Fran");

            mountainOne.AddPlayer(fran);
            mountainOne.AssignPoints();
            fran.GoOutLandscapeOrStation(mountainOne);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            mountainTwo.AddPlayer(fran);
            mountainTwo.AssignPoints();
            fran.GoOutLandscapeOrStation(mountainTwo);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            oceanOne.AddPlayer(fran);
            oceanOne.AssignPoints();
            fran.GoOutLandscapeOrStation(oceanOne);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            oceanTwo.AddPlayer(fran);
            oceanTwo.AssignPoints();
            fran.GoOutLandscapeOrStation(oceanTwo);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            oceanThree.AddPlayer(fran);
            oceanThree.AssignPoints();
            fran.GoOutLandscapeOrStation(oceanThree);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            stationOne.AddPlayer(fran);
            stationOne.AssingPointsAndCoins();
            fran.GoOutLandscapeOrStation(stationOne);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            stationTwo.AddPlayer(fran);
            stationTwo.AssingPointsAndCoins();
            fran.GoOutLandscapeOrStation(stationTwo);
            Console.WriteLine(fran.Score);
            Console.WriteLine("Coins" + fran.Coins.Count);




        }
    }
}
