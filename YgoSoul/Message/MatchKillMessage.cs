using YgoSoul.DuelRunner;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class MatchKillMessage : BaseMessage
{
    public uint CardCode { get; }

    public MatchKillMessage(uint cardCode)
    {
        CardCode = cardCode;
    }

    public override string ToString()
    {
        return $"MatchKill, Card={CardLibrary.GetCard(CardCode).Name}";
    }
}