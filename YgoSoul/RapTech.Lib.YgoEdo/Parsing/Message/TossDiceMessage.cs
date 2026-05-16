using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class TossDiceMessage : BaseMessage
{
    public byte Player { get; }
    public IReadOnlyList<byte> Results { get; }

    public TossDiceMessage(byte player, List<byte> results)
    {
        Player = player;
        Results = results;
    }

    public override string ToString()
    {
        return $"TossCoin, Player={Player}, Results=[{string.Join(", ", Results)}]";
    }
}