namespace AFSInterview.Items
{
    using System;
    using System.Collections.Generic;
	using UnityEngine;

	public class InventoryController : MonoBehaviour
	{
		[SerializeField] private List<Item> items;
		[SerializeField] private int money;

		public int Money => money;
		public int ItemsCount => items.Count;

		public static Action<int> OnItemsSold;

		public void SellAllItemsUpToValue(int maxValue)
		{
			var itemsForSale = new List<Item>(items);
			for (var i = 0; i < itemsForSale.Count; i++)
			{
				var itemValue = itemsForSale[i].Value;
				if (itemValue > maxValue)
					continue;
				
				money += itemValue;
				items.Remove(itemsForSale[i]);
			}
			OnItemsSold?.Invoke(Money);
		}

		public void AddItem(Item item)
		{
			items.Add(item);
		}
	}
}