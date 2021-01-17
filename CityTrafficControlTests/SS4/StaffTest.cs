using CityTrafficControl.SS4;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CityTrafficControlTests.SS4
{
	[TestClass]
	public class StaffTest
	{
		Team team1;
		Team team2;
		Team team3;
		Dictionary<int, Person> workers1;
		Dictionary<int, Person> workers2;
		Dictionary<int, Person> workers3;

		[TestInitialize]
		public void Test_Init()
		{
			workers1 = new Dictionary<int, Person>();
			workers2 = new Dictionary<int, Person>();
			workers3 = new Dictionary<int, Person>();

			Person p1 = new Person(1, "Martin", "spec1");
			p1.SetOperational(false);
			Person p2 = new Person(2, "Hans", "spec2");
			p2.SetOperational(false);

			workers1.Add(p1);
			workers1.Add(p2);
			workers1.Add(new Person(3, "John", "spec3"));

			team1 = new Team(workers1, 1);

			workers2.Add(new Person(1, "Peter", "spec1"));
			workers2.Add(new Person(2, "Markus", "spec2"));
			workers2.Add(new Person(3, "Klaus", "spec3"));

			team2 = new Team(workers2, 2);

			Person p3 = new Person(1, "Hubert", "spec1");
			p3.SetOperational(false);
			Person p4 = new Person(2, "Ludwig", "spec3");
			p4.SetOperational(false);

			workers3.Add(p3);
			workers3.Add(new Person(2, "Robert", "spec2"));
			workers3.Add(p4);

			team3 = new Team(workers3, 3);
		}

		[TestMethod]
		public void Test_IsReady_Team()
        {
			Staff staff = new Staff();

			team1.SetOnMission(true);
			team2.SetOnMission(false);
			team3.SetOnMission(true);

			staff.CreateTeam(team1);
			staff.CreateTeam(team2);
			staff.CreateTeam(team3);

			Assert.Equals(false, staff.IsReady(team1));
			Assert.Equals(true, staff.IsReady(team2));
			Assert.Equals(false, staff.IsReady(team3));
        }
	}
}
