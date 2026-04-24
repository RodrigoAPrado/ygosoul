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
        { Zone.Monster4, CardLocation.MonsterZone }
    };

    public static readonly Dictionary<Zone, uint> ZoneIndex = new()
    {
        { Zone.Monster0, 0 },
        { Zone.Monster1, 1 },
        { Zone.Monster2, 2 },
        { Zone.Monster3, 3 },
        { Zone.Monster4, 4 }
    };
}