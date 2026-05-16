using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class HintCodeMessage : BaseMessage, IHintCodeMessage
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