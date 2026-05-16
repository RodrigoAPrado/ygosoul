using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class HintCodeMessage : BaseMessage
{
    public byte Player { get; }
    public uint CardCode { get; }
    public HintCodeMessage(byte player, uint cardCode)
    {
        Player = player;
        CardCode = cardCode;
    }

    public override string ToString()
    {
        return $"Hint: Player={Player} Card={CardLibrary.InternalGetCard(CardCode).Name}";
    }
}