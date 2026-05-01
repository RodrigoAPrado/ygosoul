using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class HintMessageAttribute : BaseMessage
{
    public byte Player { get; }
    public MonsterAttributes Attribute { get; }
    public HintMessageAttribute(byte player, MonsterAttributes attribute)
    {
        Player = player;
        Attribute = attribute;
    }

    public override string ToString()
    {
        return $"Hint: Player={Player} Attribute={Attribute}";
    }
}