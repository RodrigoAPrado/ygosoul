using YgoSoul.Flag;

namespace YgoSoul.Message.Component;

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
        return IsLocationEmpty() ? $"Player {Player} directly." : $"Player {Player} at {Location}, sequence {Sequence}, position {Position}.";
    }
}