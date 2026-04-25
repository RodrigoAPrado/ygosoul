using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class UnselectedCardMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => Cards.Count + UnselectedCards.Count;
    public byte Player { get; }
    public bool Finishable { get; }
    public bool Cancelable { get; }
    public uint Min { get; }
    public uint Max { get; }
    public IReadOnlyList<CardReference> Cards { get; }
    public IReadOnlyList<CardReference> UnselectedCards { get; }

    public UnselectedCardMessage(
        byte player, 
        bool finishable, 
        bool cancelable, 
        uint min, 
        uint max, 
        List<CardReference> cards, 
        List<CardReference> unselectedCards)
    {
        Player = player;
        Finishable = finishable;
        Cancelable = cancelable;
        Min = min;
        Max = max;
        Cards = cards;
        UnselectedCards = unselectedCards;
    }
    public byte[] GetResponse(int id)
    {
        if (id < 0 && (Cancelable || Finishable))
            return BitConverter.GetBytes(-1);
        if (id < 0 || id > Cards.Count + UnselectedCards.Count)
            return [];

        var response = new byte[8];
        BitConverter.GetBytes(1).CopyTo(response, 0);
        BitConverter.GetBytes(id).CopyTo(response, 4);

        return response;
    }
}