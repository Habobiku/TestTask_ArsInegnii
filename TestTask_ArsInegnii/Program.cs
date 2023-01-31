using System;
using System.Reflection.PortableExecutable;
using TestTask_ArsInegnii.Coins;
using TestTask_ArsInegnii.Interfaces;
using TestTask_ArsInegnii.Models;
using TestTask_ArsInegnii.Services;

namespace TestTask_ArsInegnii;

public static class Program
{
    private static CoinDispenser InitializeCoinDispenser()
    {
        var coinDispenser = new CoinDispenser();
        coinDispenser.AddCountedCoins(new int[6] { 10, 5, 2, 1, 7, 4 });
        return coinDispenser;
    }
    private static Storage InitializeStorage()
    {
        var storage = new Storage();
        storage.Add(new Item("Coca Cola", 0.33m), 1);
        storage.Add(new Item("Fanta", 0.33m), 1);
        storage.Add(new Item("Sprite", 0.33m), 0);
        storage.Add(new Item("Solo", 0.33m), 10);
        storage.Add(new Item("Frydenlund", 4.7m), 10);
        return storage;

    }
    private static VedingMachine InitializeVedingMachine()
    {

        var storage = InitializeStorage();
        var coinDispenser = InitializeCoinDispenser();
        var paymentService = new PaymentService();

        var dispenseService = new DispenseService(storage, paymentService);
        var vedingMachine = new VedingMachine(storage, paymentService, dispenseService, coinDispenser);

        
        return vedingMachine;
    }
    public static void Main()
    {
        var vedingMachine = InitializeVedingMachine();
        var item = new Item("Coca Cola", 1);

        vedingMachine.InsertMoney(new TwoEuros());
        
        var dispenseItem = vedingMachine.DispenseItem(item);
        var p = vedingMachine.ChangeMoney();
        
    }
}