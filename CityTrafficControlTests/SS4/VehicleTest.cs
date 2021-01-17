using CityTrafficControl.SS4;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CityTrafficControlTests.SS4
{
	[TestClass]
	public class VehicleTest
	{
		Vehicle vehicle1;
		Vehicle vehicle2;
		Vehicle vehicle3;

		[TestInitialize]
		public void Test_Init()
        {
			vehicle1 = new Vehicle(1, "Auto1");
			vehicle2 = new Vehicle(2, "Auto2");
			vehicle3 = new Vehicle(3, "Auto3");
        }

		[TestMethod]
		public void Test_SendToMaintenance()
        {
			Assert.Equals(false, vehicle1.GetInMaintenance());
			vehicle1.SendToMaintenance();
			Assert.Equals(false, vehicle1.SendToMaintenance());
			Assert.Equals(true, vehicle1.GetInMaintenance());

			vehicle2.SendToMaintenance();
			Assert.Equals(true, vehicle2.GetInMaintenance());

			Assert.Equals(false, vehicle3.GetInMaintenance());
			vehicle3.SendToMaintenance();
			Assert.Equals(true, vehicle3.GetInMaintenance());
        }

		[TestMethod]
		public void Test_GetFromMaintenance()
        {
			vehicle1.SendToMaintenance();
			Assert.Equals(true, vehicle1.GetInMaintenance());
			vehicle1.GetFromMaintenance();
			Assert.Equals(false, vehicle1.GetInMaintenance());

			Assert.Equals(false, vehicle2.GetFromMaintenance());
			vehicle2.SendToMaintenance();
			Assert.Equals(true, vehicle2.GetFromMaintenance());

			vehicle3.SendToMaintenance();
			Assert.Equals(true, vehicle3.GetFromMaintenance());
        }
	}
}
