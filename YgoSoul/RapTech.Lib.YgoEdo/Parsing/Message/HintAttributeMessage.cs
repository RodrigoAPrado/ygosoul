using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class HintAttributeMessage : BaseMessage
{
    public byte Player { get; }
    public OCG_MonsterAttributes Attribute { get; }
    public HintAttributeMessage(byte player, OCG_MonsterAttributes attribute)
    {
        Player = player;
        Attribute = attribute;
    }

    public override string ToString()
    {
        return $"Hint: Player={Player} Attribute={Attribute}";
    }
}