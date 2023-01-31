using System;
using TestTask_ArsInegnii.Coins;

namespace TestTask_ArsInegnii.Interfaces
{
	public interface IVedingMachine
	{
		public decimal InsertMoney(Coin coin);
        public List<Coin> ChangeMoney(); 
    }
}

