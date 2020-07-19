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
            MountainLandscape mountainOne = new MountainLandscape("Los Andes",2,1);
            MountainLandscape mountainTwo = new MountainLandscape("Everest",1,2);
            OceanLandscape oceanOne = new OceanLandscape("Atlantico",3,3);
            OceanLandscape oceanTwo = new OceanLandscape("Pacifico",4,4);
            Farm farm = new Farm("La Joaquina",3,5,3);
            ThermalWater dayman = new ThermalWater("Termas del Dayman,",4,6,3);

            // Viajeros.
            SingleTraveler fran = new SingleTraveler("Fran");
            SingleTraveler juan =  new SingleTraveler("Juan");
            SingleTraveler pedro = new SingleTraveler("Pedro");

            List<Traveler> players = new List<Traveler>();
            players.Add(fran);
            players.Add(juan);
            players.Add(pedro);
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
            
            // Movimiento de Jugadores.
            fran.TravelerMove(1);
            juan.TravelerMove(2);
            pedro.TravelerMove(1);

            fran.TravelerMove(2);
            juan.TravelerMove(3);
            pedro.TravelerMove(2);


            fran.TravelerMove(5);
            juan.TravelerMove(6);
            pedro.TravelerMove(3);
            
            fran.TravelerMove(7);
            juan.TravelerMove(7);
            pedro.TravelerMove(4);
            pedro.TravelerMove(5);
            pedro.TravelerMove(6);
            pedro.TravelerMove(7);
            
            winners = road.Final.Winners;

            // Ganador o Ganadores.
            Console.WriteLine("Los Puntajes Finales son: ");
            foreach(Traveler traveler in players)
            {
                Console.WriteLine($"{traveler.Name}: {traveler.Score}");       
            }
            

            foreach(Traveler traveler in winners)
            {
                Console.WriteLine($"El ganador es {traveler.Name} con {traveler.Score} puntos");
            }





        }
    }
}
