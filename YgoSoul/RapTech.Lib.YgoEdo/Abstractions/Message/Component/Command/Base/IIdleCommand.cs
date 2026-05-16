namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;

public interface IIdleCommand
{
    uint Index { get; }
}


/*
 *
 *
    NormalSummon = 0,
    SpecialSummon = 1,
    ChangeCardPosition = 2,
    Set = 3,
    SpellOrTrapSet = 4,
    EffectActivation = 5,
    GoToBattlePhase = 6,
    GotoEndPhase = 7,
    ShuffleHand = 8,
 *
 *

 */