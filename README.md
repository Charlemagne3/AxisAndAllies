# AxisAndAllies

This app calculates the odds of rolling a certain number of hits in battles in the Axis and Allies board games.

The app was originally a Unity App, but has been converted into a Golang REST API as of commit 40. This will be tagged as a release once all of the old functionality is ported. For now, land and sea battles work correctly, but strategic raids (air battles) have not yet been converted from the old Unity implementation. For now, they simply behave like the other battle types.

Unity Release:

https://github.com/Charlemagne3/AxisAndAllies/tree/v0.0.1

## Setup

Install [Golang][Golang-Installation]

## Development

+ `make setup` will populate the `.env` file
+ `make deps` will download dependencies
+ `make test` will run unit tests
+ `make clean` will erase temporary files from builds
+ `make build` will compile the application for execution
+ `make run` will build and then execute the application

## Architecture

The app runs locally on port 8080.

### POST `/api/v0/battle/land`

Calculates the odds (out of 1) of rolling each possible number of hits.
There must be at least 1 attacking unit and 1 defending unit.

#### Payload:

```JSON
{
    "AttackingInfantry": 1,
    "AttackingArtillery": 0,
    "AttackingMechanizedInfantry": 0,
    "AttackingTanks": 0,
    "AttackingFighters": 0,
    "AttackingTacticalBombers": 0,
    "AttackingStrategicBombers": 0,
    "DefendingInfantry": 1,
    "DefendingArtillery": 0,
    "DefendingMechanizedInfantry": 0,
    "DefendingTanks": 0,
    "DefendingFighters": 0,
    "DefendingTacticalBombers": 0,
    "DefendingStrategicBombers": 0
}
```

#### Response:

```JSON
{
    "AttackerHits": {
        "0": 0.8333333333333334,
        "1": 0.16666666666666666
    },
    "DefenderHits": {
        "0": 0.6666666666666666,
        "1": 0.3333333333333333
    }
}
```

### POST `/api/v0/battle/sea`

Calculates the odds (out of 1) of rolling each possible number of hits.
There must be at least 1 attacking unit and 1 defending unit.

#### Payload:

```JSON
{
    "AttackingSubmarines": 1,
    "AttackingDestroyers": 0,
    "AttackingCrusiers": 0,
    "AttackingBattleships": 0,
    "AttackingAircraftCarriers": 0,
    "AttackingFighters": 0,
    "AttackingTacticalBombers": 0,
    "AttackingStrategicBombers": 0,
    "DefendingSubmarines": 1,
    "DefendingDestroyers": 0,
    "DefendingCrusiers": 0,
    "DefendingBattleships": 0,
    "DefendingAircraftCarriers": 0,
    "DefendingFighters": 0,
    "DefendingTacticalBombers": 0,
    "DefendingStrategicBombers": 0
}
```

#### Response:

```JSON
{
    "AttackerHits": {
        "0": 0.6666666666666666,
        "1": 0.3333333333333333
    },
    "DefenderHits": {
        "0": 0.8333333333333334,
        "1": 0.16666666666666666
    }
}
```

### POST `/api/v0/battle/air`

Calculates the odds (out of 1) of rolling each possible number of hits.
There must be at least 1 attacking unit and 1 defending unit.

#### Payload:

```JSON
{
    "AttackingFighters": 1,
    "AttackingTacticalBombers": 0,
    "AttackingStrategicBombers": 0,
    "DefendingFighters": 1,
    "DefendingTacticalBombers": 0,
    "DefendingStrategicBombers": 0
}
```

#### Response:

```JSON
{
    "AttackerHits": {
        "0": 0.5,
        "1": 0.5
    },
    "DefenderHits": {
        "0": 0.3333333333333333,
        "1": 0.6666666666666666
    }
}
```

[Golang-Installation]: https://golang.org/doc/install
[DotEnv]: https://github.com/joho/godotenv
