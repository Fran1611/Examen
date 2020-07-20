using System;
using System.Collections.Generic;

namespace Library
{
    /*
        Se define la clase abstracta Traveler, la cual será heredada por todos los tipos
        de Viajeros. Al ser abstracta no podra crearse una instancia de Traveler.
        El propóstio de utilizar Herencia es la reutilizaciónde codigo. Los subtipos de Traveler
        no tendrán que definir lo que ya está definido en Traveler.
        Tomando como base el patrón Observer, Traveler es un Observable, es decir que tendra una lista
        de Observadores a los que deberá notificar en determinado momento.
        Se asigna a Traveler la responsabilidad de moverse, Traveler es experto en conocer su posición.
        Cuando se mueva notificará a los observadores.
        Debido a que los observadores son siempre de tipo Experience, no se implementaron las interfaces
        IObserver y IObservable.
        Cumple con OCP, ya que para crear distintos tipos de Viajeros no es necesario modificar
        el codigo existente, simplemente debe crearse una nueva clase que herede Traveler
        y definir los nuevos métodos y/o propiedades.

    */
    public abstract class Traveler

    {
        /// <summary>
        /// Posición del Viajero iniciada en 0.
        /// </summary>
        private int position = 0;

        /// <summary>
        /// Puntaje del Viajero iniciado en 0.
        /// </summary>
        private int score = 0;

        /// <summary>
        /// Cantidad de Oceanos visitados por Viajero iniciada en 0.
        /// </summary>
        private int oceansVisited = 0;

        /// <summary>
        /// Cantidad de Montañas visitados por Viajero iniciada en 0.
        /// </summary>
        private int montainsVisited = 0;

        /// <summary>
        /// Monedas del Viajero iniciada en 0.
        /// </summary>
        private int coins = 0;

        public Traveler(string name)
        {
            Name = name;
        }
        
        /// <summary>
        /// Propiedad que retorna y setea el nombre.
        /// </summary>
        /// <value></value>
        public string Name {get;set;}

        /// <summary>
        /// Propiedad que retorna y seta las monedas si el nuevo valor es mayor que 0.
        /// </summary>
        /// <value></value>
        public int Coins
        {
            get 
            {
                return coins;
            }
            set
            {
                if (value>0)
                {
                    coins = value;                    
                }
            }
        }
        /// <summary>
        /// Propiedad que retorna y seta la Posición si el nuevo valor es mayor que 0.
        /// </summary>
        /// <value></value>
        public int Position
        {
            get 
            {
                return position;
            }
            set
            {
                if (value>0)
                {
                    position = value;                    
                }
            }
        }

        /// <summary>
        /// Propiedad que retorna y seta los Oceanos visitados si el nuevo valor es mayor que 0.
        /// </summary>
        /// <value></value>
        public int OceansVisited
        {
            get 
            {
                return oceansVisited;
            }
            set
            {
                if (value>0)
                {
                    oceansVisited = value;                    
                }
            }
        }

        /// <summary>
        /// Propiedad que retorna y seta las Motañas visitadas si el nuevo valor es mayor que 0.
        /// </summary>
        /// <value></value>
        public int MontainsVisited
        {
            get 
            {
                return montainsVisited;
            }
            set
            {
                if (value>0)
                {
                    montainsVisited = value;                    
                }
            }
        }

        /// <summary>
        /// Propiedad que retorna y seta el Puntaje si el nuevo valor es mayor que 0.
        /// </summary>
        /// <value></value>
        public int  Score
        {
            get 
            {
                return score;
            }
            set
            {
                if (value>0)
                {
                    score = value;                    
                }
            }
        }

        /// <summary>
        /// Lista de Observadores de tipo Experience.
        /// </summary>
        /// <typeparam name="Experience">Experiencias</typeparam>
        /// <returns></returns>
        private List<Experience> observers = new List<Experience>();

        /// <summary>
        /// Método para agregar observadores.
        /// </summary>
        /// <param name="observer">Recibe una Experiencia por parámetro</param>
        public void AddObserver(Experience observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// Método para eliminar observadores.
        /// </summary>
        /// <param name="observer">Recibe una Experiencia por parámetro</param>
        public void DeleteObserver(Experience observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// Método para notificar a los observadores.
        /// </summary>
        public void Notify()
        {
            foreach(Experience observer in observers)
            {
                observer.Update(this);
            }
        }

        /// <summary>
        /// Método para mover al Viajero a una nueva posición.
        /// Cuando se mueve notifica a los observadores.
        /// </summary>
        /// <param name="newPosition"></param>
        /// <returns></returns>
        public bool TravelerMove(int newPosition)
        {
            if(newPosition > this.Position)
            {
                this.Position = newPosition;
                this.Notify();
                return true;
            }
            else return false;
        }   
    }
}
