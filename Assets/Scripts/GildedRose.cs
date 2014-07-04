using System.Collections.Generic;
using UnityEngine;

public class Program
{
	public IList<ItemSubBase> Items;

	static void Main(string[] args)
	{
		var app = new Program()
		{
			Items = new List<ItemSubBase>
			{
				new NormalItem ("+5 Dexterity Vest", 10 , 20),
				new InvestmentCollectableItem ("Aged Brie", 2, 0),
				new NormalItem ("Elixir of the Mongoose", 5, 7),
				new InmutableItem ("Sulfuras, Hand of Ragnaros"),
				new TicketItem ("Backstage passes to a TAFKAL80ETC concert", 15, 20),
//				new ItemSubBase ("Conjured Mana Cake", 3, 6);
			}
		};
		
		app.UpdateItems ();
	}
	
	public void UpdateItems ()
	{
		for (var i = 0; i < Items.Count; i++)
			Items[i].Update ();
	}
}

public class Item
{
	public string Name { get; set; }
	public int SellIn { get; set; }
	public int Quality { get; set; }
}
