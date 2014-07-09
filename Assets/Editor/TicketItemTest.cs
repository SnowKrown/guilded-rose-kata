using System.Collections.Generic;
using NUnit.Framework;

namespace UnityTest
{
	[TestFixture]
	internal class TicketItemTest 
	{
		private TicketItem item;
		
		public void UpdateItem (int sellIn, int quality)
		{
			item = new TicketItem ("Item", sellIn, quality);
			item.Update();
		}

		[Test]
		public void ProbeThatQualityIsIncreasedByOneWhenItsSellInIsHigherThanTen ()
		{
			UpdateItem (11, 10);
			Assert.AreEqual(11, item.Quality);
		}

		[Test]
		public void ProbeQualityIsIncreasedByTwoWhenSellInIsBetweenTenAndFive ()
		{
			UpdateItem (11, 10);
			item.Update();
			Assert.AreEqual (13, item.Quality);
		}

		[Test]
		public void ProbeQualityIsIncreasedByThreeWhenSellInIsBetweenFiveAndZero ()
		{
			UpdateItem(5, 4);
			Assert.AreEqual (7, item.Quality);
		}

		[Test]
		public void ProbeThatQualityIsZeroWhenSellInIsZero ()
		{
			UpdateItem(0, 4);
			Assert.AreEqual(0, item.Quality);
		}
	}
}
