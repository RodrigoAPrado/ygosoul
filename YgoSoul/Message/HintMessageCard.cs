using YgoSoul.DuelRunner;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class HintMessageCard : BaseMessage
{
    public byte Player { get; }
    public uint CardCode { get; }
    public HintMessageCard(byte player, uint cardCode)
    {
        Player = player;
        CardCode = cardCode;
    }

    public override string ToString()
    {
        return $"Hint: Player={Player} Card={CardLibrary.GetCard(CardCode).Name}";
    }
}