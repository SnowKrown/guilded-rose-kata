using System.Collections.Generic;
using NUnit.Framework;

namespace UnityTest
{
	[TestFixture]
	internal class ConjuredItemTest 
	{
		[Test]
		public void ProbeThatQualityIsDecreasedByTwo()
		{
			ConjuredItem item = new ConjuredItem ("Item", 2, 4);
			item.Update ();
			Assert.AreEqual(2, item.Quality);
		}
	}
}
