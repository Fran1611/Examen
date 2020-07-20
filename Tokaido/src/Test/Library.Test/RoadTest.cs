using NUnit.Framework;
using Library;
using System.Collections.Generic;
namespace Library.Test
{
    public class RoadTest
    {

        SingleTraveler traveler1;
        SingleTraveler traveler2;
        Road roadOne;
        Road roadTwo;
        MountainLandscape mountain;
        OceanLandscape ocean;
        Farm farm;
        ThermalWater thermal;
        

        [SetUp]
        public void SetUp()
        {
            roadOne = new Road();
            roadTwo = new Road();
            mountain = new MountainLandscape("Los Andes",2,1);
            ocean = new OceanLandscape("Atlantico",3,2);
            farm = new Farm("La Joaquina",3,3,3);
            thermal = new ThermalWater("Termas del Dayman,",4,4,6);
            traveler1 = new SingleTraveler("Fran");
            traveler2 = new SingleTraveler("Juan");

            roadOne.AddExperience(mountain);
            roadOne.AddExperience(ocean);
            roadOne.AddExperience(farm);
            roadOne.AddExperience(thermal);
            roadOne.AddTravelers(traveler1);
            roadOne.AddTravelers(traveler2);
            roadOne.FinalPositionOfRoad();
            roadOne.LoadObservers();

            
        }

        /// <summary>
        /// Test que verifica que la experiencia final es EndPosition.
        /// </summary>
        [Test]
        public void FinalPositionOfRoadTest()
        {
            EndPosition actual = roadOne.Final;

            Assert.AreEqual("Final del Camino",actual.Name);
            Assert.AreEqual(2,actual.Capacity);
            Assert.AreEqual(5,actual.Position);
        }

        /// <summary>
        /// Test que verifica que No se puede crear 2 caminos con distinta EndPosition.
        /// </summary>
        [Test]
        public void TwoRoadsWithSameEndPosition()
        {
            roadTwo.AddExperience(mountain);
            roadTwo.AddExperience(ocean);
            roadTwo.AddExperience(farm);
            roadTwo.FinalPositionOfRoad();

            EndPosition actual = roadOne.Final;
            EndPosition actualTwo = roadTwo.Final;

            Assert.AreEqual(actual,actualTwo);
        }
    }
}