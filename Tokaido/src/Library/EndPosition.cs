using System.Collections.Generic;
namespace Library
{
    /*
        La clase EndPosition es un subtipo de Experience. Por lo tanto presenta las mismas
        propiedades y métodos definidos en la superclase.
        Gracias a que Update es polimórfica EndPosition define Update según sus necesidades.
        Tomando como base el patrón Observer, EndPosition es un observador. El método Update
        recibira una actualización cuando un Viajero cambie su posición.
        Por expert se le asigna la responsabilidad de determinar quienes son los Viajeros ganadores
        cuando su capacidad está completa, EndPosition conoce a la totalidad de Viajeros.
        Cumple con SRP, ya que sus responsabilidades estan asociadas a determinar cual o cuales son
        los Viajeros ganadores.
        Utiliza Singleton, debido a que el camino solo puede tener un punto final, solo puede haber
        una instancia de EndPosition.
    */
    public class EndPosition : Experience
    {
        private EndPosition(string name, int capacity, int position) : base (name,capacity,position)
        {
        }

        /// <summary>
        /// Variable Instancia de EndPosition
        /// </summary>
        private static EndPosition instance = null;  

        /// <summary>
        /// Método que crea una instancia de EndPosition en caso que no exista una.
        /// </summary>
        /// <param name="name">Nombre de la Experiencia</param>
        /// <param name="capacity">Capacidad de la Experiencia</param>
        /// <param name="position"> Posición de la Experiencia</param>
        /// <returns> Retorna una instancia de EndPosition</returns>
        public static EndPosition Instance(string name, int capacity, int position)
        {   
            if (instance == null)  
            {  
                instance = new EndPosition(name,capacity,position);     
            }  
            
            return instance;  
        }

        /// <summary>
        /// Lista de Viajeros ganadores.
        /// </summary>
        /// <typeparam name="Traveler"></typeparam>
        private List<Traveler> winners = new List<Traveler>();

        /// <summary>
        /// Propiedad que retorna la lista de Viajeros ganadores.
        /// </summary>
        public List<Traveler> Winners {get{return winners;}}

        /// <summary>
        /// Método de actualización, se ejecuta cuando un Viajero se mueve.
        /// </summary>
        /// <param name="observable"> Viajero que se movió</param>
        public override void Update(Traveler observable)
        {
            if(observable.Position == this.Position)
            {
                if (this.Capacity > this.Travelers.Count)
                {
                    EnterTraveler(observable);
                    
                    if (this.Capacity == this.Travelers.Count)
                    {
                        WinnerTravelers();
                    }
                }
            }
        }
        
        /// <summary>
        /// Método para determinar quién o quienes son los ganadores.
        /// </summary>
        public void WinnerTravelers()
        {   
            int maxScore = 0;

            foreach(Traveler traveler in this.Travelers)
            {
                if (traveler.Score > maxScore)
                {
                    Winners.Clear();
                    maxScore = traveler.Score;
                    Winners.Add(traveler);
                }
                else if(traveler.Score == maxScore)
                {
                    Winners.Add(traveler);
                }
            }
        }
    }
}