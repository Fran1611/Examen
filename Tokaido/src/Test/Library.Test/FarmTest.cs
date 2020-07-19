using NUnit.Framework;
using Library;
namespace Library.Test
{
    public class FarmTest
    {

        SingleTraveler traveler1;
        SingleTraveler traveler2;

        Farm FarmOne;
        Farm FarmTwo;
        Farm FarmThree;

        Road road;
        

        [SetUp]
        public void Setup()
        {
            traveler1 = new SingleTraveler("Fran");
            traveler2 = new SingleTraveler("Juan");
            FarmOne = new Farm("Granja",2,1,3);
            FarmTwo = new Farm("GranjaDos",2,2,3);
            FarmThree = new Farm("GranjaTres",1,3,3);

            road = new Road();
            road.AddTravelers(traveler1);
            road.AddTravelers(traveler2);
            road.AddExperience(FarmOne);
            road.AddExperience(FarmTwo);
            road.AddExperience(FarmThree);
            road.LoadObservers();
        }

        /// <summary>
        /// Test que verifica la asignación de monedas.
        /// </summary>
        [Test]
        public void AssignPointsToTravelersTest()
        {
            traveler1.TravelerMove(1);
            traveler2.TravelerMove(1);
            
            Assert.AreEqual(traveler1.Coins, 3);
            Assert.AreEqual(traveler2.Coins, 3);
        }

        /// <summary>
        /// Test que verifica la asignación de puntos cuando un Viajero pasa por varias Granjas.
        /// </summary>
        [Test]
        public void FarmAssignPointsTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(3);

            Assert.AreEqual(traveler1.Coins, 9);
        }

        /// <summary>
        /// Test que verifica que un Viajero no puede entrar a una Granja anterior.
        /// </summary>
        [Test]
        public void EnterTravelerTest()
        {
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(1);
            bool expected = FarmTwo.Travelers.Contains(traveler1);
            bool expectedTwo = FarmOne.Travelers.Contains(traveler1);

            Assert.AreEqual(expected,true);
            Assert.AreEqual(expectedTwo,false);
        }

        /// <summary>
        ///  Test que verifica que un Viajero puede entrar a cualquier Farm que se encuentra despues.
        /// </summary>
        [Test]
        public void EnterTravelerTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(3);
            bool expected = FarmThree.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
        }

        /// <summary>
        /// Test que verifica que si la Granja está completa no puede entrar otro Viajero.
        /// </summary>
        [Test]
        public void EnterTravelerTestThree()
        {
            traveler1.TravelerMove(3);
            traveler2.TravelerMove(3);
            bool expected = FarmThree.Travelers.Contains(traveler1);
            bool expectedTwo = FarmThree.Travelers.Contains(traveler2);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expectedTwo);
        }

        /// <summary>
        /// Test que verifica que cuando Viajero se mueve a otro Farm, es eliminado del que estaba anteriormente 
        /// </summary>
        [Test]
        public void DeleteTraveler()
        {
            traveler1.TravelerMove(1);
            bool expected = FarmOne.Travelers.Contains(traveler1);
            traveler1.TravelerMove(2);
            bool expectedTwo = FarmOne.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expectedTwo);
        }   
    }
}