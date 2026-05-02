using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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