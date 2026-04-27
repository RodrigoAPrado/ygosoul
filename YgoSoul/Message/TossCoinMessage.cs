using YgoSoul.Flag;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class TossCoinMessage : BaseMessage
{
    public byte Player { get; }
    public IReadOnlyList<CoinResult> Results { get; }

    public TossCoinMessage(byte player, List<CoinResult> results)
    {
        Player = player;
        Results = results;
    }

    public override string ToString()
    {
        return $"TossCoin, Player={Player}, Results=[{string.Join(", ", Results)}]";
    }
}