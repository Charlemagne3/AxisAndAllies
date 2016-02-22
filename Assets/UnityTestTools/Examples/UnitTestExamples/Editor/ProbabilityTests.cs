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
		[SetUp] public void Init()
		{
			NUnit.Framework.GlobalSettings.DefaultFloatingPointTolerance = 0.0000000001;
		}

		[Test]
		public void TestOneInfantry0()
		{
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(5 / 6.0, odds);
		}

		[Test]
		public void TestOneInfantry1()
		{
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual(1 / 6.0, odds);
		}

		[Test]
		public void TestTwoInfantry0()
		{
			List<Unit> attackers = new List<Unit>(2);
			List<Unit> defenders = new List<Unit>(2);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(25 / 36.0, odds);
		}

		[Test]
		public void TestTwoInfantry1()
		{
			List<Unit> attackers = new List<Unit>(2);
			List<Unit> defenders = new List<Unit>(2);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual((
				5 * 1 +
				1 * 5) / 36.0, odds);
		}

		[Test]
		public void TestTwoInfantry2()
		{
			List<Unit> attackers = new List<Unit>(2);
			List<Unit> defenders = new List<Unit>(2);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(2);
			Assert.AreEqual(1 / 36.0, odds);
		}

		[Test]
		public void TestThreeInfantry0()
		{
			List<Unit> attackers = new List<Unit>(3);
			List<Unit> defenders = new List<Unit>(3);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(125 / 216.0, odds);
		}

		[Test]
		public void TestThreeInfantry1()
		{
			List<Unit> attackers = new List<Unit>(3);
			List<Unit> defenders = new List<Unit>(3);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual((
				5 * 5 * 1 +
				5 * 1 * 5 +
				1 * 5 * 5) / 216.0, odds);
		}

		[Test]
		public void TestThreeInfantry2()
		{
			List<Unit> attackers = new List<Unit>(3);
			List<Unit> defenders = new List<Unit>(3);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(2);
			Assert.AreEqual((
				5 * 1 * 1 +
				1 * 5 * 1 +
				1 * 1 * 5) / 216.0, odds);
		}

		[Test]
		public void TestThreeInfantry3()
		{
			List<Unit> attackers = new List<Unit>(3);
			List<Unit> defenders = new List<Unit>(3);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(3);
			Assert.AreEqual(1 / 216.0, odds);
		}

		[Test]
		public void TestOneTank1()
		{
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Tank());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (3 / 6.0, odds);
		}

		[Test]
		public void TestTwoTanks1()
		{
			List<Unit> attackers = new List<Unit>(2);
			List<Unit> defenders = new List<Unit>(2);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Tank());
			attackers.Add(new Tank());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (2 * ((3 / 6.0) * (3 / 6.0)), odds);
		}

		[Test]
		public void TestThreeTanks1()
		{
			List<Unit> attackers = new List<Unit>(3);
			List<Unit> defenders = new List<Unit>(3);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Tank());
			attackers.Add(new Tank());
			attackers.Add(new Tank());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual (3 * ((3 / 6.0) * (3 / 6.0) * (3 / 6.0)), odds);
		}

		[Test]
		public void TestThreeInfantrySum()
		{
			List<Unit> attackers = new List<Unit>(3);
			List<Unit> defenders = new List<Unit>(3);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds3 = battle.AttackerOdds.OddsOf(3);
			var odds2 = battle.AttackerOdds.OddsOf(2);
			var odds1 = battle.AttackerOdds.OddsOf(1);
			var odds0 = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(1, odds3 + odds2 + odds1 + odds0);
		}

		[Test]
		public void TestFourInfantry0()
		{
			List<Unit> attackers = new List<Unit>(4);
			List<Unit> defenders = new List<Unit>(4);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(625 / 1296.0, odds);
		}

		[Test]
		public void TestFourInfantry1()
		{
			List<Unit> attackers = new List<Unit>(4);
			List<Unit> defenders = new List<Unit>(4);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual((	
				5 * 5 * 5 * 1 +
				5 * 5 * 1 * 5 +
				5 * 1 * 5 * 5 + 
				1 * 5 * 5 * 5) / 1296.0, odds);
		}

		[Test]
		public void TestFourInfantry2()
		{
			List<Unit> attackers = new List<Unit>(4);
			List<Unit> defenders = new List<Unit>(4);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(2);
			Assert.AreEqual((	
				5 * 5 * 1 * 1 +
				5 * 1 * 5 * 1 +
				5 * 1 * 1 * 5 + 
				1 * 5 * 5 * 1 + 
				1 * 5 * 1 * 5 +
				1 * 1 * 5 * 5) / 1296.0, odds);
		}

		[Test]
		public void TestFourInfantry3()
		{
			List<Unit> attackers = new List<Unit>(4);
			List<Unit> defenders = new List<Unit>(4);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(3);
			Assert.AreEqual((	
				5 * 1 * 1 * 1 +
				1 * 5 * 1 * 1 +
				1 * 1 * 5 * 1 +
				1 * 1 * 1 * 5) / 1296.0, odds);
		}

		[Test]
		public void TestFourInfantry4()
		{
			List<Unit> attackers = new List<Unit>(4);
			List<Unit> defenders = new List<Unit>(4);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(4);
			Assert.AreEqual(1 / 1296.0, odds);
		}

		[Test]
		public void TestFourInfantrySum()
		{
			List<Unit> attackers = new List<Unit>(4);
			List<Unit> defenders = new List<Unit>(4);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds4 = battle.AttackerOdds.OddsOf(4);
			var odds3 = battle.AttackerOdds.OddsOf(3);
			var odds2 = battle.AttackerOdds.OddsOf(2);
			var odds1 = battle.AttackerOdds.OddsOf(1);
			var odds0 = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(1, odds4 + odds3 + odds2 + odds1 + odds0);
		}

		[Test]
		public void TestFiveInfantrySum()
		{
			List<Unit> attackers = new List<Unit>(5);
			List<Unit> defenders = new List<Unit>(5);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds5 = battle.AttackerOdds.OddsOf(5);
			var odds4 = battle.AttackerOdds.OddsOf(4);
			var odds3 = battle.AttackerOdds.OddsOf(3);
			var odds2 = battle.AttackerOdds.OddsOf(2);
			var odds1 = battle.AttackerOdds.OddsOf(1);
			var odds0 = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(1, odds5 + odds4 + odds3 + odds2 + odds1 + odds0);
		}

		[Test]
		public void TestTenInfantry10()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(10);
			Assert.AreEqual(1 / 60466176.0, odds);
		}

		[Test]
		public void TestTenInfantry9()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(9);
			Assert.AreEqual((
					5 +
					5 +
					5 +
					5 +
					5 +
					5 +
					5 +
					5 +
					5 +
					5) / 60466176.0, odds);
		}

		[Test]
		public void TestTenInfantry8()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(8);
			Assert.AreEqual((
				5 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 1 * 1 +
				5 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 1 +
				5 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 1 +
				5 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 1 +
				5 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 1 +
				5 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 1 +
				5 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 1 +
				5 * 1 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 1 +
				5 * 1 * 1 * 1 * 1 * 1 * 1 * 1 * 1 * 5 +

				1 * 5 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 1 +
				1 * 5 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 1 +
				1 * 5 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 1 +
				1 * 5 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 1 +
				1 * 5 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 1 +
				1 * 5 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 1 +
				1 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 1 +
				1 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 1 * 5 +

				1 * 1 * 5 * 5 * 1 * 1 * 1 * 1 * 1 * 1 +
				1 * 1 * 5 * 1 * 5 * 1 * 1 * 1 * 1 * 1 +
				1 * 1 * 5 * 1 * 1 * 5 * 1 * 1 * 1 * 1 +
				1 * 1 * 5 * 1 * 1 * 1 * 5 * 1 * 1 * 1 +
				1 * 1 * 5 * 1 * 1 * 1 * 1 * 5 * 1 * 1 +
				1 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 5 * 1 +
				1 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 5 +

				1 * 1 * 1 * 5 * 5 * 1 * 1 * 1 * 1 * 1 +
				1 * 1 * 1 * 5 * 1 * 5 * 1 * 1 * 1 * 1 +
				1 * 1 * 1 * 5 * 1 * 1 * 5 * 1 * 1 * 1 +
				1 * 1 * 1 * 5 * 1 * 1 * 1 * 5 * 1 * 1 +
				1 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 5 * 1 +
				1 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 5 +

				1 * 1 * 1 * 1 * 5 * 5 * 1 * 1 * 1 * 1 +
				1 * 1 * 1 * 1 * 5 * 1 * 5 * 1 * 1 * 1 +
				1 * 1 * 1 * 1 * 5 * 1 * 1 * 5 * 1 * 1 +
				1 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 5 * 1 +
				1 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 5 +

				1 * 1 * 1 * 1 * 1 * 5 * 5 * 1 * 1 * 1 +
				1 * 1 * 1 * 1 * 1 * 5 * 1 * 5 * 1 * 1 +
				1 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 5 * 1 +
				1 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 5 +

				1 * 1 * 1 * 1 * 1 * 1 * 5 * 5 * 1 * 1 +
				1 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 5 * 1 +
				1 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 5 +

				1 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 5 * 1 +
				1 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 5 +

				1 * 1 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 5) / 60466176.0, odds);
		}

		[Test]
		public void TestTenInfantry7()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(7);
			Assert.AreEqual((
				5 * 5 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 1 +
				5 * 5 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 1 +
				5 * 5 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 1 +
				5 * 5 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 1 +
				5 * 5 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 1 +
				5 * 5 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 1 +
				5 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 1 +
				5 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 1 * 5 +

				5 * 1 * 5 * 5 * 1 * 1 * 1 * 1 * 1 * 1 +
				5 * 1 * 5 * 1 * 5 * 1 * 1 * 1 * 1 * 1 +
				5 * 1 * 5 * 1 * 1 * 5 * 1 * 1 * 1 * 1 +
				5 * 1 * 5 * 1 * 1 * 1 * 5 * 1 * 1 * 1 +
				5 * 1 * 5 * 1 * 1 * 1 * 1 * 5 * 1 * 1 +
				5 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 5 * 1 +
				5 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 5 +

				5 * 1 * 1 * 5 * 5 * 1 * 1 * 1 * 1 * 1 +
				5 * 1 * 1 * 5 * 1 * 5 * 1 * 1 * 1 * 1 +
				5 * 1 * 1 * 5 * 1 * 1 * 5 * 1 * 1 * 1 +
				5 * 1 * 1 * 5 * 1 * 1 * 1 * 5 * 1 * 1 +
				5 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 5 * 1 +
				5 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 5 +

				5 * 1 * 1 * 1 * 5 * 5 * 1 * 1 * 1 * 1 +
				5 * 1 * 1 * 1 * 5 * 1 * 5 * 1 * 1 * 1 +
				5 * 1 * 1 * 1 * 5 * 1 * 1 * 5 * 1 * 1 +
				5 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 5 * 1 +
				5 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 5 +

				5 * 1 * 1 * 1 * 1 * 5 * 5 * 1 * 1 * 1 +
				5 * 1 * 1 * 1 * 1 * 5 * 1 * 5 * 1 * 1 +
				5 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 5 * 1 +
				5 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 5 +

				5 * 1 * 1 * 1 * 1 * 1 * 5 * 5 * 1 * 1 +
				5 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 5 * 1 +
				5 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 5 +

				5 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 5 * 1 +
				5 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 5 +

				5 * 1 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 5 +

				//

				1 * 5 * 5 * 5 * 1 * 1 * 1 * 1 * 1 * 1 +
				1 * 5 * 5 * 1 * 5 * 1 * 1 * 1 * 1 * 1 +
				1 * 5 * 5 * 1 * 1 * 5 * 1 * 1 * 1 * 1 +
				1 * 5 * 5 * 1 * 1 * 1 * 5 * 1 * 1 * 1 +
				1 * 5 * 5 * 1 * 1 * 1 * 1 * 5 * 1 * 1 +
				1 * 5 * 5 * 1 * 1 * 1 * 1 * 1 * 5 * 1 +
				1 * 5 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 5 +

				1 * 5 * 1 * 5 * 5 * 1 * 1 * 1 * 1 * 1 +
				1 * 5 * 1 * 5 * 1 * 5 * 1 * 1 * 1 * 1 +
				1 * 5 * 1 * 5 * 1 * 1 * 5 * 1 * 1 * 1 +
				1 * 5 * 1 * 5 * 1 * 1 * 1 * 5 * 1 * 1 +
				1 * 5 * 1 * 5 * 1 * 1 * 1 * 1 * 5 * 1 +
				1 * 5 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 5 +

				1 * 5 * 1 * 1 * 5 * 5 * 1 * 1 * 1 * 1 +
				1 * 5 * 1 * 1 * 5 * 1 * 5 * 1 * 1 * 1 +
				1 * 5 * 1 * 1 * 5 * 1 * 1 * 5 * 1 * 1 +
				1 * 5 * 1 * 1 * 5 * 1 * 1 * 1 * 5 * 1 +
				1 * 5 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 5 +

				1 * 5 * 1 * 1 * 1 * 5 * 5 * 1 * 1 * 1 +
				1 * 5 * 1 * 1 * 1 * 5 * 1 * 5 * 1 * 1 +
				1 * 5 * 1 * 1 * 1 * 5 * 1 * 1 * 5 * 1 +
				1 * 5 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 5 +

				1 * 5 * 1 * 1 * 1 * 1 * 5 * 5 * 1 * 1 +
				1 * 5 * 1 * 1 * 1 * 1 * 5 * 1 * 5 * 1 +
				1 * 5 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 5 +

				1 * 5 * 1 * 1 * 1 * 1 * 1 * 5 * 5 * 1 +
				1 * 5 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 5 +

				1 * 5 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 5 +

				//

				1 * 1 * 5 * 5 * 5 * 1 * 1 * 1 * 1 * 1 +
				1 * 1 * 5 * 5 * 1 * 5 * 1 * 1 * 1 * 1 +
				1 * 1 * 5 * 5 * 1 * 1 * 5 * 1 * 1 * 1 +
				1 * 1 * 5 * 5 * 1 * 1 * 1 * 5 * 1 * 1 +
				1 * 1 * 5 * 5 * 1 * 1 * 1 * 1 * 5 * 1 +
				1 * 1 * 5 * 5 * 1 * 1 * 1 * 1 * 1 * 5 +

				1 * 1 * 5 * 1 * 5 * 5 * 1 * 1 * 1 * 1 +
				1 * 1 * 5 * 1 * 5 * 1 * 5 * 1 * 1 * 1 +
				1 * 1 * 5 * 1 * 5 * 1 * 1 * 5 * 1 * 1 +
				1 * 1 * 5 * 1 * 5 * 1 * 1 * 1 * 5 * 1 +
				1 * 1 * 5 * 1 * 5 * 1 * 1 * 1 * 1 * 5 +

				1 * 1 * 5 * 1 * 1 * 5 * 5 * 1 * 1 * 1 +
				1 * 1 * 5 * 1 * 1 * 5 * 1 * 5 * 1 * 1 +
				1 * 1 * 5 * 1 * 1 * 5 * 1 * 1 * 5 * 1 +
				1 * 1 * 5 * 1 * 1 * 5 * 1 * 1 * 1 * 5 +

				1 * 1 * 5 * 1 * 1 * 1 * 5 * 5 * 1 * 1 +
				1 * 1 * 5 * 1 * 1 * 1 * 5 * 1 * 5 * 1 +
				1 * 1 * 5 * 1 * 1 * 1 * 5 * 1 * 1 * 5 +

				1 * 1 * 5 * 1 * 1 * 1 * 1 * 5 * 5 * 1 +
				1 * 1 * 5 * 1 * 1 * 1 * 1 * 5 * 1 * 5 +

				1 * 1 * 5 * 1 * 1 * 1 * 1 * 1 * 5 * 5 +

				//

				1 * 1 * 1 * 5 * 5 * 5 * 1 * 1 * 1 * 1 +
				1 * 1 * 1 * 5 * 5 * 1 * 5 * 1 * 1 * 1 +
				1 * 1 * 1 * 5 * 5 * 1 * 1 * 5 * 1 * 1 +
				1 * 1 * 1 * 5 * 5 * 1 * 1 * 1 * 5 * 1 +
				1 * 1 * 1 * 5 * 5 * 1 * 1 * 1 * 1 * 5 +

				1 * 1 * 1 * 5 * 1 * 5 * 5 * 1 * 1 * 1 +
				1 * 1 * 1 * 5 * 1 * 5 * 1 * 5 * 1 * 1 +
				1 * 1 * 1 * 5 * 1 * 5 * 1 * 1 * 5 * 1 +
				1 * 1 * 1 * 5 * 1 * 5 * 1 * 1 * 1 * 5 +

				1 * 1 * 1 * 5 * 1 * 1 * 5 * 5 * 1 * 1 +
				1 * 1 * 1 * 5 * 1 * 1 * 5 * 1 * 5 * 1 +
				1 * 1 * 1 * 5 * 1 * 1 * 5 * 1 * 1 * 5 +

				1 * 1 * 1 * 5 * 1 * 1 * 1 * 5 * 5 * 1 +
				1 * 1 * 1 * 5 * 1 * 1 * 1 * 5 * 1 * 5 +

				1 * 1 * 1 * 5 * 1 * 1 * 1 * 1 * 5 * 5 +

				//

				1 * 1 * 1 * 1 * 5 * 5 * 5 * 1 * 1 * 1 +
				1 * 1 * 1 * 1 * 5 * 5 * 1 * 5 * 1 * 1 +
				1 * 1 * 1 * 1 * 5 * 5 * 1 * 1 * 5 * 1 +
				1 * 1 * 1 * 1 * 5 * 5 * 1 * 1 * 1 * 5 +

				1 * 1 * 1 * 1 * 5 * 1 * 5 * 5 * 1 * 1 +
				1 * 1 * 1 * 1 * 5 * 1 * 5 * 1 * 5 * 1 +
				1 * 1 * 1 * 1 * 5 * 1 * 5 * 1 * 1 * 5 +

				1 * 1 * 1 * 1 * 5 * 1 * 1 * 5 * 5 * 1 +
				1 * 1 * 1 * 1 * 5 * 1 * 1 * 5 * 1 * 5 +

				1 * 1 * 1 * 1 * 5 * 1 * 1 * 1 * 5 * 5 +

				//

				1 * 1 * 1 * 1 * 1 * 5 * 5 * 5 * 1 * 1 +
				1 * 1 * 1 * 1 * 1 * 5 * 5 * 1 * 5 * 1 +
				1 * 1 * 1 * 1 * 1 * 5 * 5 * 1 * 1 * 5 +

				1 * 1 * 1 * 1 * 1 * 5 * 1 * 5 * 5 * 1 +
				1 * 1 * 1 * 1 * 1 * 5 * 1 * 5 * 1 * 5 +

				1 * 1 * 1 * 1 * 1 * 5 * 1 * 1 * 5 * 5 +

				//

				1 * 1 * 1 * 1 * 1 * 1 * 5 * 5 * 5 * 1 +
				1 * 1 * 1 * 1 * 1 * 1 * 5 * 5 * 1 * 5 +

				1 * 1 * 1 * 1 * 1 * 1 * 5 * 1 * 5 * 5 +

				1 * 1 * 1 * 1 * 1 * 1 * 1 * 5 * 5 * 5) / 60466176.0, odds);
		}

		[Test]
		public void TestTenInfantry3()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(3);
			Assert.AreEqual((
				1 * 1 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 5 +
				1 * 1 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 5 +
				1 * 1 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 5 +
				1 * 1 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 5 +
				1 * 1 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 5 +
				1 * 1 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 5 +
				1 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 5 +
				1 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 5 * 1 +

				1 * 5 * 1 * 1 * 5 * 5 * 5 * 5 * 5 * 5 +
				1 * 5 * 1 * 5 * 1 * 5 * 5 * 5 * 5 * 5 +
				1 * 5 * 1 * 5 * 5 * 1 * 5 * 5 * 5 * 5 +
				1 * 5 * 1 * 5 * 5 * 5 * 1 * 5 * 5 * 5 +
				1 * 5 * 1 * 5 * 5 * 5 * 5 * 1 * 5 * 5 +
				1 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 1 * 5 +
				1 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 1 +

				1 * 5 * 5 * 1 * 1 * 5 * 5 * 5 * 5 * 5 +
				1 * 5 * 5 * 1 * 5 * 1 * 5 * 5 * 5 * 5 +
				1 * 5 * 5 * 1 * 5 * 5 * 1 * 5 * 5 * 5 +
				1 * 5 * 5 * 1 * 5 * 5 * 5 * 1 * 5 * 5 +
				1 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 1 * 5 +
				1 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 1 +

				1 * 5 * 5 * 5 * 1 * 1 * 5 * 5 * 5 * 5 +
				1 * 5 * 5 * 5 * 1 * 5 * 1 * 5 * 5 * 5 +
				1 * 5 * 5 * 5 * 1 * 5 * 5 * 1 * 5 * 5 +
				1 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 1 * 5 +
				1 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 1 +

				1 * 5 * 5 * 5 * 5 * 1 * 1 * 5 * 5 * 5 +
				1 * 5 * 5 * 5 * 5 * 1 * 5 * 1 * 5 * 5 +
				1 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 1 * 5 +
				1 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 1 +

				1 * 5 * 5 * 5 * 5 * 5 * 1 * 1 * 5 * 5 +
				1 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 1 * 5 +
				1 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 1 +

				1 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 1 * 5 +
				1 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 1 +

				1 * 5 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 1 +

				//

				5 * 1 * 1 * 1 * 5 * 5 * 5 * 5 * 5 * 5 +
				5 * 1 * 1 * 5 * 1 * 5 * 5 * 5 * 5 * 5 +
				5 * 1 * 1 * 5 * 5 * 1 * 5 * 5 * 5 * 5 +
				5 * 1 * 1 * 5 * 5 * 5 * 1 * 5 * 5 * 5 +
				5 * 1 * 1 * 5 * 5 * 5 * 5 * 1 * 5 * 5 +
				5 * 1 * 1 * 5 * 5 * 5 * 5 * 5 * 1 * 5 +
				5 * 1 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 1 +

				5 * 1 * 5 * 1 * 1 * 5 * 5 * 5 * 5 * 5 +
				5 * 1 * 5 * 1 * 5 * 1 * 5 * 5 * 5 * 5 +
				5 * 1 * 5 * 1 * 5 * 5 * 1 * 5 * 5 * 5 +
				5 * 1 * 5 * 1 * 5 * 5 * 5 * 1 * 5 * 5 +
				5 * 1 * 5 * 1 * 5 * 5 * 5 * 5 * 1 * 5 +
				5 * 1 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 1 +

				5 * 1 * 5 * 5 * 1 * 1 * 5 * 5 * 5 * 5 +
				5 * 1 * 5 * 5 * 1 * 5 * 1 * 5 * 5 * 5 +
				5 * 1 * 5 * 5 * 1 * 5 * 5 * 1 * 5 * 5 +
				5 * 1 * 5 * 5 * 1 * 5 * 5 * 5 * 1 * 5 +
				5 * 1 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 1 +

				5 * 1 * 5 * 5 * 5 * 1 * 1 * 5 * 5 * 5 +
				5 * 1 * 5 * 5 * 5 * 1 * 5 * 1 * 5 * 5 +
				5 * 1 * 5 * 5 * 5 * 1 * 5 * 5 * 1 * 5 +
				5 * 1 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 1 +

				5 * 1 * 5 * 5 * 5 * 5 * 1 * 1 * 5 * 5 +
				5 * 1 * 5 * 5 * 5 * 5 * 1 * 5 * 1 * 5 +
				5 * 1 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 1 +

				5 * 1 * 5 * 5 * 5 * 5 * 5 * 1 * 1 * 5 +
				5 * 1 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 1 +

				5 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 1 +

				//

				5 * 5 * 1 * 1 * 1 * 5 * 5 * 5 * 5 * 5 +
				5 * 5 * 1 * 1 * 5 * 1 * 5 * 5 * 5 * 5 +
				5 * 5 * 1 * 1 * 5 * 5 * 1 * 5 * 5 * 5 +
				5 * 5 * 1 * 1 * 5 * 5 * 5 * 1 * 5 * 5 +
				5 * 5 * 1 * 1 * 5 * 5 * 5 * 5 * 1 * 5 +
				5 * 5 * 1 * 1 * 5 * 5 * 5 * 5 * 5 * 1 +

				5 * 5 * 1 * 5 * 1 * 1 * 5 * 5 * 5 * 5 +
				5 * 5 * 1 * 5 * 1 * 5 * 1 * 5 * 5 * 5 +
				5 * 5 * 1 * 5 * 1 * 5 * 5 * 1 * 5 * 5 +
				5 * 5 * 1 * 5 * 1 * 5 * 5 * 5 * 1 * 5 +
				5 * 5 * 1 * 5 * 1 * 5 * 5 * 5 * 5 * 1 +

				5 * 5 * 1 * 5 * 5 * 1 * 1 * 5 * 5 * 5 +
				5 * 5 * 1 * 5 * 5 * 1 * 5 * 1 * 5 * 5 +
				5 * 5 * 1 * 5 * 5 * 1 * 5 * 5 * 1 * 5 +
				5 * 5 * 1 * 5 * 5 * 1 * 5 * 5 * 5 * 1 +

				5 * 5 * 1 * 5 * 5 * 5 * 1 * 1 * 5 * 5 +
				5 * 5 * 1 * 5 * 5 * 5 * 1 * 5 * 1 * 5 +
				5 * 5 * 1 * 5 * 5 * 5 * 1 * 5 * 5 * 1 +

				5 * 5 * 1 * 5 * 5 * 5 * 5 * 1 * 1 * 5 +
				5 * 5 * 1 * 5 * 5 * 5 * 5 * 1 * 5 * 1 +

				5 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 1 * 1 +

				//

				5 * 5 * 5 * 1 * 1 * 1 * 5 * 5 * 5 * 5 +
				5 * 5 * 5 * 1 * 1 * 5 * 1 * 5 * 5 * 5 +
				5 * 5 * 5 * 1 * 1 * 5 * 5 * 1 * 5 * 5 +
				5 * 5 * 5 * 1 * 1 * 5 * 5 * 5 * 1 * 5 +
				5 * 5 * 5 * 1 * 1 * 5 * 5 * 5 * 5 * 1 +

				5 * 5 * 5 * 1 * 5 * 1 * 1 * 5 * 5 * 5 +
				5 * 5 * 5 * 1 * 5 * 1 * 5 * 1 * 5 * 5 +
				5 * 5 * 5 * 1 * 5 * 1 * 5 * 5 * 1 * 5 +
				5 * 5 * 5 * 1 * 5 * 1 * 5 * 5 * 5 * 1 +

				5 * 5 * 5 * 1 * 5 * 5 * 1 * 1 * 5 * 5 +
				5 * 5 * 5 * 1 * 5 * 5 * 1 * 5 * 1 * 5 +
				5 * 5 * 5 * 1 * 5 * 5 * 1 * 5 * 5 * 1 +

				5 * 5 * 5 * 1 * 5 * 5 * 5 * 1 * 1 * 5 +
				5 * 5 * 5 * 1 * 5 * 5 * 5 * 1 * 5 * 1 +

				5 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 1 * 1 +

				//

				5 * 5 * 5 * 5 * 1 * 1 * 1 * 5 * 5 * 5 +
				5 * 5 * 5 * 5 * 1 * 1 * 5 * 1 * 5 * 5 +
				5 * 5 * 5 * 5 * 1 * 1 * 5 * 5 * 1 * 5 +
				5 * 5 * 5 * 5 * 1 * 1 * 5 * 5 * 5 * 1 +

				5 * 5 * 5 * 5 * 1 * 5 * 1 * 1 * 5 * 5 +
				5 * 5 * 5 * 5 * 1 * 5 * 1 * 5 * 1 * 5 +
				5 * 5 * 5 * 5 * 1 * 5 * 1 * 5 * 5 * 1 +

				5 * 5 * 5 * 5 * 1 * 5 * 5 * 1 * 1 * 5 +
				5 * 5 * 5 * 5 * 1 * 5 * 5 * 1 * 5 * 1 +

				5 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 1 * 1 +

				//

				5 * 5 * 5 * 5 * 5 * 1 * 1 * 1 * 5 * 5 +
				5 * 5 * 5 * 5 * 5 * 1 * 1 * 5 * 1 * 5 +
				5 * 5 * 5 * 5 * 5 * 1 * 1 * 5 * 5 * 1 +

				5 * 5 * 5 * 5 * 5 * 1 * 5 * 1 * 1 * 5 +
				5 * 5 * 5 * 5 * 5 * 1 * 5 * 1 * 5 * 1 +

				5 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 1 * 1 +

				//

				5 * 5 * 5 * 5 * 5 * 5 * 1 * 1 * 1 * 5 +
				5 * 5 * 5 * 5 * 5 * 5 * 1 * 1 * 5 * 1 +

				5 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 1 * 1 +

				5 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 1 * 1) / 60466176.0, odds);
		}

		[Test]
		public void TestTenInfantry2()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(2);
			Assert.AreEqual((
				1 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 5 * 5 +
				1 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 5 +
				1 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 5 +
				1 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 5 +
				1 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 5 +
				1 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 5 +
				1 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 5 +
				1 * 5 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 5 +
				1 * 5 * 5 * 5 * 5 * 5 * 5 * 5 * 5 * 1 +

				5 * 1 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 5 +
				5 * 1 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 5 +
				5 * 1 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 5 +
				5 * 1 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 5 +
				5 * 1 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 5 +
				5 * 1 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 5 +
				5 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 5 +
				5 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 5 * 1 +

				5 * 5 * 1 * 1 * 5 * 5 * 5 * 5 * 5 * 5 +
				5 * 5 * 1 * 5 * 1 * 5 * 5 * 5 * 5 * 5 +
				5 * 5 * 1 * 5 * 5 * 1 * 5 * 5 * 5 * 5 +
				5 * 5 * 1 * 5 * 5 * 5 * 1 * 5 * 5 * 5 +
				5 * 5 * 1 * 5 * 5 * 5 * 5 * 1 * 5 * 5 +
				5 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 1 * 5 +
				5 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 5 * 1 +

				5 * 5 * 5 * 1 * 1 * 5 * 5 * 5 * 5 * 5 +
				5 * 5 * 5 * 1 * 5 * 1 * 5 * 5 * 5 * 5 +
				5 * 5 * 5 * 1 * 5 * 5 * 1 * 5 * 5 * 5 +
				5 * 5 * 5 * 1 * 5 * 5 * 5 * 1 * 5 * 5 +
				5 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 1 * 5 +
				5 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 5 * 1 +

				5 * 5 * 5 * 5 * 1 * 1 * 5 * 5 * 5 * 5 +
				5 * 5 * 5 * 5 * 1 * 5 * 1 * 5 * 5 * 5 +
				5 * 5 * 5 * 5 * 1 * 5 * 5 * 1 * 5 * 5 +
				5 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 1 * 5 +
				5 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 5 * 1 +

				5 * 5 * 5 * 5 * 5 * 1 * 1 * 5 * 5 * 5 +
				5 * 5 * 5 * 5 * 5 * 1 * 5 * 1 * 5 * 5 +
				5 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 1 * 5 +
				5 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 5 * 1 +

				5 * 5 * 5 * 5 * 5 * 5 * 1 * 1 * 5 * 5 +
				5 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 1 * 5 +
				5 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 5 * 1 +

				5 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 1 * 5 +
				5 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 5 * 1 +

				5 * 5 * 5 * 5 * 5 * 5 * 5 * 5 * 1 * 1) / 60466176.0, odds);
		}

		[Test]
		public void TestTenInfantry1()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual((
				1953125 +
				1953125 +
				1953125 +
				1953125 +
				1953125 +
				1953125 +
				1953125 +
				1953125 +
				1953125 +
				1953125) / 60466176.0, odds);
		}

		[Test]
		public void TestTenInfantry0()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(9765625 / 60466176.0, odds);
		}

		[Test]
		public void TestTenInfantrySum()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(10);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
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
			Assert.AreEqual(1, odds10 + odds9 + odds8 + odds7 + odds6 + odds5 + odds4 + odds3 + odds2 + odds1 + odds0);
		}

		[Test]
		public void TestRussia0()
		{
			List<Unit> attackers = new List<Unit>(11);
			List<Unit> defenders = new List<Unit>(11);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(5 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 / 362797056.0, odds);
		}

		[Test]
		public void TestRussia1()
		{
			List<Unit> attackers = new List<Unit>(11);
			List<Unit> defenders = new List<Unit>(11);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual((
				1 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				5 * 1 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 + 
				5 * 5 * 1 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 2 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				5 * 5 * 5 * 4 * 2 * 4 * 4 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 2 * 4 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 4 * 2 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 4 * 4 * 2 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 2 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				5 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3) / 362797056.0, odds);
		}

		[Test]
		public void TestRussia2()
		{
			List<Unit> attackers = new List<Unit>(11);
			List<Unit> defenders = new List<Unit>(11);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
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
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.AttackerOdds.OddsOf(2);
			Assert.AreEqual((
				1 * 1 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 + 
				1 * 5 * 1 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 + 
				1 * 5 * 5 * 2 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				1 * 5 * 5 * 4 * 2 * 4 * 4 * 4 * 4 * 3 * 3 + 
				1 * 5 * 5 * 4 * 4 * 2 * 4 * 4 * 4 * 3 * 3 + 
				1 * 5 * 5 * 4 * 4 * 4 * 2 * 4 * 4 * 3 * 3 + 
				1 * 5 * 5 * 4 * 4 * 4 * 4 * 2 * 4 * 3 * 3 + 
				1 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 2 * 3 * 3 + 
				1 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				1 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +

				5 * 1 * 1 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 + 
				5 * 1 * 5 * 2 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				5 * 1 * 5 * 4 * 2 * 4 * 4 * 4 * 4 * 3 * 3 + 
				5 * 1 * 5 * 4 * 4 * 2 * 4 * 4 * 4 * 3 * 3 + 
				5 * 1 * 5 * 4 * 4 * 4 * 2 * 4 * 4 * 3 * 3 + 
				5 * 1 * 5 * 4 * 4 * 4 * 4 * 2 * 4 * 3 * 3 + 
				5 * 1 * 5 * 4 * 4 * 4 * 4 * 4 * 2 * 3 * 3 + 
				5 * 1 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				5 * 1 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +

				5 * 5 * 1 * 2 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				5 * 5 * 1 * 4 * 2 * 4 * 4 * 4 * 4 * 3 * 3 + 
				5 * 5 * 1 * 4 * 4 * 2 * 4 * 4 * 4 * 3 * 3 + 
				5 * 5 * 1 * 4 * 4 * 4 * 2 * 4 * 4 * 3 * 3 + 
				5 * 5 * 1 * 4 * 4 * 4 * 4 * 2 * 4 * 3 * 3 + 
				5 * 5 * 1 * 4 * 4 * 4 * 4 * 4 * 2 * 3 * 3 + 
				5 * 5 * 1 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				5 * 5 * 1 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +

				5 * 5 * 5 * 2 * 2 * 4 * 4 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 2 * 4 * 2 * 4 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 2 * 4 * 4 * 2 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 2 * 4 * 4 * 4 * 2 * 4 * 3 * 3 + 
				5 * 5 * 5 * 2 * 4 * 4 * 4 * 4 * 2 * 3 * 3 + 
				5 * 5 * 5 * 2 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +
				5 * 5 * 5 * 2 * 4 * 4 * 4 * 4 * 4 * 3 * 3 +

				5 * 5 * 5 * 4 * 2 * 2 * 4 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 2 * 4 * 2 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 2 * 4 * 4 * 2 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 2 * 4 * 4 * 4 * 2 * 3 * 3 + 
				5 * 5 * 5 * 4 * 2 * 4 * 4 * 4 * 4 * 3 * 3 +
				5 * 5 * 5 * 4 * 2 * 4 * 4 * 4 * 4 * 3 * 3 +

				5 * 5 * 5 * 4 * 4 * 2 * 2 * 4 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 2 * 4 * 2 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 2 * 4 * 4 * 2 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 2 * 4 * 4 * 4 * 3 * 3 +
				5 * 5 * 5 * 4 * 4 * 2 * 4 * 4 * 4 * 3 * 3 +

				5 * 5 * 5 * 4 * 4 * 4 * 2 * 2 * 4 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 4 * 2 * 4 * 2 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 4 * 2 * 4 * 4 * 3 * 3 +
				5 * 5 * 5 * 4 * 4 * 4 * 2 * 4 * 4 * 3 * 3 +

				5 * 5 * 5 * 4 * 4 * 4 * 4 * 2 * 2 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 4 * 4 * 2 * 4 * 3 * 3 +
				5 * 5 * 5 * 4 * 4 * 4 * 4 * 2 * 4 * 3 * 3 +

				5 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 2 * 3 * 3 + 
				5 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 2 * 3 * 3 +

				5 * 5 * 5 * 4 * 4 * 4 * 4 * 4 * 4 * 3 * 3) / 362797056.0, odds);
		}

		[Test]
		public void TestHeterogenousArmy0()
		{
			List<Unit> attackers = new List<Unit>(5);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Artillery());
			attackers.Add(new Tank());
			attackers.Add(new Fighter());
			attackers.Add(new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var attackerOdds = battle.AttackerOdds.OddsOf(0);
			Assert.AreEqual(4 * 4 * 3 * 3 * 2 / 7776.0, attackerOdds);
		}

		[Test]
		public void TestHeterogenousArmy1()
		{
			List<Unit> attackers = new List<Unit>(5);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Artillery());
			attackers.Add(new Tank());
			attackers.Add(new Fighter());
			attackers.Add(new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var attackerOdds = battle.AttackerOdds.OddsOf(1);
			Assert.AreEqual((
				2 * 4 * 3 * 3 * 2 +
				4 * 2 * 3 * 3 * 2 +
				4 * 4 * 3 * 3 * 2 +
				4 * 4 * 3 * 3 * 2 +
				4 * 4 * 3 * 3 * 4) / 7776.0, attackerOdds);
		}

		[Test]
		public void TestAmphibiousAssault0()
		{
			List<Unit> attackers = new List<Unit>(5);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Artillery());
			attackers.Add(new Tank());
			attackers.Add(new Fighter());
			attackers.Add(new Bomber());
			bombarders.Add(new Cruiser());
			bombarders.Add(new Battleship());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var attackerOdds = battle.AttackerOdds.OddsOf(0);
			var bombarderOdds = battle.BombarderOdds.OddsOf(0);
			Assert.AreEqual(4 * 4 * 3 * 3 * 2 / 7776.0, attackerOdds);
			Assert.AreEqual(3 * 4 / 36.0, bombarderOdds);
		}

		[Test]
		public void TestAntiAircraft0()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(5);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(5);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Fighter());
			attackers.Add(new Fighter());
			attackers.Add(new Fighter());
			attackers.Add(new Fighter());
			attackers.Add(new Fighter());			
			defenders.Add(new Infantry());
			defenders.Add(new Infantry());
			defenders.Add(new Infantry());
			defenders.Add(new Infantry());
			defenders.Add(new Infantry());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var attackerOdds = battle.AttackerOdds.OddsOf(0);
			var defenderOdds = battle.DefenderOdds.OddsOf(0);
			var antiAircraftOdds = battle.AntiAircraftOdds.OddsOf(0);
			Assert.AreEqual(5 * 5 * 5 * 5 * 5 * 3 * 3 * 3 * 3 * 3 / 60466176.0, attackerOdds);
			Assert.AreEqual(4 * 4 * 4 * 4 * 4 / 7776.0, defenderOdds);
			Assert.AreEqual(30517578125 / 470184984576.0, antiAircraftOdds);
		}

		[Test]
		public void TestAntiAircraftSum()
		{
			List<Unit> attackers = new List<Unit>(10);
			List<Unit> defenders = new List<Unit>(5);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(5);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Infantry());
			attackers.Add(new Fighter());
			attackers.Add(new Fighter());
			attackers.Add(new Fighter());
			attackers.Add(new Fighter());
			attackers.Add(new Fighter());			
			defenders.Add(new Infantry());
			defenders.Add(new Infantry());
			defenders.Add(new Infantry());
			defenders.Add(new Infantry());
			defenders.Add(new Infantry());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			antiAircraftArtillery.Add(new AntiAircraftArtillery());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds15 = battle.AttackerOdds.OddsOf(15);
			var odds14 = battle.AttackerOdds.OddsOf(14);
			var odds13 = battle.AttackerOdds.OddsOf(13);
			var odds12 = battle.AttackerOdds.OddsOf(12);
			var odds11 = battle.AttackerOdds.OddsOf(11);
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
			Assert.AreEqual(1, odds15 + odds14 + odds13 + odds12 + odds11 + odds10 + odds9 + odds8 + odds7 + odds6 + odds5 + odds4 + odds3 + odds2 + odds1 + odds0);
		}
			
		[Test]
		public void TestRaiderOdds1Raider0Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.RaiderOdds.OddsOf(0);
			Assert.AreEqual(5 / 6.0, odds);
		}

		[Test]
		public void TestRaiderOdds1Raider1Hit(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.RaiderOdds.OddsOf(1);
			Assert.AreEqual(1 / 6.0, odds);
		}

		[Test]
		public void TestRaiderOdds2Raiders0Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Fighter());
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.RaiderOdds.OddsOf(0);
			Assert.AreEqual(25 / 36.0, odds);
		}

		[Test]
		public void TestRaiderOdds2Raiders1Hit(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Fighter());
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.RaiderOdds.OddsOf(1);
			Assert.AreEqual(10 / 36.0, odds);
		}

		[Test]
		public void TestRaiderOdds2Raiders2Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Fighter());
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.RaiderOdds.OddsOf(2);
			Assert.AreEqual(1 / 36.0, odds);
		}

		[Test]
		public void TestInterceptorOdds1Interceptor0Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.InterceptorOdds.OddsOf(0);
			Assert.AreEqual(4 / 6.0, odds);
		}

		[Test]
		public void TestInterceptorOdds1Interceptor1Hit(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.InterceptorOdds.OddsOf(1);
			Assert.AreEqual(2 / 6.0, odds);
		}

		[Test]
		public void TestInterceptorOdds2Interceptors0Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(2);
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.InterceptorOdds.OddsOf(0);
			Assert.AreEqual(16 / 36.0, odds);
		}

		[Test]
		public void TestInterceptorOdds2Interceptors1Hit(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(2);
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.InterceptorOdds.OddsOf(1);
			Assert.AreEqual(16 / 36.0, odds);
		}

		[Test]
		public void TestInterceptorOdds2Interceptors2Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(2);
			raiders.Add (new Bomber());
			interceptors.Add (new Fighter());
			interceptors.Add (new Fighter());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.InterceptorOdds.OddsOf(2);
			Assert.AreEqual(4 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds1Bomber1Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(1);
			Assert.AreEqual(1 / 6.0, odds);
		}

		[Test]
		public void TestStrategicOdds1Bomber2Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(2);
			Assert.AreEqual(1 / 6.0, odds);
		}

		[Test]
		public void TestStrategicOdds1Bomber3Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(3);
			Assert.AreEqual(1 / 6.0, odds);
		}

		[Test]
		public void TestStrategicOdds1Bomber4Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(4);
			Assert.AreEqual(1 / 6.0, odds);
		}

		[Test]
		public void TestStrategicOdds1Bomber5Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(5);
			Assert.AreEqual(1 / 6.0, odds);
		}

		[Test]
		public void TestStrategicOdds1Bomber6Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(6);
			Assert.AreEqual(1 / 6.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers2Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(2);
			Assert.AreEqual(1 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers3Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(3);
			Assert.AreEqual(2 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers4Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(4);
			Assert.AreEqual(3 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers5Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(5);
			Assert.AreEqual(4 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers6Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(6);
			Assert.AreEqual(5 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers7Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(7);
			Assert.AreEqual(6 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers8Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(8);
			Assert.AreEqual(5 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers9Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(9);
			Assert.AreEqual(4 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers10Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(10);
			Assert.AreEqual(3 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers11Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(11);
			Assert.AreEqual(2 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds2Bombers12Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(12);
			Assert.AreEqual(1 / 36.0, odds);
		}

		[Test]
		public void TestStrategicOdds3Bombers3Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(3);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(3);
			Assert.AreEqual(1 / 216.0, odds);
		}

		[Test]
		public void TestStrategicOdds3Bombers4Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(3);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(4);
			Assert.AreEqual(3 / 216.0, odds);
		}

		[Test]
		public void TestStrategicOdds3Bombers5Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(3);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(5);
			Assert.AreEqual(6 / 216.0, odds);
		}

		[Test]
		public void TestStrategicOdds3Bombers6Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(3);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(6);
			Assert.AreEqual(10 / 216.0, odds);
		}

		[Test]
		public void TestStrategicOdds3Bombers7Damage(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(3);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.StrategicOdds.OddsOf(7);
			Assert.AreEqual(15 / 216.0, odds);
		}

		[Test]
		public void TestIndustrialComplexOdds1Bomber0Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.IndustrialComplexOdds.OddsOf(0);
			Assert.AreEqual(5 / 6.0, odds);
		}

		[Test]
		public void TestIndustrialComplexOdds1Bomber1Hit(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(1);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.IndustrialComplexOdds.OddsOf(1);
			Assert.AreEqual(1 / 6.0, odds);
		}

		[Test]
		public void TestIndustrialComplexOdds2Bombers0Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.IndustrialComplexOdds.OddsOf(0);
			Assert.AreEqual(25 / 36.0, odds);
		}

		[Test]
		public void TestIndustrialComplexOdds2Bombers1Hit(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.IndustrialComplexOdds.OddsOf(1);
			Assert.AreEqual(10 / 36.0, odds);
		}

		[Test]
		public void TestIndustrialComplexOdds2Bombers2Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(2);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.IndustrialComplexOdds.OddsOf(2);
			Assert.AreEqual(1 / 36.0, odds);
		}

		[Test]
		public void TestIndustrialComplexOdds3Bombers0Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(3);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.IndustrialComplexOdds.OddsOf(0);
			Assert.AreEqual(125 / 216.0, odds);
		}

		[Test]
		public void TestIndustrialComplexOdds3Bombers1Hit(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(3);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.IndustrialComplexOdds.OddsOf(1);
			Assert.AreEqual(75 / 216.0, odds);
		}

		[Test]
		public void TestIndustrialComplexOdds3Bombers2Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(3);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.IndustrialComplexOdds.OddsOf(2);
			Assert.AreEqual(15 / 216.0, odds);
		}

		[Test]
		public void TestIndustrialComplexOdds3Bombers3Hits(){
			List<Unit> attackers = new List<Unit>(1);
			List<Unit> defenders = new List<Unit>(1);
			List<Unit> bombarders = new List<Unit>(1);
			List<AntiAircraftArtillery> antiAircraftArtillery = new List<AntiAircraftArtillery>(1);
			List<Unit> raiders = new List<Unit>(3);
			List<Unit> interceptors = new List<Unit>(1);
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			raiders.Add (new Bomber());
			var battle = new Battle(attackers, defenders, bombarders, antiAircraftArtillery, raiders, interceptors);
			var odds = battle.IndustrialComplexOdds.OddsOf(3);
			Assert.AreEqual(1 / 216.0, odds);
		}
	}
}
