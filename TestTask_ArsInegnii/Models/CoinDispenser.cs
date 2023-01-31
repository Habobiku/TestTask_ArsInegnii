using System;
using TestTask_ArsInegnii.Coins;
using TestTask_ArsInegnii.Interfaces;
using TestTask_ArsInegnii.Services;

namespace TestTask_ArsInegnii.Models
{
	public class CoinDispenser: ICoinDispenser
    {
        public List<Coin> Coins { get; private set; }

        public CoinDispenser()
        {
            Coins = new List<Coin>();
        }
        public List<Coin> GiveChange(decimal amount)
        {
            if (Coins.Count == 0)
            {
                throw new Exception("No coins available to give change");
            }
            var change = new List<Coin>();
            var coinsOrdering = Coins.OrderByDescending(c => c.Value).ToList();
            var changeRound = Math.Round(amount * 2, MidpointRounding.AwayFromZero) / 2;

            foreach (var coin in coinsOrdering)
            {
                while (changeRound >= coin.Value)
                {
                    change.Add(coin);
                    Coins.Remove(coin);
                    changeRound -= coin.Value;
                }
            }
            if (changeRound != 0)
            {
                throw new Exception("Unable to give exact change");
            }
            return change;
        }
        public void AddCountedCoins(int[] count)
        {
            Coins.AddRange(Enumerable.Repeat(new TwoEuros(), count[0]));
            Coins.AddRange(Enumerable.Repeat(new OneEuros(), count[1]));
            Coins.AddRange(Enumerable.Repeat(new FiftyCent(), count[2]));
            Coins.AddRange(Enumerable.Repeat(new TwentyCent(), count[3]));
            Coins.AddRange(Enumerable.Repeat(new TenCent(), count[4]));
            Coins.AddRange(Enumerable.Repeat(new FiveCent(), count[5]));
        }

        public void AddCoins(List<Coin> coins) => coins.AddRange(coins);
        public void AddCoin(Coin coin) => Coins.Add(coin);
    }
}

