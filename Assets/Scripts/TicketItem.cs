
public class TicketItem : ItemSubBase 
{
	public TicketItem (string name, int sellIn, int quality)
	{
		this.Name = name;
		this.SellIn = sellIn;
		this.Quality = quality;
	}

	protected override void UpdateQuality ()
	{
		IncreaseQuality();
		if(SellIn < 10)
			IncreaseQuality();
		if(SellIn < 5)
			IncreaseQuality();

		if(SellIn <= 0)
			Quality = 0;
	}
	
	protected override void UpdateSellIn ()
	{
		DecreaseSellIn();
	}
}

