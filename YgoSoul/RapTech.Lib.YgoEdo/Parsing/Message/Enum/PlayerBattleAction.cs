namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

[Flags]
public enum PlayerBattleAction : uint
{
    ActivateEffect = 0,
    Attack = 1,
    GoToMainPhase2 = 2,
    GoToEndPhase = 3,
}