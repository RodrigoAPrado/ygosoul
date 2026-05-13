using YgoSoul.RapTech.Lib.Ygoedo.Flag;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

public class FullLocationReference
{
    public byte Controller { get; }
    public CardLocation Location { get; }
    public uint Sequence { get; }
    public CardPosition Position { get; }

    public FullLocationReference(byte controller, CardLocation location, uint sequence, CardPosition position)
    {
        Controller = controller;
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
        return $"Player={Controller}, Location={Location}, Sequence={Sequence}, Position={Position}";
    }
}