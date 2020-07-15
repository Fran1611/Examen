using System;
using System.Collections.Generic;
using Library;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Mountain mountainOne = new Mountain("Los Andes",2,0);
            Mountain mountainTwo = new Mountain("Everest",1,1);

            Ocean oceanOne = new Ocean("Atlantico",3,0);
            Ocean oceanTwo = new Ocean("Pacifico",4,1);
            Ocean oceanThree = new Ocean("Indico",1,2);

            Coin coin1 = new Coin(TypeOfCoin.SimpleCoin);
            Coin coin2 = new Coin(TypeOfCoin.SimpleCoin);
            Coin coin3 = new Coin(TypeOfCoin.SimpleCoin);
            List<Coin> coinsList = new List<Coin>{coin1,coin2,coin3};
            FarmStation granja = new FarmStation("La Joaquina",3,3,coinsList);
            ThermalWaterStation dayman = new ThermalWaterStation("Termas del Dayman,",4,4,2);

            TravelerOne fran = new TravelerOne("Fran");

            mountainOne.EnterPlayer(fran);
            mountainOne.AssignPointsToPlayers();
            mountainOne.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            mountainTwo.EnterPlayer(fran);
            mountainTwo.AssignPointsToPlayers();
            mountainTwo.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            oceanOne.EnterPlayer(fran);
            oceanOne.AssignPointsToPlayers();
            oceanOne.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            oceanTwo.EnterPlayer(fran);
            oceanTwo.AssignPointsToPlayers();
            oceanTwo.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            oceanThree.EnterPlayer(fran);
            oceanThree.AssignPointsToPlayers();
            oceanThree.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            granja.EnterPlayer(fran);
            granja.AssingPointsAndCoinsToPlayer();
            granja.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            dayman.EnterPlayer(fran);
            dayman.AssingPointsAndCoinsToPlayer();
            dayman.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            Console.WriteLine("Coins" + fran.Coins.Count);




        }
    }
}
