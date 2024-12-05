using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectXUnitVijaySales.Utility;

namespace VijaySales.Tests.OrderProcessingTests
{
    public class TestOrderProcessing
    {
        [Fact]
        public static void CurrentDayTest()
        {
            DateTime dateTime = DateTime.Now;
            int expectedDay = 19;
            int actualDay = dateTime.Day;
            Assert.Equal(expectedDay, actualDay);
        }

        [Fact]
        public void OrderCollectionTest()
        {
            FlowersUtility mgr = new FlowersUtility();
            List<string> allFlowers = mgr.GetTodayFreshFlowers();
            //................
            Assert.Equal(56, 1);
        }

        [Fact]
        public void OrderCancellationTest()
        {
            FlowersUtility mgr = new FlowersUtility();
            List<string> allFlowers = mgr.GetTodayFreshFlowers();
            Assert.Equal(56, 1);
        }


        [Fact]
        public void OrderApprovalTest()
        {
            Assert.Equal(56, 1);
        }
    }
}
