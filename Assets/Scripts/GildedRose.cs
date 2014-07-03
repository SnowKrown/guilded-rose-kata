using System.Collections.Generic;
using UnityEngine;

namespace GildedRose.Console
{
	public class Program
	{
		public IList<DetailedItem> Items;

		static void Main(string[] args)
		{
			var app = new Program()
			{
				Items = new List<DetailedItem>
				{
					new DetailedItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Type = ItemType.Normal},
					new DetailedItem {Name = "Aged Brie", SellIn = 2, Quality = 0, Type = ItemType.InvestmentCollectable},
					new DetailedItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Type = ItemType.Normal},
					new DetailedItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Type = ItemType.Inmutable},
					new DetailedItem
					{
						Name = "Backstage passes to a TAFKAL80ETC concert",
						SellIn = 15,
						Quality = 20,
						Type = ItemType.Ticket
					},
					new DetailedItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Type = ItemType.Conjured}
				}
			};
			
			app.UpdateQuality();
		}
		
		public void UpdateQuality()
		{
			for (var i = 0; i < Items.Count; i++)
			{
				UpdateQualityBeforeDecreaseSellIn(i);
				DecreaseSellIn (i);

				if (Items[i].SellIn < 0)
				{
					if (Items[i].Type != ItemType.InvestmentCollectable)
					{
						if (Items[i].Type != ItemType.Ticket)
							DecreaseQuality(i);
						else
							Items[i].Quality = 0;
					}
					else
					{
						IncreaseQuality (i);
					}
				}
			}
		}

		private void UpdateQualityBeforeDecreaseSellIn (int index)
		{
			if(Items[index].Type == ItemType.Ticket)
				IncreaseTicketQuality (index);
			else if(Items[index].Type == ItemType.InvestmentCollectable)
				IncreaseQuality (index);
			else
				DecreaseQuality (index);
		}

		private void DecreaseSellIn (int index)
		{
			if (Items[index].Type != ItemType.Inmutable)
				Items[index].SellIn--;
		}

		private void IncreaseTicketQuality (int i)
		{
			IncreaseQuality (i);

			if (Items[i].SellIn < 11 )
				IncreaseQuality (i);
				
			if (Items[i].SellIn < 6)
				IncreaseQuality (i);
		}

		private void DecreaseQuality (int index)
		{
			if (Items[index].Quality > 0)
			{
				if (Items[index].Type != ItemType.Inmutable)
					Items[index].Quality--;
			}
		}

		private void IncreaseQuality (int index)
		{
			if (Items[index].Quality < 50)
				Items[index].Quality++;
		}
	}

	public enum ItemType
	{
		Normal = 0,
		InvestmentCollectable = 1,
		Inmutable = 2,
		Ticket = 3,
		Conjured = 4,
	}
	
	public class Item
	{
		public string Name { get; set; }
		public int SellIn { get; set; }
		public int Quality { get; set; }
	}
	
	public class DetailedItem : Item
	{
		public ItemType Type { get; set;}
	}
}
