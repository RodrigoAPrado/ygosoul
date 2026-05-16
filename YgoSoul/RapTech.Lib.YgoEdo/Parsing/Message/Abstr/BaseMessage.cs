using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

public abstract class BaseMessage : IOcgMessage
{
    public virtual InputType Input => InputType.None;
    public virtual int InputCount => 0;
    public virtual byte[] GetResponse(List<int> input) => [];
}