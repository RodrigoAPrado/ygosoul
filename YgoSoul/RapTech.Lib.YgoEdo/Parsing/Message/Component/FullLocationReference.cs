using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

public class FullLocationReference
{
    public byte Controller { get; }
    public OCG_CardLocation Location { get; }
    public uint Sequence { get; }
    public OCG_CardPosition Position { get; }

    public FullLocationReference(byte controller, OCG_CardLocation location, uint sequence, OCG_CardPosition position)
    {
        Controller = controller;
        Location = location;
        Sequence = sequence;
        Position = position;
    }

    public bool IsLocationEmpty()
    {
        return Location == OCG_CardLocation.Unknown;
    }

    public override string ToString()
    {
        return $"Player={Controller}, Location={Location}, Sequence={Sequence}, Position={Position}";
    }
}