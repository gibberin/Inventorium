using System;
using Xunit;
using NventoriumLib;

namespace NventoriumTests
{
    public class NvLibTests
    {
        [Fact]
        public void ObjectTest()
        {
            InvObject newObj = new InvObject();

            Assert.True(0 < newObj.ID.ToString().Length);
        }
    }
}
