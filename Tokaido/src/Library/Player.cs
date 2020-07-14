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
    public abstract class Player
    {
        private int score = 0;

        public Player(string name)
        {
            Name = name;
        }

        public string Name {get;set;}
        public List<Coin> Coins = new List<Coin>();
        public int OceansVisited {get;set;}
        public int MontainsVisited {get;set;}
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

        public void AddCoins(List<Coin> coins)
        {
            foreach(Coin coin in coins)
            this.Coins.Add(coin);
        }

        public void GoOutLandscapeOrStation(Station station)
        {
            station.RemovePlayer(this);
        }

        public void GoOutLandscapeOrStation(Landscape landscape)
        {
            landscape.RemovePlayer(this);
        }        
    }
}
