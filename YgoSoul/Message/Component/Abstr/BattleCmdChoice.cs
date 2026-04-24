using YgoSoul.Flag;

namespace YgoSoul.Message.Component.Abstr;

public abstract class BattleCmdChoice
{
    public uint Index { get; }

    protected BattleCmdChoice(uint index)
    {
        Index = index;
    }
}