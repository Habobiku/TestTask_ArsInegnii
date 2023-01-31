using System;
using TestTask_ArsInegnii.Interfaces;

namespace TestTask_ArsInegnii.Models
{
    public class Storage : IStorage
    {
        public Dictionary<IItem, int> Items { get; }
        public int Count => Items.Count;

        public Storage()
        {
            Items = new Dictionary<IItem, int>();
        }
        public void Add(IItem item, int quantity = 1)
        {
            if (Items.ContainsKey(item))
            {
                Items[item] += quantity;
                return;
            }

            Items.Add(item, quantity);
        }
        public void Deduct(IItem item, int quantity = 1)
        {
            var stock = Items[item];

            if (stock - quantity < 0)
            {
                throw new Exception($"Not enough items in stock. Current stock is {stock}.");
            }

            Items[item] -= quantity;

            if (Items[item] < 0)
            {
                Items[item] = 0;
            }
        }

        public bool Contains(string productName) => Items.Any(x => string.Equals(x.Key.Name, productName, StringComparison.InvariantCultureIgnoreCase));
        public IItem GetItem(string productName) => Items.First(x => string.Equals(x.Key.Name, productName, StringComparison.InvariantCultureIgnoreCase)).Key;
        public bool HasItem(IItem item) => Items.ContainsKey(item);
        public void Remove(IItem item) => Items.Remove(item);
    }
}

