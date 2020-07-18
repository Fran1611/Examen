using System;
using System.Collections.Generic;
using Library;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Experiencias.
            Mountain mountainOne = new Mountain("Los Andes",2,1);
            Mountain mountainTwo = new Mountain("Everest",1,2);
            Ocean oceanOne = new Ocean("Atlantico",3,3);
            Ocean oceanTwo = new Ocean("Pacifico",4,4);
            FarmStation farm = new FarmStation("La Joaquina",3,5,3);
            ThermalWaterStation dayman = new ThermalWaterStation("Termas del Dayman,",4,6,3);

            // Viajeros.
            SingleTraveler fran = new SingleTraveler("Fran");
            SingleTraveler juan =  new SingleTraveler("Juan");

            List<Traveler> winners = new List<Traveler>();

            // El Camino.
            Road road = new Road();
            road.AddExperience(mountainOne);
            road.AddExperience(mountainTwo);
            road.AddExperience(oceanOne);
            road.AddExperience(oceanTwo);
            road.AddExperience(farm);
            road.AddExperience(dayman);

            road.AddTravelers(fran);
            road.AddTravelers(juan);
            road.FinalPositionOfRoad();
            road.LoadObservers();
            

            fran.TravelerMove(1);
            juan.TravelerMove(2);
            fran.TravelerMove(2);
            juan.TravelerMove(3);
            fran.TravelerMove(5);
            juan.TravelerMove(6);
            fran.TravelerMove(7);
            juan.TravelerMove(7);
            
            winners = road.Winners;
            foreach(Traveler traveler in winners)
            {
                Console.WriteLine(traveler.Name);
            }





        }
    }
}
