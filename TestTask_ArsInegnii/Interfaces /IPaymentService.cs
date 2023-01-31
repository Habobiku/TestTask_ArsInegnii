using System;
using TestTask_ArsInegnii.Coins;

namespace TestTask_ArsInegnii.Interfaces
{
	public interface IPaymentService
	{
        public decimal Balance { get; }
        public decimal Withdraw(decimal money);
        public decimal Deposit(Coin coin);
        public decimal RefundMoney();
    }
}

