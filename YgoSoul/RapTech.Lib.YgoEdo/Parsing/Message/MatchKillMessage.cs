using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class MatchKillMessage : BaseMessage
{
    public uint CardCode { get; }

    public MatchKillMessage(uint cardCode)
    {
        CardCode = cardCode;
    }

    public override string ToString()
    {
        return $"MatchKill, Card={CardLibrary.InternalGetCard(CardCode).Name}";
    }
}