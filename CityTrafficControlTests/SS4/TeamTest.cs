using CityTrafficControl.SS4;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CityTrafficControlTests.SS4
{
	[TestClass]
	public class TeamTest
	{
		Dictionary<int, Person> workers;

		[TestInitialize]
		public void Test_Init()
        {
			workers = new Dictionary<int, Person>();

			workers.Add(new Person(1, "Martin", "spec1"));
			workers.Add(new Person(2, "Hans", "spec2"));
			workers.Add(new Person(3, "Peter", "spec3"));
			workers.Add(new Person(4, "Markus", "spec4"));
			workers.Add(new Person(5, "Klaus", "spec5"));

		}



		[TestMethod]
		public void Test_AddWorker()
        {
			Team team = new Team(workers, 1);

			Assert.Equals(5, team.GetAmount());

			team.Add(new Person(6, "Thomas", "spec6"));
			team.Add(new Person(7, "Sebastian", "spec7"));

			Assert.Equals(7, team.GetAmount());

			team.Add(new Person(8, "Paul", "spec8"));

			Assert.Equals(8, team.GetAmount());
        }

		[TestMethod]
		public void Test_RemoveWorker()
        {
			Team team = new Team(workers, 1);

			Assert.Equals(true, team.RemoveWorker(1));

			Assert.Equals(4, team.GetAmount());

			Assert.Equals(false, team.RemoveWorker(1));

			Assert.Equals(false, team.RemoveWorker(10));

			Assert.Equals(false, team.RemoveWorker(-100));

			Assert.Equals(false, team.RemoveWorker(69));
		}

		[TestMethod]
		public void Test_HasEnoughManpower()
        {
			Team team = new Team(workers, 1);

			Assert.Equals(true, team.HasEnoughManpower());

			Person p1 = new Person(6, "Lukas", "spec6");
			p1.SetOperational(false);
			Person p2 = new Person(7, "Frank", "spec7");
			p2.SetOperational(false);
			Person p3 = new Person(8, "Tobias", "spec8");
			p3.SetOperational(false);
			Person p4 = new Person(9, "Christian", "spec9");
			p4.SetOperational(false);

			team.Add(p1);
			team.Add(p2);
			team.Add(p3);
			team.Add(p4);
			
			Assert.Equals(true, team.HasEnoughManpower());

			Person p5 = new Person(10, "Fabian", "spec10");
			p5.SetOperational(false);
			Person p6 = new Person(11, "Heinz", "spec11");
			p6.SetOperational(false);

			team.Add(p5);
			team.Add(p6);
        }
	}
}
