using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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