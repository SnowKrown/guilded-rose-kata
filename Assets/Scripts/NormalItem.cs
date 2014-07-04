
public class NormalItem : ItemSubBase
{
	public NormalItem (string name, int sellIn, int quality)
	{
		this.Name = name;
		this.SellIn = sellIn;
		this.Quality = quality;
	}

	protected override void UpdateQuality ()
	{
		DecreaseQuality();

		if (SellIn < 0)
			DecreaseQuality ();
	}

	protected override void UpdateSellIn ()
	{
		DecreaseSellIn();
	}
}
