using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectUnselectedCardMessage : IMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => CardsToSelect.Count + CardsToUnselect.Count;
    public byte Player { get; }
    public bool Finishable { get; }
    public bool Cancelable { get; }
    public uint Min { get; }
    public uint Max { get; }
    public IReadOnlyList<CardReference> CardsToSelect { get; }
    public IReadOnlyList<CardReference> CardsToUnselect { get; }

    public SelectUnselectedCardMessage(
        byte player, 
        bool finishable, 
        bool cancelable, 
        uint min, 
        uint max, 
        List<CardReference> cardsToSelect, 
        List<CardReference> cardsToUnselect)
    {
        Player = player;
        Finishable = finishable;
        Cancelable = cancelable;
        Min = min;
        Max = max;
        CardsToSelect = cardsToSelect;
        CardsToUnselect = cardsToUnselect;
    }
    public byte[] GetResponse(int id)
    {
        if (id < 0 && (Cancelable || Finishable))
            return BitConverter.GetBytes(-1);
        if (id < 0 || id > CardsToSelect.Count + CardsToUnselect.Count)
            return [];

        var response = new byte[8];
        BitConverter.GetBytes(1).CopyTo(response, 0);
        BitConverter.GetBytes(id).CopyTo(response, 4);
        return response;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {Player}, toggle one of the following cards: ");

        if (CardsToSelect.Count > 0)
        {
            sb.AppendLine("SelectableCards: ");
            foreach (var c in CardsToSelect)
            {
                sb.AppendLine($"[{c.Index}] => {CardLibrary.GetCard(c.CardCode).Name}");
            }
        }

        if (CardsToUnselect.Count > 0)
        {
            sb.AppendLine("Cards you can unselect:");
            foreach (var c in CardsToUnselect)
            {
                sb.AppendLine($"[{c.Index + CardsToUnselect.Count}] => {CardLibrary.GetCard(c.CardCode).Name}");
            }
        }

        return sb.ToString();
    }
}