using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class DamageStepStartMessage : BaseMessage
{
    public override string ToString()
    {
        return $"Starting the Damage Step!";
    }
}