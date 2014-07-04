
public class ConjuredItem : ItemSubBase 
{
	public ConjuredItem (string name, int sellIn, int quality)
	{
		this.Name = name;
		this.SellIn = sellIn;
		this.Quality = quality;
	}
	
	protected override void UpdateQuality ()
	{
		DecreaseQuality ();
		DecreaseQuality ();
	}
	
	protected override void UpdateSellIn ()
	{
		DecreaseSellIn ();
	}
}
