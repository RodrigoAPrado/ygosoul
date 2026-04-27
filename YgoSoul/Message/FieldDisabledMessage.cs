using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

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