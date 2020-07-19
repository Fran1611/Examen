using System.Collections.Generic;

namespace Library
{

    /* 
        La clase Traveler hereda la clase Traveler, por lo tanto es subtipo de Traveler y
        puede hacer uso de todas las propiedades y operaciones definidas en Traveler.
        En este caso SingleTraveler es un Viajero común y no presenta diferencia alguna con Traveler.
        
    */
    public class SingleTraveler : Traveler
    {
        public SingleTraveler(string name): base(name)
        {
            Name = name;
        }

    }
}