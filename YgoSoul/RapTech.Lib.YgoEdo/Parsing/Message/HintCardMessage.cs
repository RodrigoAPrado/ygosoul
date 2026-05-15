using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class HintCardMessage : BaseHintMessage
{
    public byte Player { get; }
    public uint CardCode { get; }

    public HintCardMessage(byte player, uint cardCode) 
        : base($"Hint: Player={player} Card={CardLibrary.InternalGetCard(cardCode).Name}")
    {
        Player = player;
        CardCode = cardCode;
    }

    public override string ToString()
    {
        return $"Hint: Player={Player} Card={CardLibrary.InternalGetCard(CardCode).Name}";
    }
}