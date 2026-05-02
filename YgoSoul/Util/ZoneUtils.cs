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
        { Zone.SpellTrap4, CardLocation.SpellTrapZone },
        { Zone.FieldZone, CardLocation.SpellTrapZone },
        { Zone.Pendulum0, CardLocation.SpellTrapZone },
        { Zone.Pendulum1, CardLocation.SpellTrapZone },
        { Zone.OpponentMonster0, CardLocation.MonsterZone },
        { Zone.OpponentMonster1, CardLocation.MonsterZone },
        { Zone.OpponentMonster2, CardLocation.MonsterZone },
        { Zone.OpponentMonster3, CardLocation.MonsterZone },
        { Zone.OpponentMonster4, CardLocation.MonsterZone },
        { Zone.OpponentExtraMonsterZone0, CardLocation.MonsterZone },
        { Zone.OpponentExtraMonsterZone1, CardLocation.MonsterZone },
        { Zone.OpponentSpellTrap0, CardLocation.SpellTrapZone },
        { Zone.OpponentSpellTrap1, CardLocation.SpellTrapZone },
        { Zone.OpponentSpellTrap2, CardLocation.SpellTrapZone },
        { Zone.OpponentSpellTrap3, CardLocation.SpellTrapZone },
        { Zone.OpponentSpellTrap4, CardLocation.SpellTrapZone },
        { Zone.OpponentFieldZone, CardLocation.SpellTrapZone },
        { Zone.OpponentPendulum0, CardLocation.SpellTrapZone },
        { Zone.OpponentPendulum1, CardLocation.SpellTrapZone },
    };

    public static readonly Dictionary<Zone, uint> ZoneIndexInput = new()
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
        { Zone.SpellTrap4, 4 },
        { Zone.FieldZone, 5 },
        { Zone.Pendulum0, 6 },
        { Zone.Pendulum1, 7 },
        { Zone.OpponentMonster0, 0 },
        { Zone.OpponentMonster1, 1 },
        { Zone.OpponentMonster2, 2 },
        { Zone.OpponentMonster3, 3 },
        { Zone.OpponentMonster4, 4 },
        { Zone.OpponentExtraMonsterZone0, 5 },
        { Zone.OpponentExtraMonsterZone1, 6 },
        { Zone.OpponentSpellTrap0, 0 },
        { Zone.OpponentSpellTrap1, 1 },
        { Zone.OpponentSpellTrap2, 2 },
        { Zone.OpponentSpellTrap3, 3 },
        { Zone.OpponentSpellTrap4, 4 },
        { Zone.OpponentFieldZone, 5 },
        { Zone.OpponentPendulum0, 6 },
        { Zone.OpponentPendulum1, 7 },
    };
    
    public static readonly List<Zone> ZoneIndexQuery =
    [
        Zone.Monster0,
        Zone.Monster1,
        Zone.Monster2,
        Zone.Monster3,
        Zone.Monster4,
        Zone.ExtraMonsterZone0,
        Zone.ExtraMonsterZone1,
        Zone.SpellTrap0,
        Zone.SpellTrap1,
        Zone.SpellTrap2,
        Zone.SpellTrap3,
        Zone.SpellTrap4,
        Zone.FieldZone,
        Zone.Pendulum0,
        Zone.Pendulum1
    ];
}