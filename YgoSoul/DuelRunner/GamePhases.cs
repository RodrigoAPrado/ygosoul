namespace YgoSoul.DuelRunner;

public enum GamePhases
{
    DrawPhase = 1,
    StandbyPhase = 2,
    MainPhase1 = 4,
    BattlePhase = 8,
    BattleStep = 10,
    DamageStep = 20,
    DamageCalculation = 40,
    BattleResult = 80,
    MainPhase2 = 100,
    EndPhase = 200
}