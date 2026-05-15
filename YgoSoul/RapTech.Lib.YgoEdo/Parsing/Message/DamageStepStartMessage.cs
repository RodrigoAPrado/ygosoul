using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class DamageStepStartMessage : BaseMessage
{
    public override string ToString()
    {
        return $"Starting the Damage Step!";
    }
}