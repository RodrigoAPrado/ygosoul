using System.Text;
using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class SortChainMessage : ISelectionsMessage
{
    public InputType Input => InputType.Sort;
    public int InputCount => Cards.Count;
    public bool CanCancel => true;
    public byte Player { get; }
    public IReadOnlyList<CardReference> Cards { get; }
    
    public SortChainMessage(byte player, List<CardReference> cards)
    {
        Player = player;
        Cards = cards;
    }
    
    public byte[] GetResponse(int id)
    {
        if (id == -1)
            return Cancel();
        
        return GetResponse([id]);
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
        sb.AppendLine($"Player {Player}, reorder the chain inputing their index with commas like a,b,c, or \"Cancel\":");
        foreach (var c in Cards)
        {
            sb.AppendLine($"{CardLibrary.InternalGetCard(c.CardCode).Name}");
        }

        return sb.ToString();
    }
}