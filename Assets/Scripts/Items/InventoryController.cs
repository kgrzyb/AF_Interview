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

		public static Action<int> OnMoneyChanged;
		public static Action<bool> OnItemConsumed;

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
			OnMoneyChanged?.Invoke(Money);
		}

		public void UseAllConsumables()
        {
			var itemsToConsume = new List<Item>(items);
			for (var i = 0; i < itemsToConsume.Count; i++)
			{
				var isConsumable = itemsToConsume[i].IsConsumable;
				if (!isConsumable)
					continue;

				items.Remove(itemsToConsume[i]);
				UseConsumable();
			}
		}

		public void AddItem(Item item)
		{
			items.Add(item);
		}

		public void UseConsumable()
        {
			var rand = UnityEngine.Random.Range(0, 2);
            if (rand == 0)
            {
				money += 100;
				OnMoneyChanged?.Invoke(Money);
				Debug.Log("Used consumable and added money and now have " + ItemsCount + " items");
			}
            else
            {
				var newItem = new Item("Orange", 75, false);
				AddItem(newItem);
				Debug.Log("Used consumable and added " + newItem.Name + " with value of " + newItem.Value + " and now have " + ItemsCount + " items");
			}
        }
	}
}