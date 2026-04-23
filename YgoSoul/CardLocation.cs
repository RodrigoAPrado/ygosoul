namespace YgoSoul;

public enum CardLocation: uint
{
    Unknown = 0x0,
    Deck = 0x1,
    Hand = 0x2,
    MonsterZone = 0x4,
    SpellTrapZone = 0x8,
    Grave = 0x10,
    Banishment = 0x20,
    Extra = 0x40,
    Overlay = 0x80
}


/*
 *
 *
 *
    public const ulong LOCATION_DECK = 0x01;
    public const ulong LOCATION_HAND = 0x02;
    public const ulong LOCATION_MZONE = 0x04;
    public const ulong LOCATION_SZONE = 0x08;
    public const ulong LOCATION_GRAVE = 0x10;
#define LOCATION_REMOVED 0x20
#define LOCATION_EXTRA 0x40
#define LOCATION_OVERLAY 0x80
 * 
 */