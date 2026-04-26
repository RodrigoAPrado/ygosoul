using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectCardMessage : ISelectionsMessage
{
    public InputType Input => InputType.Selections;
    public int InputCount => Cards.Count;
    public bool CanCancel => Cancelable;
    public byte Player { get; }
    public bool Cancelable { get; }
    public uint Min { get; }
    public uint Max { get; }
    public IReadOnlyList<CardReference> Cards { get; }

    public SelectCardMessage(byte player, bool cancelable, uint min, uint max, List<CardReference> cards)
    {
        Player = player;
        Cancelable = cancelable;
        Min = min;
        Max = max;
        Cards = cards;
    }
    
    public byte[] GetResponse(int id)
    {
        return GetResponse([id]);
    }

    public byte[] GetResponse(List<int> ids)
    {
        var invalid = ids.Any(x => x >= Cards.Count || x < 0);

        if (invalid)
            return [];
        
        if (ids.Count < Min)
            return [];
        if(ids.Count > Max)
            return [];
        
        var response = new byte[8 + ids.Count * 4];
        var offset = 4;
        
        BitConverter.GetBytes(ids.Count).CopyTo(response, offset);
        offset += 4;
        
        foreach (var i in ids)
        {
            BitConverter.GetBytes(i).CopyTo(response, offset);
            offset += 4;
        }
        return response;
    }

    public byte[] Cancel()
    {
        return BitConverter.GetBytes(-1);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Select at least {Min} cards at most {Max} cards:");
        foreach (var c in Cards)
        {
            sb.AppendLine($"{c.Index} => {CardLibrary.GetCard(c.CardCode).Name}...");
        }

        if (Cancelable)
        {
            sb.AppendLine("Input \"Cancel\" if you want to cancel this selection...");
        }
        else
        {
            sb.AppendLine("You cannot cancel this selection.");
        }

        sb.AppendLine("Input \"Enter\" to finish your selection.");
        return sb.ToString();
    }
}