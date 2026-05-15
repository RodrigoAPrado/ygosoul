using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class AttackDisabled : SimpleTextMessage
{
    public AttackDisabled() : base("Attack Disabled!")
    {
    }
}