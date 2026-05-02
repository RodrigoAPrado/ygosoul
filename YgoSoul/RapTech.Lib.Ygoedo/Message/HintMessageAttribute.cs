using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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