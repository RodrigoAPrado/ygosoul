using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class HintMessageAttribute : BaseMessage
{
    public MonsterAttributes Attribute { get; }
    public HintMessageAttribute(MonsterAttributes attribute)
    {
        Attribute = attribute;
    }

    public override string ToString()
    {
        return $"Hint: Attribute={Attribute}";
    }
}