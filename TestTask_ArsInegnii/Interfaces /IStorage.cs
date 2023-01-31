using System;
namespace TestTask_ArsInegnii.Interfaces
{
	public interface IStorage
	{
		public Dictionary<IItem,int> Items { get; }
		public int Count { get; }
		public void Add(IItem item, int quantity = 1);
		public void Remove(IItem item);
		public void Deduct(IItem item, int quantity = 1);
		public bool HasItem(IItem item);
		public bool Contains(string productName);
		public IItem GetItem(string productName);
	}
}

