using NUnit.Framework;
using Library;
namespace Library.Test
{
    public class MountainTest
    {

        SingleTraveler traveler1;
        SingleTraveler traveler2;

        Road road;
        Mountain mountainOne;
        Mountain mountainTwo;
        Mountain mountainThree;

        [SetUp]
        public void Setup()
        {
            traveler1 = new SingleTraveler("Fran");
            traveler2 = new SingleTraveler("Juan");
            
            mountainOne = new Mountain("Everest",2,1);
            mountainTwo = new Mountain("Los Andes",1,2);
            mountainThree = new Mountain("Himalaya",3,3);

            road = new Road();
            road.AddTravelers(traveler1);
            road.AddTravelers(traveler2);
            road.AddExperience(mountainOne);
            road.AddExperience(mountainTwo);
            road.AddExperience(mountainThree);
            road.LoadObservers();
        }

        // Asignacion de puntos de paisaje Montaña mas de un jugador.
        [Test]
        public void AssignPointsToTravelersTest()
        {
            traveler1.TravelerMove(1);
            traveler2.TravelerMove(1);
            
            Assert.AreEqual(traveler1.Score, 1);
            Assert.AreEqual(traveler2.Score, 1);
        }
        
        // Asignacion de puntos cuando un jugador ingresa mas de una vez a un paisaje Montaña.
        [Test]
        public void AssignPointsToTravelersTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(3);

            Assert.AreEqual(6,traveler1.Score);
        }

        // Prueba que un jugador no puede entrar a un paisaje Montaña anterior.
        [Test]
        public void EnterTravelerTest()
        {
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(1);
            bool expected = mountainTwo.Travelers.Contains(traveler1);
            bool expectedTwo = mountainOne.Travelers.Contains(traveler1);

            Assert.AreEqual(expected,true);
            Assert.AreEqual(expectedTwo,false);
        }

        // Prueba que un jugador puede entrar a cualquier paisaje Montaña que se encuentra despues.
        [Test]
        public void EnterTravelerTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(3);
            bool expected = mountainThree.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
        }



        // Prueba que si el paisaje Montaña está completo no puede entrar otro jugador.
        [Test]
        public void EnterTravelerTestThree()
        {
            traveler1.TravelerMove(2);
            traveler2.TravelerMove(2);
            bool expected = mountainTwo.Travelers.Contains(traveler1);
            bool expectedTwo = mountainTwo.Travelers.Contains(traveler2);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expectedTwo);
        }

        // Prueba que cuando Viajero se mueve a otro Paisaje, es eliminado del Paisaje en el que estaba
        [Test]
        public void DeleteTraveler()
        {
            traveler1.TravelerMove(1);
            bool expected = mountainOne.Travelers.Contains(traveler1);
            traveler1.TravelerMove(2);
            bool expectedTwo = mountainOne.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expectedTwo);
        }
    }
}