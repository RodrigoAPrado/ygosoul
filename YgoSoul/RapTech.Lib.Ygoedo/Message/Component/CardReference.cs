using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

public class CardReference
{
    public uint CardCode { get; }
    public FullLocationReference LocationReference { get; }
    public uint Index { get; }
    public byte ReleaseValue { get; set; }
    public ushort CounterAmount { get; set; }
    public ulong Sum { get; set; }

    public CardReference(
        uint cardCode,
        FullLocationReference locationReference,
        uint index)
    {
        CardCode = cardCode;
        LocationReference = locationReference;
        Index = index;
    }

    public override string ToString()
    {
        return $"{CardLibrary.InternalGetCard(CardCode).Name}, " +
               $"Location={LocationReference.Location}, " +
               $"Sequence={LocationReference.Sequence}, " +
               $"Position={LocationReference.Position}, " +
               $"Index={Index}";
    }
}