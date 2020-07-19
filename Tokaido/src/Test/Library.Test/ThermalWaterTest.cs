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

        /// <summary>
        /// Test que verifica la asignación de puntos.
        /// </summary>
        [Test]
        public void AssignPointsToTravelersTest()
        {
            traveler1.TravelerMove(1);
            traveler2.TravelerMove(1);
            
            Assert.AreEqual(traveler1.Score, 2);
            Assert.AreEqual(traveler2.Score, 2);
        }

        /// <summary>
        /// Test que verifica la asignación de puntos cuando un Viajero pasa por varias Aguas Termales.
        /// </summary>
        [Test]
        public void FarmAssignPointsTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(3);

            Assert.AreEqual(traveler1.Score, 9);
        }

        /// <summary>
        /// Test que verifica que un Viajero no puede entrar a un Agua Termal anterior.
        /// </summary>
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

        /// <summary>
        ///  Test que verifica que un Viajero puede entrar a cualquier Agua Termal que se encuentra despues.
        /// </summary>        
        [Test]
        public void EnterTravelerTestTwo()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(3);
            bool expected = thermalThree.Travelers.Contains(traveler1);

            Assert.AreEqual(true,expected);
        }

        /// <summary>
        /// Test que verifica que si el Agua Termal está completa no puede entrar otro Viajero.
        /// </summary>
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

        /// <summary>
        /// Test que verifica que cuando Viajero se mueve a otra Agua Termal, es eliminado del que estaba anteriormente 
        /// </summary>
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