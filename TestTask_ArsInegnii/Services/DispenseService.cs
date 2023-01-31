using System;
using TestTask_ArsInegnii.Interfaces;

namespace TestTask_ArsInegnii.Services
{
	public class DispenseService:IDispenseService
	{
        private readonly IStorage _storage;
        private readonly IPaymentService _paymentService;

        public DispenseService(IStorage storage, IPaymentService paymentService)
		{
            _storage = storage;
            _paymentService = paymentService;
        }
        public IItem DispenseItem(IItem item)
        {
            _storage.Deduct(item);
            _paymentService.Withdraw(item.Price);
            return item;
        }
    }
}

