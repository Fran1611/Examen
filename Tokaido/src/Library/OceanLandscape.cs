
using System.Collections.Generic;

namespace Library
{
    /*
        La clase OceanLandscape es un subtipo de Experience. Por lo tanto presenta las mismas
        propiedades y métodos definidos en la superclase.
        Gracias a que Update es polimórfica OceanLandscape define Update según sus necesidades.
        Tomando como base el patrón Observer, OceanLandscape es un observador. El método Update
        recibira una actualización cuando un Viajero cambie su posición.
        Por expert, se asigna la responsabilidad expulsar Viajeros, asi como también
        asignar puntos a los Viajeros, debido a que la clase conoce a los Viajeros que ingresaron.
    */
    public class OceanLandscape : Experience
    {
        public OceanLandscape (string name, int capacity, int position) : base(name,capacity,position)
        {
        }

        /// <summary>
        /// Lista de Viajeros que ya se les asignó los puntos de la Experiencia.
        /// </summary>
        /// <typeparam name="Traveler"></typeparam>
        /// <returns></returns>
        private List<Traveler> travelersWithPoint = new List<Traveler>();

        /// <summary>
        /// Propiedad que retorna la lista de Viajeros con asignación de puntos.
        /// </summary>
        /// <value></value>
        public List<Traveler> TravelersWithPoint
        {
            get{return travelersWithPoint;}
        }

        /// <summary>
        /// Método para expulsar a un viajero de la Experiencia.
        /// </summary>
        /// <param name="traveler"></param>
        public void ExitTraveler(Traveler traveler)
        {
            this.Travelers.Remove(traveler);
            this.TravelersWithPoint.Remove(traveler);
        }

        /// <summary>
        /// Método que se ejecuta cuando un Viajero cambia de posición.
        /// Si la posición es la misma que la de la Experiencia, el viajero es agregado
        /// de lo contrario es expulsado(si estaba en ésta experiencia).
        /// </summary>
        /// <param name="observable">Recibe un Viajero por parametro</param>
        public override void Update(Traveler observable)
        {
            if(observable.Position == this.Position)
            {
                this.EnterTraveler(observable);
                AssignPoints();
            }
            else if (this.Travelers.Contains(observable))
            {
                this.ExitTraveler(observable);
            }
        }

        /// <summary>
        /// Método que asigna los puntos a los viajeros que están en la Experiencia.
        /// </summary>
        public void AssignPoints()
        {
            foreach(Traveler traveler in this.Travelers)
            {
                if (!(this.TravelersWithPoint.Contains(traveler)))
                {
                    traveler.Score = (traveler.Score + (traveler.MontainsVisited*2) + 1);
                    this.TravelersWithPoint.Add(traveler);
                    traveler.MontainsVisited += 1;
                }
            }
        }
    }
}