using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityTrafficControl.SS4;


namespace CityTrafficControlTests.SS4
{
	[TestClass]
	public class ScheduleTest
	{
		Schedule schedule;

		[TestInitialize]
		public void Test_Init()
		{
			schedule = new Schedule(1, null, DateTime.MinValue, DateTime.MinValue);
		}

		[TestMethod]
		public void Test_Progress()
        {
			Assert.ThrowsException<ArgumentException>(() => schedule.SetProgress(-1));

			schedule.SetProgress(100);
			Assert.AreEqual(100, schedule.GetProgress());

			Assert.ThrowsException<ArgumentException>(() => schedule.SetProgress(102));

			schedule.SetProgress(0.1);
			Assert.AreEqual(0.1, schedule.GetProgress());
        }
	}
}
