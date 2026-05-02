using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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