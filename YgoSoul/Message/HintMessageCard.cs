using YgoSoul.DuelRunner;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class HintMessageCard : BaseMessage
{
    public uint CardCode { get; }
    public HintMessageCard(uint cardCode)
    {
        CardCode = cardCode;
    }

    public override string ToString()
    {
        return $"Hint: Card={CardLibrary.GetCard(CardCode).Name}";
    }
}