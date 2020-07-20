using System.Collections.Generic;
namespace Library
{
    public class Farm : Experience
    {
        /*  La clase Farm es un subtipo de Experience. Por lo tanto presenta las mismas
            propiedades y métodos definidos en la superclase.
            Gracias a que Update es polimórfica Farm define Update según sus necesidades.
            Tomando como base el patrón Observer, Farm es un observador. El método Update
            recibira una actualización cuando un Viajero cambie su posición.
            Por expert, se asigna la responsabilidad expulsar Viajeros, asi como también
            asignar puntos a los Viajeros, debido a que la clase conoce a los Viajeros que ingresaron.
        */
        public Farm (string name,int capacity, int position, int coins) : base(name,capacity, position)
        {
            Coins = coins;
        }

        /// <summary>
        /// Propiedad que retorna y setea las monedas.
        /// </summary>
        /// <value></value>
        public int Coins{get;set;}

        /// <summary>
        /// Lista de Viajeros que ya se les asignaron las monedas.
        /// </summary>
        /// <typeparam name="Traveler"></typeparam>
        /// <returns></returns>
        private List<Traveler> travelersWithPoint = new List<Traveler>();
        
        /// <summary>
        /// Propiedad que retorna la lista de viajeros a los que ya se le asingó las monedas.
        /// </summary>
        /// <value></value>
        public List<Traveler> TravelersWithPoint {get{return travelersWithPoint;}}

        
        /// <summary>
        /// Método para expulsar a un Viajero de la Experiencia.
        /// </summary>
        /// <param name="traveler"> Recibe un Viajero por parametro</param>
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
        /// Método que asigna las moneas a los viajeros que están en la Experiencia.
        /// </summary>
        public void AssignPoints()
        {
            foreach (Traveler traveler in this.Travelers)
            {
                if (!(this.TravelersWithPoint.Contains(traveler)))
                {
                    this.TravelersWithPoint.Add(traveler);
                    
                    if (this.Coins != 0)
                    { 
                        traveler.Coins += this.Coins;
                    }
                }
            }  
        }
    }
}