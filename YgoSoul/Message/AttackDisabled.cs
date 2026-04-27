using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class AttackDisabled : SimpleTextMessage
{
    public AttackDisabled() : base("Attack Disabled!")
    {
    }
}