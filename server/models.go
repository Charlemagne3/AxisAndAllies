package main

type LandBattle struct {
	AttackingInfantry           int
	AttackingArtillery          int
	AttackingMechanizedInfantry int
	AttackingTanks              int
	AttackingFighters           int
	AttackingTacticalBombers    int
	AttackingStrategicBombers   int
	DefendingInfantry           int
	DefendingArtillery          int
	DefendingMechanizedInfantry int
	DefendingTanks              int
	DefendingFighters           int
	DefendingTacticalBombers    int
	DefendingStrategicBombers   int
}

type SeaBattle struct {
	AttackingSubmarines       int
	AttackingDestroyers       int
	AttackingCrusiers         int
	AttackingBattleships      int
	AttackingAircraftCarriers int
	AttackingFighters         int
	AttackingTacticalBombers  int
	AttackingStrategicBombers int
	DefendingSubmarines       int
	DefendingDestroyers       int
	DefendingCrusiers         int
	DefendingBattleships      int
	DefendingAircraftCarriers int
	DefendingFighters         int
	DefendingTacticalBombers  int
	DefendingStrategicBombers int
}

type AirBattle struct {
	AttackingFighters         int
	AttackingTacticalBombers  int
	AttackingStrategicBombers int
	DefendingFighters         int
	DefendingTacticalBombers  int
	DefendingStrategicBombers int
}

type Unit struct {
	Attack  int
	Defense int
	Move    int
	Cost    int
}
