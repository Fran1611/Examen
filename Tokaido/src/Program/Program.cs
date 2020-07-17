using System;
using System.Collections.Generic;
using Library;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Mountain mountainOne = new Mountain("Los Andes",2,1);
            Mountain mountainTwo = new Mountain("Everest",1,2);

            Ocean oceanOne = new Ocean("Atlantico",3,3);
            Ocean oceanTwo = new Ocean("Pacifico",4,4);
            Ocean oceanThree = new Ocean("Indico",1,5);

            
            FarmStation granja = new FarmStation("La Joaquina",3,6,3);
            ThermalWaterStation dayman = new ThermalWaterStation("Termas del Dayman,",4,7,3);

            SingleTraveler fran = new SingleTraveler("Fran");

           /* mountainOne.EnterPlayer(fran);
            mountainOne.AssignPointsToTravelers();
            mountainOne.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            mountainTwo.EnterPlayer(fran);
            mountainTwo.AssignPointsToTravelers();
            mountainTwo.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            oceanOne.EnterPlayer(fran);
            oceanOne.AssignPointsToTravelers();
            oceanOne.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            oceanTwo.EnterPlayer(fran);
            oceanTwo.AssignPointsToTravelers();
            oceanTwo.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            oceanThree.EnterPlayer(fran);
            oceanThree.AssignPointsToTravelers();
            oceanThree.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            granja.EnterPlayer(fran);
            granja.AssingPointsAndCoinsToTravelers();
            granja.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            //Console.WriteLine(fran.Coins.Count);

            dayman.EnterPlayer(fran);
            dayman.AssingPointsAndCoinsToTravelers();
            dayman.ExitPlayer(fran);
            Console.WriteLine(fran.Score);
            Console.WriteLine("Coins" + fran.Coins);*/




        }
    }
}
