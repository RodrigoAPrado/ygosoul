namespace YgoSoul.DuelRunner;

public static class OcgConstants
{
    // Valores base extraídos do seu .h
    public const ulong DUEL_1ST_TURN_DRAW = 0x200;
    public const ulong DUEL_1_FACEUP_FIELD = 0x400;
    public const ulong DUEL_PZONE = 0x800;
    public const ulong DUEL_EMZONE = 0x2000;
    public const ulong DUEL_FSX_MMZONE = 0x4000;
    public const ulong DUEL_TRAP_MONSTERS_NOT_USE_ZONE = 0x8000;
    public const ulong DUEL_SPSUMMON_ONCE_OLD_NEGATE = 0x40000;
    public const ulong DUEL_RETURN_TO_DECK_TRIGGERS = 0x10000;
    public const ulong DUEL_TRIGGER_ONLY_IN_LOCATION = 0x20000;
    public const ulong DUEL_CANNOT_SUMMON_OATH_OLD = 0x80000;

    // A nossa Master Rule 2 (Wind-Up Era)
    public const ulong DUEL_MODE_MR2 = (DUEL_1ST_TURN_DRAW 
                                       | DUEL_1_FACEUP_FIELD 
                                       | DUEL_SPSUMMON_ONCE_OLD_NEGATE 
                                       | DUEL_RETURN_TO_DECK_TRIGGERS 
                                       | DUEL_CANNOT_SUMMON_OATH_OLD);

    public const ulong DUEL_MODE_MR5 = (DUEL_PZONE | DUEL_EMZONE | DUEL_FSX_MMZONE | DUEL_TRAP_MONSTERS_NOT_USE_ZONE |
                                        DUEL_TRIGGER_ONLY_IN_LOCATION);
}