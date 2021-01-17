using CityTrafficControl.SS4;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CityTrafficControlTests.SS4
{
	[TestClass]
	public class ScheduleTest
	{
		Schedule schedule;

		[TestInitialize]
		public void Test_Init()
		{
			schedule = new Schedule(1, null, null, null);
		}

		[TestMethod]
		public void Test_Progress()
        {
			Assert.ThrowsException<ArgumentException>(schedule.SetProgress(-1));

			schedule.SetProgress(100);
			Assert.Equals(100, schedule.GetProgress());

			Assert.ThrowsException<ArgumentException>(schedule.SetProgress(102));

			schedule.SetProgress(0.1);
			Assert.Equals(0.1, schedule.GetProgress());
        }
	}
}
