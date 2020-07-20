using System.Collections.Generic;
using System;

namespace Library
{
    /*
        La clase Road es la encargada de armar el camino.
        Road conoce la lista de Viajeros y la lista de Experiencias.
        Por expert, se asigna la responsabilidad de agregar Experiencias y Viajeros, 
        así como también la responsabilidad de agregar a cada Viajero los Observadores (Experiencias), 
        ya que Road debe conoce quienes son los Viajeros y las Experiencias.
        Road utliza también Creator, se le asigna la responsabilidad de crear el final del camino,
        como conoce las experiencias del camino conoce entonces cual es la ultima experiencia y agrega
        a esa lista de experiencias el final del camino.
        Road utiliza DIP, porque no depende de cada tipo de Viajero ni de cada Tipo de Experience, sino que
        depende de las abstracciones de éstas, es decir de Experience y Traveler.
        Cumple con OCP, ya que para crear por más que se creen nuevos tipos de Experiencias y de Viajeros
        no es necesario modificar el código de ésta clase.


    */
    public class Road
    {
        /// <summary>
        /// Lista de Viajeros que jugaran.
        /// </summary>
        /// <typeparam name="Traveler">Los viajeros son de tipo Traveler</typeparam>
        private List<Traveler> travelers = new List<Traveler>();

        /// <summary>
        /// Lista de Experiencias que tiene el camino.
        /// </summary>
        /// <typeparam name="Experience">Las Experiencias son de tipo Experience</typeparam>
        
        private List<Experience> experiences = new List<Experience>();

        /// <summary>
        /// Propiedad que retorna la lista de Experiencias.
        /// </summary>
        /// <value> Lista objetos de tipo Experience </value>
        public List<Experience> Experiences{get{return experiences;}}

        /// <summary>
        /// Propiedad que retorna la lista de Viajeros.
        /// </summary>
        /// <value>Lista objetos de tipo Traveler</value>
        public List<Traveler> Travelers{get{return travelers;}}

        /// <summary>
        /// Propiedad que retorna la Experiencia Final del camino.
        /// </summary>
        /// <value>Experiencia de tipo EndPosition</value>
        public EndPosition Final {get;set;}
        

        /// <summary>
        ///  Se agrega una nueva experiencia al Camino. 
        /// Se pueden agregar todas las experiencias que se deseen.
        /// </summary>
        /// <param name="experience"> Experiencia a agregar</param>
        public void AddExperience(Experience experience)
        {
            Experiences.Add(experience);
        }

        /// <summary>
        /// Se agrega un nuevo Viajero al Camino. Se acepta hasta 6 Viajeros.
        /// </summary>
        /// <param name="traveler"> Viajero a agregar</param>
        public void AddTravelers(Traveler traveler)
        {
            if(travelers.Count < 6)
            {
                Travelers.Add(traveler);
            }
        }

       /// <summary>
       /// Método que crea la última Experiencia y la agrega a la lista de experiencias del Camino.
       /// </summary>
        public void FinalPositionOfRoad()
        {
            int maxPosition = 0;
            foreach(Experience experience in Experiences)
            {
                if(experience.Position > maxPosition)
                {
                    maxPosition = experience.Position;
                }
            }
            maxPosition += 1;
            Final = EndPosition.Instance("Final del Camino",travelers.Count,maxPosition);
            //Final.AddObserver(this);
            AddExperience(Final);
        }

        /// <summary>
        /// Método para agrear a los observadores(Experiencias) en los Observables (Viajeros)
        /// </summary>
        public void LoadObservers()
        {
            foreach(Traveler traveler in Travelers)
            {
                foreach(Experience experience in Experiences)
                {
                    traveler.AddObserver(experience);
                }
            }
        }
    }
}