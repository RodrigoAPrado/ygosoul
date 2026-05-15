using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class TossCoinMessage : BaseMessage
{
    public byte Player { get; }
    public IReadOnlyList<OCG_CoinResult> Results { get; }

    public TossCoinMessage(byte player, List<OCG_CoinResult> results)
    {
        Player = player;
        Results = results;
    }

    public override string ToString()
    {
        return $"TossCoin, Player={Player}, Results=[{string.Join(", ", Results)}]";
    }
}