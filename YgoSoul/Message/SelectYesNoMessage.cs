using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectYesNoMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => 1;
    public byte Player { get; }
    public CardReference? Card { get; }
    public ulong Description { get; }

    public SelectYesNoMessage(byte player, CardReference? card, ulong description)
    {
        Player = player;
        Card = card;
        Description = description;
    }
    
    public byte[] GetResponse(int id)
    {
        if (id != 0 && id != 1)
        {
            return [0xFF, 0xFF, 0xFF, 0xFF];
        }

        return BitConverter.GetBytes(id);
    }

    public override string ToString()
    {
        if (Card == null)
            return $"Player {Player}, 0 - No, 1 - Yes";
        return $"\nPlayer {Player}, card effect for card {CardLibrary.GetCard(Card.CardCode).Name}. 0 - No, 1 - Yes";
    }
}