using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest
{
	[TestFixture]
	[Category("Probability Tests")]
	internal class ProbabilityTests
	{
		[Test]
		public void Test1()
		{
			List<Unit> attackers = new List<Unit>(6);
			List<Unit> defenders = new List<Unit>(6);
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (1 / 6.0, odds);
		}

		[Test]
		public void Test2()
		{
			List<Unit> attackers = new List<Unit>(6);
			List<Unit> defenders = new List<Unit>(6);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (2 * ((1 / 6.0) * (5 / 6.0)), odds);
		}

		[Test]
		public void Test3()
		{
			List<Unit> attackers = new List<Unit>(6);
			List<Unit> defenders = new List<Unit>(6);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (3 * ((1 / 6.0) * (5 / 6.0) * (5 / 6.0)), odds);
		}

		[Test]
		public void Test4()
		{
			List<Unit> attackers = new List<Unit>(6);
			List<Unit> defenders = new List<Unit>(6);
			attackers.Add(new Tank());
			var battle = new Battle(attackers, defenders);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (3 / 6.0, odds);
		}

		[Test]
		public void Test5()
		{
			List<Unit> attackers = new List<Unit>(6);
			List<Unit> defenders = new List<Unit>(6);
			attackers.Add(new Tank());
			attackers.Add(new Tank());
			var battle = new Battle(attackers, defenders);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (2 * ((3 / 6.0) * (3 / 6.0)), odds);
		}

		[Test]
		public void Test6()
		{
			List<Unit> attackers = new List<Unit>(6);
			List<Unit> defenders = new List<Unit>(6);
			attackers.Add(new Tank());
			attackers.Add(new Tank());
			attackers.Add(new Tank());
			var battle = new Battle(attackers, defenders);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (3 * ((3 / 6.0) * (3 / 6.0) * (3 / 6.0)), odds);
		}

		[Test]
		public void TestThreeInfantry()
		{
			List<Unit> attackers = new List<Unit>(3);
			List<Unit> defenders = new List<Unit>(3);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders);
			var odds3 = battle.AttackerOdds.OddsOf(3);
			var odds2 = battle.AttackerOdds.OddsOf(2);
			var odds1 = battle.AttackerOdds.OddsOf(1);
			var odds0 = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual (1, odds3 + odds2 + odds1 + odds0);
		}

		[Test]
		public void TestFourInfantry()
		{
			List<Unit> attackers = new List<Unit>(4);
			List<Unit> defenders = new List<Unit>(4);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders);
			var odds4 = battle.AttackerOdds.OddsOf(4);
			var odds3 = battle.AttackerOdds.OddsOf(3);
			var odds2 = battle.AttackerOdds.OddsOf(2);
			var odds1 = battle.AttackerOdds.OddsOf(1);
			var odds0 = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual (1, odds4 + odds3 + odds2 + odds1 + odds0);
		}

		[Test]
		public void TestFiveInfantry()
		{
			List<Unit> attackers = new List<Unit>(5);
			List<Unit> defenders = new List<Unit>(5);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders);
			var odds5 = battle.AttackerOdds.OddsOf(5);
			var odds4 = battle.AttackerOdds.OddsOf(4);
			var odds3 = battle.AttackerOdds.OddsOf(3);
			var odds2 = battle.AttackerOdds.OddsOf(2);
			var odds1 = battle.AttackerOdds.OddsOf(1);
			var odds0 = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual (1, odds5 + odds4 + odds3 + odds2 + odds1 + odds0);
		}

		[Test]
		public void TestTenInfantry1()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders);
			var odds = battle.AttackerOdds.OddsOf(10);
			Assert.AreEqual( (1 / 6.0) * (1 / 6.0) * (1 / 6.0) * (1 / 6.0) * (1 / 6.0) * (1 / 6.0) * (1 / 6.0) * (1 / 6.0) * (1 / 6.0) * (1 / 6.0), odds);
		}

		[Test]
		public void TestTenInfantry2()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders);
			var odds10 = battle.AttackerOdds.OddsOf(10);
			var odds9 = battle.AttackerOdds.OddsOf(9);
			var odds8 = battle.AttackerOdds.OddsOf(8);
			var odds7 = battle.AttackerOdds.OddsOf(7);
			var odds6 = battle.AttackerOdds.OddsOf(6);
			var odds5 = battle.AttackerOdds.OddsOf(5);
			var odds4 = battle.AttackerOdds.OddsOf(4);
			var odds3 = battle.AttackerOdds.OddsOf(3);
			var odds2 = battle.AttackerOdds.OddsOf(2);
			var odds1 = battle.AttackerOdds.OddsOf(1);
			var odds0 = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual (odds10 + odds9 + odds8 + odds7 + odds6 + odds5 + odds4 + odds3 + odds2 + odds1 + odds0, 1);
		}

		[Test]
		public void TestRussia1()
		{
			List<Unit> attackers = new List<Unit>(6);
			List<Unit> defenders = new List<Unit>(6);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Artillery());
			attackers.Add(new Artillery());
			attackers.Add(new Artillery());
			attackers.Add(new Fighter());
			attackers.Add(new Fighter());
			var battle = new Battle(attackers, defenders);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (
				(1 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (1 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (5 / 6.0) * (1 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (2 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (2 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (2 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (2 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (2 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (2 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0), odds);
		}
	}
}