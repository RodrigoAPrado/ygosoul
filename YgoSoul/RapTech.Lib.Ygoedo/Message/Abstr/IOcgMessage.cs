using YgoSoul.RapTech.Lib.Ygoedo.Manager.Interface;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

public interface IOcgMessage : IDuelMessage
{
    int InputCount { get; }
    byte[] GetResponse(List<int> input);
}