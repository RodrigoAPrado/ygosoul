using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

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
        sb.AppendLine($"Player {Attacker.Controller} declares attack on Player {Target.Controller}");
        sb.Append($"in {Target.Sequence}, that is {Target.Position}, and on {Target.Location}, with ");
        sb.Append($"a card in {Attacker.Sequence}, that is {Attacker.Position}, and on {Attacker.Location}");
        return sb.ToString();
    }
}