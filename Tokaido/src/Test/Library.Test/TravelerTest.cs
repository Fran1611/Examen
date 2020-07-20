using NUnit.Framework;
using Library;
namespace Library.Test
{
    public class TravelerTest
    {

        SingleTraveler fran;
        MountainLandscape mountain;
        OceanLandscape ocean;
        Farm farm;
        

        [SetUp]
        public void Setup()
        {  
            mountain = new MountainLandscape("Los Andes",2,1);
            ocean = new OceanLandscape("Atlantico",3,2);
            farm = new Farm("La Joaquina",0,3,3);
            fran = new SingleTraveler("Fran");
            fran.AddObserver(mountain);
            fran.AddObserver(ocean);
            fran.AddObserver(farm);
        }

        /// <summary>
        /// Test que verifica que el viajero se mueve a la experiencia indicada por posición.
        /// </summary>
        [Test]
        public void TravelerMoveTest()
        {
            fran.TravelerMove(1);
            Assert.AreEqual(fran, mountain.Travelers[0]);
            Assert.AreEqual(fran.Position,1);
        }

        /// <summary>
        /// Test que comprueba que la posición del Viajero no puede ser negativa.
        /// </summary>
        [Test]
        public void TravelerMoveTestTwoTest()
        {
            fran.TravelerMove(-1);

            Assert.AreEqual(fran.Position, 0);
        }

        /// <summary>
        /// Aunque el viajero no ingrese a la experiencia indicada, su posición cambia.
        /// </summary>
        [Test]
        public void TravelerMoveTestThreeTest()
        {
            fran.TravelerMove(3);
            bool actual = farm.Travelers.Contains(fran);

            Assert.AreEqual(3,fran.Position);
            Assert.AreEqual(false, actual);
        }

        /// <summary>
        /// Verifica que aunque no exista experiencia el viajero cambia de posición.
        /// </summary>
        [Test]
        public void TravelerMoveTestFourTest()
        {
            fran.TravelerMove(10);
            Assert.AreEqual(10,fran.Position);
        }
    }
}