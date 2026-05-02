using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class AddCounterMessage : BaseMessage
{
    public ushort CounterType { get; }
    public byte Player { get; }
    public CardLocation Location { get; }
    public byte Sequence { get; }
    public ushort Count { get; }

    public AddCounterMessage(ushort counterType, byte player, CardLocation location, byte sequence, ushort count)
    {
        CounterType = counterType;
        Player = player;
        Location = location;
        Sequence = sequence;
        Count = count;
    }

    public override string ToString()
    {
        return $"AddCounter, CounterType={(CounterType)CounterType}, Player={Player}, Location={Location} Sequence={Sequence}, Count={Count}";
    }
}