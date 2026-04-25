namespace YgoSoul.Flag;

[Flags]
public enum PlayerBattleAction : uint
{
    ActivateEffect = 0,
    Attack = 1,
    GoToMainPhase2 = 2,
    GoToEndPhase = 3,
}