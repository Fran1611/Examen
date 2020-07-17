using NUnit.Framework;
using Library;
namespace Library.Test
{
    public class MountainTest
    {

        SingleTraveler traveler1;
        SingleTraveler traveler2;

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
        }

        // Asignacion de puntos de paisaje Oceano con dos jugadores que ingresan en distinto momento.
        [Test]
        public void AssignPointsToTravelersTest()
        {
            mountainOne.EnterTraveler(traveler1);
            mountainOne.AssignPointsToTravelers();

            mountainOne.EnterTraveler(traveler2);
            mountainOne.AssignPointsToTravelers();

            Assert.AreEqual(traveler1.Score,1);
            Assert.AreEqual(traveler2.Score, 1);
        }

        [Test]
        public void AssignPointsToTravelersTestThree()
        {
            mountainOne.EnterTraveler(traveler1);
            mountainOne.EnterTraveler(traveler2);
            
            mountainOne.AssignPointsToTravelers();

            Assert.AreEqual(traveler1.Score,1);
            Assert.AreEqual(traveler2.Score, 1);
        }

        // Asignacion de puntos cuando un jugador ingresa mas de una vez a un paisaje Oceano.
        [Test]
        public void AssignPointsToTravelersTestTwo()
        {
            mountainOne.EnterTraveler(traveler1);
            mountainOne.AssignPointsToTravelers();
            mountainOne.ExitTraveler(traveler1);

            mountainTwo.EnterTraveler(traveler1);
            mountainTwo.AssignPointsToTravelers();
            mountainTwo.ExitTraveler(traveler1);

            mountainThree.EnterTraveler(traveler1);
            mountainThree.AssignPointsToTravelers();

            Assert.AreEqual(6,traveler1.Score);
        }

        // Prueba que un jugador no puede entrar a un paisaje Oceano anterior.
        [Test]
        public void EnterTravelerTest()
        {
            mountainTwo.EnterTraveler(traveler1);
            mountainOne.EnterTraveler(traveler1);

            bool expectedOne = mountainTwo.Travelers.Contains(traveler1);
            bool expectedTwo = mountainOne.Travelers.Contains(traveler1);

            Assert.AreEqual(expectedOne,true);
            Assert.AreEqual(expectedTwo,false);
        }

        // Prueba que un jugador puede entrar a cualquier paisaje Oceano que se encuentra despues.
        [Test]
        public void EnterTravelerTestTwo()
        {
            mountainTwo.EnterTraveler(traveler2);
            mountainThree.EnterTraveler(traveler2);

            bool expectedOne = mountainTwo.Travelers.Contains(traveler2);
            bool expectedTwo = mountainThree.Travelers.Contains(traveler2);

            Assert.AreEqual(true,expectedOne);
            Assert.AreEqual(true,expectedTwo);
        }

        // Prueba que si el paisaje Oceano está completo no puede entrar otro jugador.
        [Test]
        public void EnterTravelerTestThree()
        {
            bool expectedOne = mountainTwo.EnterTraveler(traveler1);
            bool expectedTwo = mountainTwo.EnterTraveler(traveler2);

            bool expectedThree = mountainTwo.Travelers.Contains(traveler1);
            bool expectedFour = mountainTwo.Travelers.Contains(traveler2);

            Assert.AreEqual(true,expectedOne);
            Assert.AreEqual(false,expectedTwo);
            Assert.AreEqual(true,expectedThree);
            Assert.AreEqual(false,expectedFour);
        }
 
    }
}