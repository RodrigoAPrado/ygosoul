using YgoSoul.DuelRunner;
using YgoSoul.Handler;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectEffectYesNoMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => 1;
    public byte Player { get; }
    public CardReference Card { get; }
    public ulong Description { get; }

    public SelectEffectYesNoMessage(byte player, CardReference card, ulong description)
    {
        Player = player;
        Card = card;
        Description = description;
    }
    
    public byte[] GetResponse(int id)
    {
        if (id != 0 && id != 1)
            return [];

        return BitConverter.GetBytes(id);
    }

    public override string ToString()
    {
        return $"\nPlayer {Player}, card effect for card {CardLibrary.GetCard(Card.CardCode).Name}. Description={DescriptionHandler.GetDescription(Description)}\n[0] - No\n[1] - Yes";
    }
}