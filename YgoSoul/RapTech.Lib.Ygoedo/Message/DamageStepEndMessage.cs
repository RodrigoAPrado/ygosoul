using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class DamageStepEndMessage : BaseMessage
{
    public override string ToString()
    {
        return $"Ending the Damage Step!";
    }
}