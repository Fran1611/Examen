using System;


namespace Library
{

    public enum TypeOfCoin
    {
        SimpleCoin,
        OtherCoin,
    }

    public class Coin
    {  
        public readonly TypeOfCoin type;

        public Coin(TypeOfCoin coinType)
        {
            type = coinType;
        }
    }
}