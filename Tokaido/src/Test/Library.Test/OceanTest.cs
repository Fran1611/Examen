using NUnit.Framework;
using Library;
namespace Library.Test
{
    public class OceanTest
    {
        SingleTraveler traveler1;
        SingleTraveler traveler2;
        Ocean oceanOne;
        Ocean oceanTwo;
        Ocean oceanThree;

        Road road;

        [SetUp]
        public void Setup()
        {
            traveler1 = new SingleTraveler("Fran");
            traveler2 = new SingleTraveler("Juan");
            
            oceanOne = new Ocean("Atlantico",3,1);
            oceanTwo = new Ocean("Pacifico",4,2);
            oceanThree = new Ocean("Indico",1,3);

            road = new Road();
            road.AddTravelers(traveler1);
            road.AddTravelers(traveler2);
            road.AddExperience(oceanOne);
            road.AddExperience(oceanTwo);
            road.AddExperience(oceanThree);
            road.LoadObservers();

        }
        
        // Asignacion de puntos de paisaje Oceano con dos jugadores que ingresan en distinto momento.
        [Test]
        public void AssignPointsToTravelersTest()
        {
            traveler1.TravelerMove(1);
            traveler2.TravelerMove(1);
            
            Assert.AreEqual(traveler1.Score, 1);
            Assert.AreEqual(traveler2.Score, 1);
        }

    
        // Asignacion de puntos cuando un jugador ingresa mas de una vez a un paisaje Oceano.
        [Test]
        public void AssignPointsToTravelersTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(3);
        
            Assert.AreEqual(9,traveler1.Score);
        }

        // Prueba que un jugador no puede entrar a un paisaje Oceano anterior.
        [Test]
        public void EnterTravelerTest()
        {
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(1);

            bool expected = oceanOne.Travelers.Contains(traveler1);

            Assert.AreEqual(expected,false);
        }

        // Prueba que un jugador puede entrar a cualquier paisaje Oceano que se encuentra despues.
        [Test]
        public void EnterTravelerTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(3);

            bool expected = oceanThree.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
        }

        // Prueba que si el paisaje Oceano está completo no puede entrar otro jugador.
        [Test]
        public void EnterTravelerTestThree()
        {
            traveler1.TravelerMove(3);
            traveler2.TravelerMove(3);

            bool expected = oceanThree.Travelers.Contains(traveler1);
            bool expectedTwo = oceanThree.Travelers.Contains(traveler2);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expectedTwo);
        }
        // Prueba que cuando Viajero se mueve a otro Paisaje, es eliminado del Paisaje en el que estaba
        [Test]
        public void DeleteTraveler()
        {
            traveler1.TravelerMove(1);
            bool expected = oceanOne.Travelers.Contains(traveler1);
            traveler1.TravelerMove(2);
            bool expectedTwo = oceanOne.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expectedTwo);
        }
    }
}