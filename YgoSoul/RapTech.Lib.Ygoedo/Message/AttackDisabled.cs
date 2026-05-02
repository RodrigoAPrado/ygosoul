using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class AttackDisabled : SimpleTextMessage
{
    public AttackDisabled() : base("Attack Disabled!")
    {
    }
}