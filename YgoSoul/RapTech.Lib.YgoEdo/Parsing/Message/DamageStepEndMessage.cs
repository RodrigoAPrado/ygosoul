using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class DamageStepEndMessage : BaseMessage
{
    public override string ToString()
    {
        return $"Ending the Damage Step!";
    }
}