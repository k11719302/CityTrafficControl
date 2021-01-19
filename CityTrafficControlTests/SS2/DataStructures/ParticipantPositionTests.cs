using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.SS2.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControlTests.SS2.DataStructures {
	[TestClass]
	public class ParticipantPositionTests {
		[TestMethod]
		public void Test_PositionChangeable() {
			ParticipantPosition pos = new ParticipantPosition(0, 0);
			Coordinate start = new Coordinate(0, 0), end = new Coordinate(13, 44);

			Assert.AreEqual(start.X, pos.X);
			Assert.AreEqual(start.Y, pos.Y);

			pos.PosX = 13; pos.PosY = 44;

			Assert.AreEqual(end.X, pos.X);
			Assert.AreEqual(end.Y, pos.Y);
		}
	}
}
