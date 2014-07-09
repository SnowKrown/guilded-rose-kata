using System.Collections.Generic;
using NUnit.Framework;

namespace UnityTest
{
	[TestFixture]
	internal class InvestmentCollectableItemTest
	{
		private InvestmentCollectableItem item;
		
		public void UpdateItem (int sellIn, int quality)
		{
			item = new InvestmentCollectableItem ("Item", sellIn, quality);
			item.Update();
		}
		
		[Test]
		public void ProbeThatQualityIsIncreasedOverTime ()
		{
			UpdateItem (10, 49);
			Assert.AreEqual (50, item.Quality);
		}

		[Test]
		public void ProbeThatItemsCantIncreaseQualityOverFifty ()
		{
			UpdateItem (10, 50);
			Assert.AreEqual(50, item.Quality);
		}
	}
}
