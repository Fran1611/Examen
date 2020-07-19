using NUnit.Framework;
using Library;
namespace Library.Test
{
    public class EndPositionTest
    {
        SingleTraveler traveler1;
        SingleTraveler traveler2;
        Road roadOne;
        Road roadTwo;
        Mountain mountain;
        Ocean ocean;
        Farm farm;
        ThermalWater thermal;


        [SetUp]
        public void SetUp()
        {
            roadOne = new Road();
            roadTwo = new Road();
            mountain = new Mountain("Los Andes",2,1);
            ocean = new Ocean("Atlantico",3,2);
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
        }

        [Test]
        public void OnlyOneEndPositionTest()
        {
            EndPosition endPosition = EndPosition.Instance("final",1,2);
            EndPosition endPositionTwo = EndPosition.Instance("OTHER",5,6);

            Assert.AreEqual(endPosition,endPositionTwo);
        }

        [Test]
        public void EndPositionFinalExperienceTest()
        {
        
            EndPosition expected = roadOne.Final;
            Experience actual = roadOne.Experiences[(roadOne.Experiences.Count)-1];

            Assert.AreEqual(expected,actual);
        }
    }
}