using System.Collections.Generic;
using NUnit.Framework;

namespace UnityTest
{
	[TestFixture]
	internal class NormalItemTest 
	{
		private NormalItem item;

		public void UpdateItem (int sellIn, int quality)
		{
			item = new NormalItem ("Item", sellIn, quality);
			item.Update();
		}

		[Test]
		public void ProbeQualityIsDecreaseByOneAfterOneDay ()
		{
			UpdateItem(1, 2);
			Assert.AreEqual (1, item.Quality);
		}

		[Test]
		public void ProbeThatTheSellInIsDecreasedByOneAfterOneDay ()
		{
			UpdateItem(2, 1);
			Assert.AreEqual (1, item.SellIn);
		}

		[Test]
		public void ProbeThatQualityCantBeNegative()
		{
			UpdateItem(10, 0);
			Assert.AreEqual (0, item.Quality);
		}

		[Test]
		public void ProbeThatIfSellInIsLowerThanZeroQualityDecreaseByTwo ()
		{
			UpdateItem(0, 2);
			Assert.AreEqual (0, item.Quality);
		}
	}
}
