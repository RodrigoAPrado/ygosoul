using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public class ChainOption
{
    public uint Code { get; set; }
    public byte Controller { get; set; }
    public OCG_CardLocation Location { get; set; }
    public uint Sequence { get; set; }
    public OCG_CardPosition Position { get; set; }
    public ulong Description { get; set; }

    public override string ToString()
    {
        return $"Card={CardLibrary.InternalGetCard(Code).Name}, Ctrl={Controller}, Loc={Location}, Seq={Sequence}, SubSeq={Position}. " +
               $"\nDesc={DescriptionHandler.GetDescription(Description)}";
    }
}