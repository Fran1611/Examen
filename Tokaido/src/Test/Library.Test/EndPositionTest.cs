using NUnit.Framework;
using Library;
using System.Collections.Generic;
namespace Library.Test
{
    public class EndPositionTest
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
        /// Test que verifica que solo puede existir una instancia de EndPosition.
        /// </summary>
        [Test]
        public void OnlyOneEndPositionTest()
        {
            
            EndPosition endPosition = EndPosition.Instance("final",1,2);
            EndPosition endPositionTwo = EndPosition.Instance("OTHER",5,6);

            Assert.AreEqual(endPosition,endPositionTwo);
        }
        
        /// <summary>
        /// Test que verífica el método para determinar el ganador.
        /// </summary>
        [Test]
        public void OnlyWinnerTravelerTest()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(2);
            traveler1.TravelerMove(3);
            traveler1.TravelerMove(4);
            traveler1.TravelerMove(5);

            traveler2.TravelerMove(1);
            traveler2.TravelerMove(3);
            traveler2.TravelerMove(5);
            Traveler winner = roadOne.Final.Winners[0];

            Assert.AreEqual(traveler1.Name, winner.Name);
            Assert.AreEqual(traveler1.Score,traveler1.Score);
            Assert.AreEqual(traveler1.Position,winner.Position);
                   
        }

        /// <summary>
        /// Test que verifica que puede haber mas de un ganador.
        /// </summary>
        [Test]
        public void MorethanOneWinnerTest()
        {
            traveler1.TravelerMove(1);
            traveler1.TravelerMove(3);
            traveler1.TravelerMove(5);

            traveler2.TravelerMove(1);
            traveler2.TravelerMove(3);
            traveler2.TravelerMove(5);
            List<Traveler> winners = new List<Traveler>();
            winners.Add(traveler1);
            winners.Add(traveler2);

            List<Traveler> listWinners = roadOne.Final.Winners;

            Assert.AreEqual(winners,listWinners);  
        }
    }
}