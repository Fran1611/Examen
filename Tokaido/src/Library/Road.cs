using System.Collections.Generic;
using System;

namespace Library
{
    public class Road : IObserver
    {
        private List<Traveler> travelers = new List<Traveler>();
        private readonly List<Experience> experiences = new List<Experience>();
        private EndPosition final;
        //private List<Traveler> winners;
        public List<Traveler> Winners {get;private set;}


        // Se agrega una nueva experiencia al Camino. Se pueden agregar todas las experiencias que se deseen.
        public void AddExperience(Experience experience)
        {
            experiences.Add(experience);
        }

        // Se agrega un nuevo Viajero al Camino. Se acepta hasta 6 Viajeros.
        public void AddTravelers(Traveler traveler)
        {
            if(travelers.Count < 6)
            {
                travelers.Add(traveler);
            }
        }

        // Luego de agregar todas las Experiencias que se desean
        // se debe utilizar este metodo para crear el final del camino
        // el que se va a ubicar en la última posición.
        public void FinalPositionOfRoad()
        {
            int maxPosition = 0;
            foreach(Experience experience in experiences)
            {
                if(experience.Position > maxPosition)
                {
                    maxPosition = experience.Position;
                }
            }
            maxPosition += 1;
            final = EndPosition.Instance("Final del Camino",travelers.Count,maxPosition);
            final.AddObserver(this);
            AddExperience(final);
        }

        // Método para cargar los observadores 
        public void LoadObservers()
        {
            foreach(Traveler traveler in travelers)
            {
                foreach(Experience experience in experiences)
                {
                    traveler.AddObserver(experience as IObserver);
                }
            }
        }
        // Método que ejecuta el juego mientras playGame sea true.
        // Cuando playGame sea false, el juego termina y se retorna los ganadores


        // Cuando la experiencia EndPosition notifica a Road, el Juego debe terminar.
        public void Update(IObservable observable)
        {
            this.Winners = (observable as EndPosition).WinningTraveler();
        }
    }
}