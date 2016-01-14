//using System;
//using System.Collections.Generic;
//using System.Threading;
//using NUnit.Framework;
//using UnityEngine;
//
//namespace UnityTest
//{
//	[TestFixture]
//	[Category("Probability Tests")]
//	internal class ProbabilityTests
//	{
//		[Test]
//		public void Test1()
//		{
//			List<Unit> attackers = new List<Unit>(6);
//			List<Unit> defenders = new List<Unit>(6);
//			attackers.Add(new Infantry());
//			var battle = new Battle(attackers, defenders);
//			var odds = battle.AttackerOdds.OddsOf(1);
//			Assert.AreEqual (1 / 6.0, odds);
//		}
//
//		[Test]
//		public void Test2()
//		{
//			List<Unit> attackers = new List<Unit>(6);
//			List<Unit> defenders = new List<Unit>(6);
//			attackers.Add(new Infantry());
//			attackers.Add(new Infantry());
//			var battle = new Battle(attackers, defenders);
//			var odds = battle.AttackerOdds.OddsOf(1);
//			Assert.AreEqual (2 * ((1 / 6.0) * (5 / 6.0)), odds);
//		}
//
//		[Test]
//		public void Test3()
//		{
//			List<Unit> attackers = new List<Unit>(6);
//			List<Unit> defenders = new List<Unit>(6);
//			attackers.Add(new Infantry());
//			attackers.Add(new Infantry());
//			attackers.Add(new Infantry());
//			var battle = new Battle(attackers, defenders);
//			var odds = battle.AttackerOdds.OddsOf(1);
//			Assert.AreEqual (3 * ((1 / 6.0) * (5 / 6.0) * (5 / 6.0)), odds);
//		}
//
//		[Test]
//		public void Test4()
//		{
//			List<Unit> attackers = new List<Unit>(6);
//			List<Unit> defenders = new List<Unit>(6);
//			attackers.Add(new Tank());
//			var battle = new Battle(attackers, defenders);
//			var odds = battle.AttackerOdds.OddsOf(1);
//			Assert.AreEqual (3 / 6.0, odds);
//		}
//
//		[Test]
//		public void Test5()
//		{
//			List<Unit> attackers = new List<Unit>(6);
//			List<Unit> defenders = new List<Unit>(6);
//			attackers.Add(new Tank());
//			attackers.Add(new Tank());
//			var battle = new Battle(attackers, defenders);
//			var odds = battle.AttackerOdds.OddsOf(1);
//			Assert.AreEqual (2 * ((3 / 6.0) * (3 / 6.0)), odds);
//		}
//
//		[Test]
//		public void Test6()
//		{
//			List<Unit> attackers = new List<Unit>(6);
//			List<Unit> defenders = new List<Unit>(6);
//			attackers.Add(new Tank());
//			attackers.Add(new Tank());
//			attackers.Add(new Tank());
//			var battle = new Battle(attackers, defenders);
//			var odds = battle.AttackerOdds.OddsOf(1);
//			Assert.AreEqual (3 * ((3 / 6.0) * (3 / 6.0) * (3 / 6.0)), odds);
//		}
//
//		[Test]
//		public void TestRussia1()
//		{
//			List<Unit> attackers = new List<Unit>(6);
//			List<Unit> defenders = new List<Unit>(6);
//			attackers.Add(new Infantry());
//			attackers.Add(new Infantry());
//			attackers.Add(new Infantry());
//			attackers.Add(new Infantry());
//			attackers.Add(new Infantry());
//			attackers.Add(new Infantry());
//			attackers.Add(new Artillery());
//			attackers.Add(new Artillery());
//			attackers.Add(new Artillery());
//			attackers.Add(new Fighter());
//			attackers.Add(new Fighter());
//			var battle = new Battle(attackers, defenders);
//			var odds = battle.AttackerOdds.OddsOf(1);
//			Assert.AreEqual (
//				(1 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (1 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (5 / 6.0) * (1 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (2 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (2 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (2 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (2 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (2 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (2 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0) +
//				(5 / 6.0) * (5 / 6.0) * (5 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (4 / 6.0) * (3 / 6.0) * (3 / 6.0), odds);
//		}
//	}
//}