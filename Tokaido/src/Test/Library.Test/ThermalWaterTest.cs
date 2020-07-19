using NUnit.Framework;
using Library;
namespace Library.Test
{
    public class ThermalWaterTest
    {

        SingleTraveler traveler1;
        SingleTraveler traveler2;
        ThermalWater thermalOne;
        ThermalWater thermalTwo;
        ThermalWater thermalThree;
        Road road;
        

        [SetUp]
        public void Setup()
        {
            traveler1 = new SingleTraveler("Fran");
            traveler2 = new SingleTraveler("Juan");
            thermalOne = new ThermalWater("Dayman",2,1,2);
            thermalTwo = new ThermalWater("Arapey",2,2,3);
            thermalThree = new ThermalWater("Guaviyu",1,3,4);
            road = new Road();
            road.AddTravelers(traveler1);
            road.AddTravelers(traveler2);
            road.AddExperience(thermalOne);
            road.AddExperience(thermalTwo);
            road.AddExperience(thermalThree);
            road.LoadObservers();
        }

        // Prueba que la asignación de puntos es correcta.
        [Test]
        public void AssignPointsToTravelersTest()
        {
            traveler1.TravelerMove(1);
            traveler2.TravelerMove(1);
            
            Assert.AreEqual(traveler1.Score, 2);
            Assert.AreEqual(traveler2.Score, 2);
        }

        // Asignacion de puntos cuando un viajero entra a varias aguas termales.
        [Test]
        public void FarmAssignPointsTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(3);

            Assert.AreEqual(traveler1.Score, 9);
        }

        // Prueba que un viajero no puede entrar una parada anterior.
        [Test]
        public void EnterTravelerTest()
        {
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(1);
            bool expected = thermalTwo.Travelers.Contains(traveler1);
            bool expectedTwo = thermalOne.Travelers.Contains(traveler1);

            Assert.AreEqual(expected,true);
            Assert.AreEqual(expectedTwo,false);
        }

        // Prueba que un jugador puede entrar a cualquier Farm que se encuentra despues.
        [Test]
        public void EnterTravelerTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(3);
            bool expected = thermalThree.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
        }

        // Prueba que si el Farm está completo no puede entrar otro jugador.
        [Test]
        public void EnterTravelerTestThree()
        {
            traveler1.TravelerMove(3);
            traveler2.TravelerMove(3);
            bool expected = thermalThree.Travelers.Contains(traveler1);
            bool expectedTwo = thermalThree.Travelers.Contains(traveler2);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expectedTwo);
        }

        // Prueba que cuando Viajero se mueve a otro Farm, es eliminado del que estaba anteriormente
        [Test]
        public void DeleteTraveler()
        {
            traveler1.TravelerMove(1);
            bool expected = thermalOne.Travelers.Contains(traveler1);
            traveler1.TravelerMove(2);
            bool expectedTwo = thermalOne.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expectedTwo);
        }   
    }
}