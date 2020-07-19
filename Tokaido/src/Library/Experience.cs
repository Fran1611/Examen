using System.Collections.Generic;
namespace Library
{
    /*
        Se define la clase abstracta Experience, la cual será heredada por todos los tipos
        de experiencias. Al ser abstracta no podra crearse una instancia de Experience.
        El propóstio de utilizar Herencia es la reutilizaciónde codigo. Los subtipos de Experience
        no tendrán que definir lo que ya está definido en Experience.
        El método Update se marcó como abstracto, ya que cada subtipo de Experience
        lo implementara de manera distinta. Por lo tanto es una operacion Polimórfica.
        Por Expert se asigna la resposablidad a Experience de agregar Viajeros a la experiencia, ya que
        Experience es experta en la capacidad de Viajeros.
    */
    public abstract class Experience
    {
        /// <summary>
        /// Variable Posición.
        /// </summary>
        private int position;
        public Experience(string name, int capacity, int position)
        {
            Capacity = capacity;
            Name = name;
            Position = position;
        }

        /// <summary>
        /// Propiedad que retorna y setea el Nombre
        /// </summary>
        /// <value></value>
        public string Name{get;set;}

        /// <summary>
        /// Propiedad que retorna y setea la Capacidad
        /// </summary>
        /// <value></value>
        public int Capacity {get;set;}

        /// <summary>
        /// Lista de Viajeros en la Experiencia.
        /// </summary>
        /// <typeparam name="Traveler"></typeparam>
        /// <returns></returns>
        private List<Traveler> travelers = new List<Traveler>();
        
        /// <summary>
        /// Propiedad que retorna la Lista de viajeros en la experiancia.
        /// </summary>
        /// <value></value>
        public List<Traveler> Travelers
        {
            get{return travelers;}
        }
        
        /// <summary>
        /// Propiedad que retorna la posición y la setea sólo si la nueva posición es mayor a 0.
        /// </summary>
        /// <value></value>
        public int Position
        {
            get {return position;}
            
            set
            {
                if (value>0)
                {
                    position = value;
                }
            }
        }

        /// <summary>
        /// Método para ingreso de Viajero a la estación.
        /// </summary>
        /// <param name="traveler"></param>
        /// <returns> retora true si el viajero ingresó y false en caso contrario</returns>
        public virtual bool EnterTraveler(Traveler traveler)
        { 
            if (Travelers.Count < Capacity)
            {
                this.Travelers.Add(traveler);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Método que se ejecuta cuando un Viajero cambia de posición.
        /// </summary>
        /// <param name="observable"></param>
        public abstract void Update(Traveler observable);
      
    }
}