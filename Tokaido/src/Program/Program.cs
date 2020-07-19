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
            Farm farm = new Farm("La Joaquina",3,5,3);
            ThermalWater dayman = new ThermalWater("Termas del Dayman,",4,6,3);

            // Viajeros.
            SingleTraveler fran = new SingleTraveler("Fran");
            SingleTraveler juan =  new SingleTraveler("Juan");
            SingleTraveler pedro = new SingleTraveler("Pedro");

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
            road.AddTravelers(pedro);
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
            pedro.TravelerMove(1);
            pedro.TravelerMove(2);
            pedro.TravelerMove(3);
            pedro.TravelerMove(4);
            pedro.TravelerMove(5);
            pedro.TravelerMove(6);
            pedro.TravelerMove(7);
            
            winners = road.Winners;
            Console.WriteLine($"Puntajes finales: {fran.Score}, {juan.Score}, {pedro.Score}");

            foreach(Traveler traveler in winners)
            {
                Console.WriteLine($" el ganador es {traveler.Name} con {traveler.Score} puntos");
            }





        }
    }
}
