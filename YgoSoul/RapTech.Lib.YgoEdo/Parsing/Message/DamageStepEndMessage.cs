using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class DamageStepEndMessage : BaseMessage
{
    public override string ToString()
    {
        return $"Ending the Damage Step!";
    }
}