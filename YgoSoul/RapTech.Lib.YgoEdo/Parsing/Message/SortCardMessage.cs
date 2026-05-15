using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class SortCardMessage : ISelectionsMessage
{
    public InputType Input => InputType.Sort;
    public int InputCount => Cards.Count;
    public bool CanCancel => true;
    public byte Player { get; }
    public IReadOnlyList<CardReference> Cards { get; }
    
    public SortCardMessage(byte player, List<CardReference> cards)
    {
        Player = player;
        Cards = cards;
    }

    public byte[] GetResponse(List<int> ids)
    {
        var invalid = ids.Any(x => x >= Cards.Count || x < 0);

        if (invalid)
            return [];

        if (ids.Count != Cards.Count)
            return [];
        
        var response = new byte[ids.Count];
        for (var i = 0; i < ids.Count; i++)
        {
            response[i] = (byte)ids[i];
        }

        return response;
    }

    public byte[] Cancel()
    {
        return [unchecked((byte)-1)];
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player {Player}, reorder the cards inputing their index with commas like a,b,c, or \"Cancel\":");
        foreach (var c in Cards)
        {
            sb.AppendLine($"{CardLibrary.InternalGetCard(c.CardCode).Name}");
        }

        return sb.ToString();
    }
}