using System.Text;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectCounterMessage : ISelectionsMessage
{
    public InputType Input => InputType.Sort;
    public int InputCount => Cards.Count;
    public bool CanCancel => false;
    public byte Player { get; }
    public ushort CounterType { get; }
    public ushort CounterAmount { get; }
    public IReadOnlyList<CardReference> Cards { get; }

    public SelectCounterMessage(byte player, ushort counterType, ushort counterAmount, IReadOnlyList<CardReference> cards)
    {
        Player = player;
        CounterType = counterType;
        CounterAmount = counterAmount;
        Cards = cards;
    }
    
    public byte[] GetResponse(int id)
    {
        return GetResponse([id]);
    }
    
    public byte[] GetResponse(List<int> ids)
    {
        if (ids.Count != Cards.Count)
            return [];
        var response = new byte[ids.Count*2];
        var offset = 0;
        
        for (var i = 0; i < ids.Count; i++)
        {
            if (ids[i] > Cards[i].CounterAmount)
                return [];
            
            BitConverter.GetBytes((ushort)ids[i]).CopyTo(response, offset);
            offset += 2;
        }

        return response;
    }

    public byte[] Cancel()
    {
        return [];
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Selec counter from cards, you need {CounterAmount} counters.");
        foreach (var c in Cards)
        {
            sb.AppendLine($"{CardLibrary.GetCard(c.CardCode).Name} has {c.CounterAmount} counters...");
        }

        return sb.ToString();
    }
}