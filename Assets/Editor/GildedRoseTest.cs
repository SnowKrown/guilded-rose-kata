using System.Collections.Generic;
using NUnit.Framework;
using GildedRose.Console;

[TestFixture]
public class GildedRoseTest 
{

	private Program app;

	[SetUp]
	public void Setup ()
	{
		app = new Program ();
	}

	public void CreateItem(int sellIn, int quality, ItemType type)
	{
		List<DetailedItem> list = new List<DetailedItem>();
		list.Add(new DetailedItem{Name = "name", SellIn = sellIn, Quality = quality, Type = type});
		app.Items = list;
	}

	[Test]
	public void ProbeThatTheSellInIsDecreasedByOneAfterOneDayForNormalTypeItems ()
	{
		CreateItem(10, 1, ItemType.Normal);
		CallUpdateQuality (1);
		Assert.AreEqual (9, app.Items[0].SellIn);
	}

	[Test]
	public void ProbeQualityIsDecreasedByOneAfterOneDayForNormalTypeItems ()
	{
		CreateItem(10, 1, ItemType.Normal);
		CallUpdateQuality (1);
		Assert.AreEqual (0, app.Items[0].Quality);
	}

	[Test]
	public void ProbeThatQualityCantBeNegativeForNormalTypeItems ()
	{
		CreateItem(10, 1, ItemType.Normal);
		CallUpdateQuality (2);
		Assert.AreEqual (0, app.Items[0].Quality);
	}

	[Test]
	public void ProbeThatItemsCanIncreaseQualityOverFiftyForInvestmentCollectableTypeItems ()
	{
		CreateItem (10, 49, ItemType.InvestmentCollectable);
		CallUpdateQuality (2);
		Assert.AreEqual(50, app.Items[0].Quality);
	}

	[Test]
	public void ProbeThatIfSellInIsLowerThanZeroQualityDecreaseByTwoForNormalTypeItems ()
	{
		CreateItem (0, 2, ItemType.Normal);
		CallUpdateQuality (1);
		Assert.AreEqual (0, app.Items[0].Quality);
	}

	[Test]
	public void ProbeThatInvestmentCollectableTypeItemsIncreaseQualityOverTime ()
	{
		CreateItem (10, 49, ItemType.InvestmentCollectable);
		CallUpdateQuality (1);
		Assert.AreEqual (50, app.Items[0].Quality);
	}

	[Test]
	public void ProbeThatInmutableTypeItemsQualityRemainsInEighty()
	{
		CreateItem (0, 80, ItemType.Inmutable);
		CallUpdateQuality (1);
		Assert.AreEqual(80, app.Items[0].Quality);
	}

	[Test]
	public void ProbeThatTicketTypeItemsIncreaseItsQualityByOneWhenItsSellInIsHigherThanTen()
	{
		CreateItem (11, 10, ItemType.Ticket);
		CallUpdateQuality (1);
		Assert.AreEqual(11, app.Items[0].Quality);
	}

	[Test]
	public void ProbeThatTicketTypeItemsIncreaseItsQualityByTwoWhenItsSellInIsLowerThanTenAndHigherThanFive ()
	{
		CreateItem (11, 10, ItemType.Ticket);
		CallUpdateQuality (2);
		Assert.AreEqual (13, app.Items[0].Quality);
	}

	[Test]
	public void ProbeThatTicketTypeItemsIncreasesItsQualityByThreeWhenSellInIsLowerThanFiveAndHigherThanZero ()
	{
		CreateItem (5, 4, ItemType.Ticket);
		CallUpdateQuality (1);
		Assert.AreEqual (7, app.Items[0].Quality);
	}

	[Test]
	public void ProbeThatTicketTypeItemsQualityIsZeroWhenItsSellInIsZero ()
	{
		CreateItem (0, 4, ItemType.Ticket);
		CallUpdateQuality (1);
		Assert.AreEqual(0, app.Items[0].Quality);
	}

	private void CallUpdateQuality (int times)
	{
		for (int i = 0; i < times; i++)
			app.UpdateQuality ();
	}
}