namespace YgoSoul;

public static class OcgConstants
{
    // Valores base extraídos do seu .h
    public const ulong DUEL_1ST_TURN_DRAW = 0x200;
    public const ulong DUEL_1_FACEUP_FIELD = 0x400;
    public const ulong DUEL_SPSUMMON_ONCE_OLD_NEGATE = 0x40000;
    public const ulong DUEL_RETURN_TO_DECK_TRIGGERS = 0x10000;
    public const ulong DUEL_CANNOT_SUMMON_OATH_OLD = 0x80000;

    // A nossa Master Rule 2 (Wind-Up Era)
    public const ulong DUEL_MODE_MR2 = DUEL_1ST_TURN_DRAW 
                                       | DUEL_1_FACEUP_FIELD 
                                       | DUEL_SPSUMMON_ONCE_OLD_NEGATE 
                                       | DUEL_RETURN_TO_DECK_TRIGGERS 
                                       | DUEL_CANNOT_SUMMON_OATH_OLD;
}