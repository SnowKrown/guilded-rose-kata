
public class ConjuredItem : NormalItem 
{
	public ConjuredItem (string name, int sellIn, int quality) : base (name, sellIn, quality)
	{
	}
	
	protected override void UpdateQuality ()
	{
		DecreaseQuality ();
		DecreaseQuality ();
	}
}
