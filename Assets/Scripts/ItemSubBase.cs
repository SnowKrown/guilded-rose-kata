
public abstract class ItemSubBase : Item
{

	public void Update()
	{
		UpdateSellIn ();
		UpdateQuality ();
	}

	protected abstract void UpdateSellIn ();
	protected abstract void UpdateQuality ();

	protected virtual void IncreaseQuality ()
	{
		if (Quality < 50)
			Quality++;
	}

	protected virtual void DecreaseQuality ()
	{
		if (Quality > 0)
			Quality--;
	}

	protected virtual void DecreaseSellIn ()
	{
	    SellIn--;
	}
}