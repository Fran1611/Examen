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

            EndPosition fin =  EndPosition.Instance("Fin",1,8);

            EndPosition fin2 = EndPosition.Instance("fin222",2,0);

            SingleTraveler fran = new SingleTraveler("Fran");

            /*fran.AddObserver(mountainOne);
            fran.AddObserver(mountainTwo);
            fran.AddObserver(oceanOne);
            fran.AddObserver(oceanTwo);
            fran.AddObserver(oceanThree);
            fran.AddObserver(fin);

            fran.TravelerMove(1);
            Console.WriteLine(mountainOne.Travelers[0].Name);
            fran.TravelerMove(2);
            Console.WriteLine(mountainTwo.Travelers[0].Name);
            Console.WriteLine(mountainOne.Travelers.Count);

            fran.TravelerMove(8);

            List<Traveler> winners = fin.WinningTraveler();
            Console.WriteLine(winners[0].Name);*/

            Console.WriteLine(fin.Name);
            Console.WriteLine(fin2.Name);


            



        }
    }
}
