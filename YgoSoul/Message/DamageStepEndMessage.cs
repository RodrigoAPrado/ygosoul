using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class DamageStepEndMessage : BaseMessage
{
    public override string ToString()
    {
        return $"Ending the Damage Step!";
    }
}