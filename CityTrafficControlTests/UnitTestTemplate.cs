using CityTrafficControl;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// See: https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019

namespace CityTrafficControlTests {
	[TestClass]
	public class UnitTestTemplate {
		[TestMethod]
		public void Test_NormalAdditionTest() {
			// arrange/initialize
			int a = 2, b = 3, actual;
			int expected = 5;

			// act/run
			actual = a + b;

			// assert/check
			Assert.AreEqual(expected, actual, "Addition of 2 and 3 should be 5");
		}

		[TestMethod]
		public void Test_DivisionByZeroException() {
			// arrange/initialize
			int a = 2, b = 0, result;

			// act/run + assert/check
			Assert.ThrowsException<DivideByZeroException>(() => result = a / b);
		}
	}
}
