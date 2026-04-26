using YgoSoul.Flag;

namespace YgoSoul.Util;

public class ZoneUtils
{
    public static readonly Dictionary<Zone, CardLocation> ZoneLocation = new()
    {
        { Zone.Monster0, CardLocation.MonsterZone },
        { Zone.Monster1, CardLocation.MonsterZone },
        { Zone.Monster2, CardLocation.MonsterZone },
        { Zone.Monster3, CardLocation.MonsterZone },
        { Zone.Monster4, CardLocation.MonsterZone },
        { Zone.ExtraMonsterZone0, CardLocation.MonsterZone },
        { Zone.ExtraMonsterZone1, CardLocation.MonsterZone },
        { Zone.SpellTrap0, CardLocation.SpellTrapZone },
        { Zone.SpellTrap1, CardLocation.SpellTrapZone },
        { Zone.SpellTrap2, CardLocation.SpellTrapZone },
        { Zone.SpellTrap3, CardLocation.SpellTrapZone },
        { Zone.SpellTrap4, CardLocation.SpellTrapZone }
    };

    public static readonly Dictionary<Zone, uint> ZoneIndex = new()
    {
        { Zone.Monster0, 0 },
        { Zone.Monster1, 1 },
        { Zone.Monster2, 2 },
        { Zone.Monster3, 3 },
        { Zone.Monster4, 4 },
        { Zone.ExtraMonsterZone0, 5 },
        { Zone.ExtraMonsterZone1, 6 },
        { Zone.SpellTrap0, 0 },
        { Zone.SpellTrap1, 1 },
        { Zone.SpellTrap2, 2 },
        { Zone.SpellTrap3, 3 },
        { Zone.SpellTrap4, 4 }
    };
}