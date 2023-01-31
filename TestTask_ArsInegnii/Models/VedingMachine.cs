using System;
using System.Collections.Generic;
using System.Drawing;
using TestTask_ArsInegnii.Coins;
using TestTask_ArsInegnii.Interfaces;

namespace TestTask_ArsInegnii.Models
{
	public class VedingMachine:IVedingMachine
	{
        private readonly IStorage _storage ;
        private readonly IPaymentService _paymentService;
        private readonly IDispenseService _dispenseService;
        private readonly ICoinDispenser _coinDispencer;

        public VedingMachine(IStorage storage, IPaymentService paymentService,IDispenseService dispenseService, CoinDispenser coinDispencer)
		{
            _storage = storage;
            _paymentService = paymentService;
            _dispenseService = dispenseService;
            _coinDispencer = coinDispencer;
        }
        public List<Coin> ChangeMoney()
        {
            var change = _paymentService.RefundMoney();
            //clearing deposit and returning the change to user
            return _coinDispencer.GiveChange(change);
        }
        public decimal InsertMoney(Coin coin)
        {
           _coinDispencer.AddCoin(coin);
           return _paymentService.Deposit(coin);
        }

        public decimal Balance => _paymentService.Balance;
        public List<Coin> Coins => _coinDispencer.Coins;
        public IItem DispenseItem(IItem item) => _dispenseService.DispenseItem(item);
    }
}

