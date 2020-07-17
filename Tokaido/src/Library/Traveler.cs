using System;
using System.Collections.Generic;

namespace Library
{
    /*
        Esta clase representa la abstracción de los Jugadores.
        Todos los distintos tipos de Jugadores heredaran ésta clase, entonces todos los Jugadores
        seran subtipos de Player y heredaran tambien todas sus propiedades y operaciones.
        La idea es poder crear distintos tipos de personajes sin tener que modificar el codigo existente.
        Por ejemplo, si se quiere crear un personaje que al pasar por cierta estación adquiera más experienca
        o recoja más monedas que otro tipo de jugador, se podria crear 

    */
    public abstract class Traveler
    {
        private int position = 0;
        private int score = 0;
        private int oceansVisited = 0;
        private int montainsVisited = 0;
        private int coins = 0;

        public Traveler(string name)
        {
            Name = name;
        }

        public string Name {get;set;}
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

        public virtual bool TravelerMove(int newPosition)
        {
            if(newPosition > this.Position)
            {
                this.Position = newPosition;
                return true;
            }
            else return false;
        }   
    }
}
