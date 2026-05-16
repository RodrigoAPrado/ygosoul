using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class FieldDisabledMessage : BaseMessage, IFieldDisabledMessage
{
    public IReadOnlyList<FieldZones> Zones => _zones.Select(x => x.ToFieldZone()).ToList().AsReadOnly();
    private readonly List<OCG_Zone> _zones;
    private readonly uint _mask;

    public FieldDisabledMessage(List<OCG_Zone> zones, uint mask)
    {
        _zones = zones;
        _mask = mask;
    }

    public override string ToString()
    {
        return $"FieldDisabled={_mask:x8}";
    }
}