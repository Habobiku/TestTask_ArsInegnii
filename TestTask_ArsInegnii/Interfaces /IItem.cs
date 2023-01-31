using System;
using TestTask_ArsInegnii.Models;

namespace TestTask_ArsInegnii.Interfaces
{
	public interface IItem: IEquatable<Item>
    {
		public string Name { get; }
		public decimal Price { get; }
	}
}

