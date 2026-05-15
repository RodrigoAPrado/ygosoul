using YgoSoul.RapTech.Lib.YgoEdo.Message.Interface.Base;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

public interface IOcgMessage : IDuelMessage
{
    int InputCount { get; }
    byte[] GetResponse(List<int> input);
}