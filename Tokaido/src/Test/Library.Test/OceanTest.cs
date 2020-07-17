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
        [SetUp]
        public void Setup()
        {
            traveler1 = new SingleTraveler("Fran");
            traveler2 = new SingleTraveler("Juan");
            oceanOne = new Ocean("Atlantico",3,3);
            oceanTwo = new Ocean("Pacifico",4,4);
            oceanThree = new Ocean("Indico",1,5);
        }

        // Asignacion de puntos de paisaje Oceano con dos jugadores que ingresan en distinto momento.
        [Test]
        public void AssignPointsToTravelersTest()
        {
            oceanOne.EnterTraveler(traveler1);
            oceanOne.AssignPointsToTravelers();

            oceanOne.EnterTraveler(traveler2);
            oceanOne.AssignPointsToTravelers();

            Assert.AreEqual(traveler1.Score,1);
            Assert.AreEqual(traveler2.Score, 1);
        }

        [Test]
        public void AssignPointsToTravelersTestThree()
        {
            oceanOne.EnterTraveler(traveler1);
            oceanOne.EnterTraveler(traveler2);
            
            oceanOne.AssignPointsToTravelers();

            Assert.AreEqual(traveler1.Score,1);
            Assert.AreEqual(traveler2.Score, 1);
        }

        // Asignacion de puntos cuando un jugador ingresa mas de una vez a un paisaje Oceano.
        [Test]
        public void AssignPointsToTravelersTestTwo()
        {
            oceanOne.EnterTraveler(traveler1);
            oceanOne.AssignPointsToTravelers();
            oceanOne.ExitTraveler(traveler1);

            oceanTwo.EnterTraveler(traveler1);
            oceanTwo.AssignPointsToTravelers();
            oceanTwo.ExitTraveler(traveler1);

            oceanThree.EnterTraveler(traveler1);
            oceanThree.AssignPointsToTravelers();

            Assert.AreEqual(9,traveler1.Score);
        }

        // Prueba que un jugador no puede entrar a un paisaje Oceano anterior.
        [Test]
        public void EnterTravelerTest()
        {
            oceanTwo.EnterTraveler(traveler1);
            oceanOne.EnterTraveler(traveler1);

            bool expectedOne = oceanTwo.Travelers.Contains(traveler1);
            bool expectedTwo = oceanOne.Travelers.Contains(traveler1);

            Assert.AreEqual(expectedOne,true);
            Assert.AreEqual(expectedTwo,false);
        }

        // Prueba que un jugador puede entrar a cualquier paisaje Oceano que se encuentra despues.
        [Test]
        public void EnterTravelerTestTwo()
        {
            oceanTwo.EnterTraveler(traveler2);
            oceanThree.EnterTraveler(traveler2);

            bool expectedOne = oceanTwo.Travelers.Contains(traveler2);
            bool expectedTwo = oceanThree.Travelers.Contains(traveler2);

            Assert.AreEqual(true,expectedOne);
            Assert.AreEqual(true,expectedTwo);
        }

        // Prueba que si el paisaje Oceano está completo no puede entrar otro jugador.
        [Test]
        public void EnterTravelerTestThree()
        {
            bool expectedOne = oceanThree.EnterTraveler(traveler1);
            bool expectedTwo = oceanThree.EnterTraveler(traveler2);

            bool expectedThree = oceanThree.Travelers.Contains(traveler1);
            bool expectedFour = oceanThree.Travelers.Contains(traveler2);

            Assert.AreEqual(true,expectedOne);
            Assert.AreEqual(false,expectedTwo);
            Assert.AreEqual(true,expectedThree);
            Assert.AreEqual(false,expectedFour);
        }
    }
}