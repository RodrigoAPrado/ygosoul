using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class FieldDisabledMessage : BaseMessage
{
    public uint Mask { get; }

    public FieldDisabledMessage(uint mask)
    {
        Mask = mask;
    }

    public override string ToString()
    {
        return $"FieldDisabled={Mask:x8}";
    }
}