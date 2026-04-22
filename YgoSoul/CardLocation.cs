namespace YgoSoul;

public enum CardLocation
{
    Deck = 1,
    Hand = 2,
    MonsterZone = 4,
    SpellTrapZone = 8,
    Grave = 10,
    Banishment = 20,
    Extra = 40,
    Overlay = 80
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