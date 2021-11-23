using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using FluentAssertions;
using NUnit.Framework;
using LazyLoad.ValueHolder;

namespace LazyLoad.Test
{
    [TestFixture]
    public class ValueHolderShould
    {
        [Test]
        public void NotLoadItemsUntilReferenced()
        {
            int orderId = 123;
            var order = new OrderFactory().CreateFromId(orderId);

            Assert.AreEqual(orderId, order.Id);

            // should trigger DB call
            var items = order.Items;

            Assert.AreEqual(0, items.Count);
        }
    }
}
