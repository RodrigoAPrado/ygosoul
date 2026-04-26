using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

public class AttackMessage : BaseMessage
{
    public FullLocationReference Attacker { get; }
    public FullLocationReference Target { get; }
    
    public AttackMessage(FullLocationReference attacker, FullLocationReference target)
    {
        Attacker = attacker;
        Target = target;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {Attacker.Player} declares attack on Player {Target.Player}");
        if (Target.IsLocationEmpty())
        {
            sb.Append($"in {Target.Sequence}, that is {Target.Position}, and on {Target.Location}, with ");
        }
        else
        {
            sb.Append("DIRECTLY! With ");
        }

        sb.Append($"a card in {Attacker.Sequence}, that is {Attacker.Position}, and on {Attacker.Location}");
        return sb.ToString();
    }
}