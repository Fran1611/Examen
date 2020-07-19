using NUnit.Framework;
using Library;
namespace Library.Test
{
    public class MountainTest
    {

        SingleTraveler traveler1;
        SingleTraveler traveler2;

        Road road;
        MountainLandscape mountainOne;
        MountainLandscape mountainTwo;
        MountainLandscape mountainThree;

        [SetUp]
        public void Setup()
        {
            traveler1 = new SingleTraveler("Fran");
            traveler2 = new SingleTraveler("Juan");
            
            mountainOne = new MountainLandscape("Everest",2,1);
            mountainTwo = new MountainLandscape("Los Andes",1,2);
            mountainThree = new MountainLandscape("Himalaya",3,3);

            road = new Road();
            road.AddTravelers(traveler1);
            road.AddTravelers(traveler2);
            road.AddExperience(mountainOne);
            road.AddExperience(mountainTwo);
            road.AddExperience(mountainThree);
            road.LoadObservers();
        }

        /// <summary>
        /// Test que verifica la asignacion de puntos de paisaje Montaña.
        /// </summary>
        [Test]
        public void AssignPointsToTravelersTest()
        {
            traveler1.TravelerMove(1);
            traveler2.TravelerMove(1);
            
            Assert.AreEqual(traveler1.Score, 1);
            Assert.AreEqual(traveler2.Score, 1);
        }
        
        /// <summary>
        /// Test que verifica la asignacion de puntos cuando un Viajero ingresa mas de una vez a un paisaje Montaña.
        /// </summary>
        [Test]
        public void AssignPointsToTravelersTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(3);

            Assert.AreEqual(6,traveler1.Score);
        }

        /// <summary>
        /// Test que verifica que un Viajero no puede entrar a un paisaje Montaña anterior.
        /// </summary>
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

        /// <summary>
        /// Test que verifica que un Viajero puede entrar a cualquier paisaje Montaña que se encuentra despues.
        /// </summary>
        [Test]
        public void EnterTravelerTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(3);
            bool expected = mountainThree.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
        }

        /// <summary>
        /// Test que verifica que si el paisaje Montaña está completo no puede entrar otro Viajero.
        /// </summary>
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

        /// <summary>
        /// Test que verifica que cuando Viajero se mueve a otro Paisaje, es eliminado del Paisaje en el que estaba
        /// </summary>
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