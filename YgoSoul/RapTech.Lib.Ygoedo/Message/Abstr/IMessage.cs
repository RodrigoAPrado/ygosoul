using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

public interface IMessage : IOcgMessage
{
    InputType Input { get; }
    int InputCount { get; }
    byte[] GetResponse(int id);
}