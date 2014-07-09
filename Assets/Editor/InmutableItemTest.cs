using System.Collections.Generic;
using NUnit.Framework;

namespace UnityTest
{
	[TestFixture]
	internal class InmutableItemTest 
	{
		[Test]
		public void ProbeThatQualityRemainsInEighty()
		{
			InmutableItem item = new InmutableItem ("Item");
			item.Update ();
			Assert.AreEqual(80, item.Quality);
		}
	}
}
