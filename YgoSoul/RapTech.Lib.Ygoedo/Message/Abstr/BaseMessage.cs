using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

public abstract class BaseMessage : IOcgMessage
{
    public virtual InputType Input => InputType.None;
    public virtual int InputCount => 0;
    public virtual byte[] GetResponse(List<int> input) => [];
}