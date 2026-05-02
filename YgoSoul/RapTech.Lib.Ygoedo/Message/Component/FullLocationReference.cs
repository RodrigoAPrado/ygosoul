using YgoSoul.RapTech.Lib.Ygoedo.Flag;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

public class FullLocationReference
{
    public byte Player { get; }
    public CardLocation Location { get; }
    public uint Sequence { get; }
    public CardPosition Position { get; }

    public FullLocationReference(byte player, CardLocation location, uint sequence, CardPosition position)
    {
        Player = player;
        Location = location;
        Sequence = sequence;
        Position = position;
    }

    public bool IsLocationEmpty()
    {
        return Location == CardLocation.Unknown;
    }

    public override string ToString()
    {
        return $"Playe={Player}, Location={Location}, Sequence={Sequence}, Position={Position}";
    }
}