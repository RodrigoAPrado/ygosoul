using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class DamageStepStartMessage : BaseMessage
{
    public override string ToString()
    {
        return $"Starting the Damage Step!";
    }
}