using System.Collections.Generic;

namespace Library
{

    /* 
        La clase Traveler hereda la clase Player, por lo tanto es subtipo de Player.
        Traveler es un tipo de Jugador. Para este caso Traveler es un jugador comúm.


    */
    public class SingleTraveler : Traveler
    {
        public SingleTraveler(string name): base(name)
        {
            Name = name;
        }

    }
}