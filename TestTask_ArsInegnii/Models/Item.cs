using TestTask_ArsInegnii.Interfaces;
using System;
namespace TestTask_ArsInegnii.Models
{
	public class Item:IItem
	{
		public Item(string name,decimal price)
		{
			Name = name;
			Price = price;
		}
		public string Name { get; }
        public decimal Price { get; }

        public bool Equals(Item? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Item)obj);
        }
        public override int GetHashCode() => HashCode.Combine(Name);
    }
}

