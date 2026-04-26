using YgoSoul.Flag;
using YgoSoul.Handler;

namespace YgoSoul.Message.Component;

public class ChainOption
{
    public uint Code { get; set; }
    public byte Controller { get; set; }
    public CardLocation Location { get; set; }
    public uint Sequence { get; set; }
    public CardPosition Position { get; set; }
    public ulong Description { get; set; }

    public override string ToString()
    {
        return $"Card={CardLibrary.GetCard(Code).Name}, Ctrl={Controller}, Loc={Location}, Seq={Sequence}, SubSeq={Position}. " +
               $"\nDesc={DescriptionHandler.GetDescription(Description)}";
    }
}