using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

public class EquipMessage : BaseMessage
{
    public FullLocationReference Equipment { get; }
    public FullLocationReference Target { get; }

    public EquipMessage(FullLocationReference equipment, FullLocationReference target)
    {
        Equipment = equipment;
        Target = target;
    }

    public override string ToString()
    {
        return $"Equip, Equipment={Equipment}, Target={Target}";
    }
}