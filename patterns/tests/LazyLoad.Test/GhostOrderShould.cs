using LazyLoad.Ghosts;
using NUnit.Framework;
using System.Linq;

namespace LazyLoad.Test
{
    [TestFixture]
    public class GhostOrderShould
    {
        protected class TestOrderWrapper : Order
        {
            public bool WasLoadCalled = false;
            public int GetDataRowCount = 0;
            public TestOrderWrapper(int id) : base(id)
            { }

            public override void Load()
            {
                WasLoadCalled = true;
                base.Load();
            }

            protected override System.Collections.ArrayList GetDataRow()
            {
                GetDataRowCount++;
                return base.GetDataRow();
            }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadItselfOnlyOnceOnPropertyAccess()
        {
            int orderId = 123;
            var order = new TestOrderWrapper(orderId);

            Assert.AreEqual(orderId, order.Id);

            Assert.IsFalse(order.WasLoadCalled);
            Assert.AreEqual(0, order.GetDataRowCount);

            // should call Load and GetDataRow once
            var shipMethod = order.ShipMethod;
            Assert.IsTrue(order.WasLoadCalled);
            Assert.AreEqual(1, order.GetDataRowCount);

            // should not increment GetDataRowCount
            var customer = order.Customer;
            Assert.IsTrue(order.WasLoadCalled);
            Assert.AreEqual(1, order.GetDataRowCount);
        }

        [Test]
        public void LoadItemsInSingleCallOnPropertyAccess()
        {
            int orderId = 123;
            var order = new Order(123);

            int itemCount = order.Items.Count(); // should call repository here 
            Assert.AreEqual(3, itemCount);
        }
    }
}