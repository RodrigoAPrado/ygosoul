using YgoSoul.Flag;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

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
        return $"AddCounter, CounterType={CounterType}, Player={Player}, Location={Location} Sequence={Sequence}, Count={Count}";
    }
}