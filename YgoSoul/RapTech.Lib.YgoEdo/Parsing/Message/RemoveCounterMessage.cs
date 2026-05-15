using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class RemoveCounterMessage : BaseMessage
{
    public OCG_CounterType CounterType { get; }
    public byte Player { get; }
    public OCG_CardLocation Location { get; }
    public byte Sequence { get; }
    public ushort Count { get; }

    public RemoveCounterMessage(OCG_CounterType counterType, byte player, OCG_CardLocation location, byte sequence, ushort count)
    {
        CounterType = counterType;
        Player = player;
        Location = location;
        Sequence = sequence;
        Count = count;
    }

    public override string ToString()
    {
        return $"RemoveCounter, CounterType={(OCG_CounterType)CounterType}, Player={Player}, Location={Location} Sequence={Sequence}, Count={Count}";
    }
}