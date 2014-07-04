
public class InvestmentCollectableItem : ItemSubBase 
{
	public InvestmentCollectableItem (string name, int sellIn, int quality)
	{
		this.Name = name;
		this.SellIn = sellIn;
		this.Quality = quality;
	}

	protected override void UpdateQuality ()
	{
		IncreaseQuality();
	}
	
	protected override void UpdateSellIn ()
	{
		DecreaseSellIn();
	}
}
