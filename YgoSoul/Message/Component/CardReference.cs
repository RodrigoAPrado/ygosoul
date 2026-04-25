using YgoSoul.Flag;

namespace YgoSoul.Message.Component;

public class CardReference
{
    public uint CardCode { get; }
    public byte Controller { get; }
    public CardLocation Location { get; }
    public uint Sequence { get; }
    public CardPosition Position { get; }
    public uint Index { get; }

    public CardReference(
        uint cardCode,
        byte controller,
        CardLocation location,
        uint sequence,
        CardPosition position,
        uint index)
    {
        CardCode = cardCode;
        Controller = controller;
        Location = location;
        Sequence = sequence;
        Position = position;
        Index = index;
    }

    public override string ToString()
    {
        return $"{CardLibrary.GetCard(CardCode).Name}, in location {Location}, sequence {Sequence}, position {Position}, index {Index}";
    }
}