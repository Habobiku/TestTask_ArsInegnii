using System;
namespace TestTask_ArsInegnii.Coins
{
   public abstract class Coin
    {
        public decimal Value { get; }

        protected Coin(decimal value)
        {
            Value = value;
        }
    }
}

