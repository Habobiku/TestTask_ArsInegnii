using System;
using TestTask_ArsInegnii.Coins;

namespace TestTask_ArsInegnii.Interfaces
{
	public interface ICoinDispenser
	{
		public List<Coin> GiveChange(decimal amount);
		public List<Coin> Coins { get; }
		public void AddCoins(List<Coin> coins);
		public void AddCountedCoins(int[] count);
		public void AddCoin(Coin coin);
    }
}

