namespace UnitTests;

[TestClass]
public class VendingMachineUnitTests
{ 
    [TestMethod]
    public void InsertMoney_UpdateBalanceAndCoins()
    {
        var insertCoins = new TwoEuros();
        decimal expectedMoney = 2;
        List<Coin> expectedCoins = new List<Coin> { insertCoins };

        var paymentService = new PaymentService();
        var coinDispenser = new CoinDispenser();
        var storage = new Storage();
        var dispenseService = new DispenseService(storage, paymentService);
        var vendingMachine = new VedingMachine(storage, paymentService, dispenseService, coinDispenser);

        var balance = vendingMachine.InsertMoney(insertCoins);

        Assert.AreEqual(expectedMoney, balance, "Money not added to balance correctly");
        CollectionAssert.AreEqual(expectedCoins, vendingMachine.Coins, "Coins not added to balance correctly");
    }
    [TestMethod]
    public void GiveChangeInCoins()
    {
        var insertCoins = new TwoEuros();
        List<Coin> expectedCoins = new List<Coin> { insertCoins };

        var paymentService = new PaymentService();
        var coinDispenser = new CoinDispenser();
        var storage = new Storage();
        var dispenseService = new DispenseService(storage, paymentService);
        var vendingMachine = new VedingMachine(storage, paymentService, dispenseService, coinDispenser);

        var balance = vendingMachine.InsertMoney(insertCoins);

        var change = vendingMachine.ChangeMoney();

        Assert.AreEqual(0, vendingMachine.Balance, "Money has not been withdrawn from the account");
        CollectionAssert.AreEqual(expectedCoins, change, "Coins were not given correctly");
    }
    [TestMethod]
    public void OrderItem_Dispence()
    {
        var insertCoins = new TwoEuros();
        var expectedItem = new Item("Coca Cola",1);

        var paymentService = new PaymentService();
        var coinDispenser = new CoinDispenser();
        var storage = new Storage();
        var dispenseService = new DispenseService(storage, paymentService);
        var vendingMachine = new VedingMachine(storage, paymentService, dispenseService, coinDispenser);
        storage.Add(expectedItem);
        vendingMachine.InsertMoney(insertCoins);

        var dispensedItem = vendingMachine.DispenseItem(expectedItem);

        Assert.AreEqual(expectedItem, dispensedItem, "Soda dispensed is not the same as the requested soda");
    }
    [TestMethod]
    public void OrderItem_OutOfStock_ShouldThrowExeption()
    {
        var insertCoins = new TwoEuros();
        var expectedItem = new Item("Coca Cola", 1);

        var paymentService = new PaymentService();
        var coinDispenser = new CoinDispenser();
        var storage = new Storage();
        var dispenseService = new DispenseService(storage, paymentService);
        var vendingMachine = new VedingMachine(storage, paymentService, dispenseService, coinDispenser);
        storage.Add(expectedItem,0);
        vendingMachine.InsertMoney(insertCoins);

        Assert.ThrowsException<Exception>(()=>vendingMachine.DispenseItem(expectedItem));
    }
    [TestMethod]
    public void OrderItem_NotEnoughMoney_ShouldThrowExeption()
    {
        var expectedItem = new Item("Coca Cola", 1);

        var paymentService = new PaymentService();
        var coinDispenser = new CoinDispenser();
        var storage = new Storage();
        var dispenseService = new DispenseService(storage, paymentService);
        var vendingMachine = new VedingMachine(storage, paymentService, dispenseService, coinDispenser);
        storage.Add(expectedItem, 1);

        Assert.ThrowsException<Exception>(() => vendingMachine.DispenseItem(expectedItem));
    }
}
