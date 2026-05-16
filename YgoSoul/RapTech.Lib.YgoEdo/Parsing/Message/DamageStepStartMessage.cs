using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class DamageStepStartMessage : BaseMessage
{
    public override string ToString()
    {
        return $"Starting the Damage Step!";
    }
}