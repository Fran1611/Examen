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

        // Asignacion de puntos de Farm con mas de un jugador.
        [Test]
        public void AssignPointsToTravelersTest()
        {
            traveler1.TravelerMove(1);
            traveler2.TravelerMove(1);
            
            Assert.AreEqual(traveler1.Coins, 3);
            Assert.AreEqual(traveler2.Coins, 3);
        }

        // Asignacion de puntos cuando un viajero entra a varias granjas.
        [Test]
        public void FarmAssignPointsTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(3);

            Assert.AreEqual(traveler1.Coins, 9);
        }

        // Prueba que un viajero no puede entrar a un Farm anterior.
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

        // Prueba que un jugador puede entrar a cualquier Farm que se encuentra despues.
        [Test]
        public void EnterTravelerTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(3);
            bool expected = FarmThree.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
        }

        // Prueba que si el Farm está completo no puede entrar otro jugador.
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

        // Prueba que cuando Viajero se mueve a otro Farm, es eliminado del que estaba anteriormente
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