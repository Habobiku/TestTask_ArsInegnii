using System;
using TestTask_ArsInegnii.Coins;
using TestTask_ArsInegnii.Interfaces;

namespace TestTask_ArsInegnii.Services
{
	public class PaymentService:IPaymentService
	{
        public decimal Balance { get; private set; }

        public decimal Withdraw(decimal money)
        {
            if (!HasSufficientFunds(money))
            {
                throw new Exception($"Out of balance! You are missing {money - Balance} funds.");
            }

            Balance -= money;
            return Balance;
        }
        public decimal RefundMoney()
        {
            var refund = Balance;
            Balance = 0;
            return refund;
        }

        public decimal Deposit(Coin coin) => Balance += coin.Value;
        private bool HasSufficientFunds(decimal money) => Balance >= money;
       
    }
}

