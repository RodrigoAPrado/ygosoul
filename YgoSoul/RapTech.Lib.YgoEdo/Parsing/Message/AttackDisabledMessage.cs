using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class AttackDisabledMessage : SimpleTextMessage, IAttackDisabledMessage
{
    public AttackDisabledMessage() : base("Attack Disabled!")
    {
    }
}