using YgoSoul.RapTech.Lib.YgoEdo.CardInfo.Interface;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class AddCounterMessage : BaseMessage, IAddCounterMessage
{
    public CounterType CounterType => _internalCounterType.ToCardCounterType();
    public byte Player { get; }
    public Location Location => _internalLocation.ToLocation();
    public byte Sequence { get; }
    public ushort Count { get; }
    private readonly OCG_CounterType _internalCounterType;
    private readonly OCG_CardLocation _internalLocation;

    public AddCounterMessage(OCG_CounterType counterType, byte player, OCG_CardLocation location, byte sequence, ushort count)
    {
        _internalCounterType = counterType;
        Player = player;
        _internalLocation = location;
        Sequence = sequence;
        Count = count;
    }

    public override string ToString()
    {
        return $"[(AddCounter) CounterType={_internalCounterType}, Player={Player}, Location={_internalLocation} Sequence={Sequence}, Count={Count}]";
    }
}