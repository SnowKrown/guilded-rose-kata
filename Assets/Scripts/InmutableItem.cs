
public class InmutableItem : ItemSubBase 
{
	public InmutableItem (string name)
	{
		this.Name = name;
		this.SellIn = 0;
		this.Quality = 80;
	}


	protected override void UpdateQuality ()
	{
	}

	protected override void UpdateSellIn ()
	{
	}
}
