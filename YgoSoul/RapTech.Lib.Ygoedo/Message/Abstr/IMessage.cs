using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

public interface IMessage : IOcgMessage
{
    int InputCount { get; }
    bool HasResponded { get; }
    bool Validated { get; }
    byte[] GetResponse(List<int> id);
    void SetResponseSet();
    void ResetResponse();
}