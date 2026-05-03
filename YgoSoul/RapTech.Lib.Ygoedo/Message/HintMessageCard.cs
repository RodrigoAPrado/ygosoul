using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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
        return $"Hint: Player={Player} Card={CardLibrary.InternalGetCard(CardCode).Name}";
    }
}