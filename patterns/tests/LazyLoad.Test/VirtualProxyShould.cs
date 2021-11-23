using FluentAssertions;
using LazyLoad.VirtualProxy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Test
{
    [TestFixture]
    public class VirtualProxyShould
    {
      
        [Test]
        public void PrintLabelWithOrderProxy()
        {
            int testOrderId = 123;
            var order = (OrderFactory.CreateFromId(testOrderId));
            Assert.AreEqual(testOrderId, order.Id); // should not have constructed Customer at this point
            testOrderId.Should().Be(order.Id);
            string result = order.PrintLabel();
            result.Should().Be("Company Name\nDefault Address");
        }

    }
}
