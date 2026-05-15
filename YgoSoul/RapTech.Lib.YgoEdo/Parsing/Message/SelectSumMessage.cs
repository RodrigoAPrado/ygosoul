using System.Text;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class SelectSumMessage : ISelectionOcgMessage
{
    public InputType Input => InputType.Selections;
    public int InputCount => MustSelect.Count + CanSelect.Count;
    public bool CanCancel => false;
    public byte Player { get; }
    public bool HasMax { get; }
    public uint Acc { get; }
    public uint Min { get; }
    public uint Max { get; }
    public IReadOnlyList<CardReference> MustSelect { get; }
    public IReadOnlyList<CardReference> CanSelect { get; }

    public SelectSumMessage(
        byte player, 
        bool hasMax, 
        uint acc,
        uint min,
        uint max,
        List<CardReference> mustSelect,
        List<CardReference> canSelect
        )
    {
        Player = player;
        HasMax = hasMax;
        Acc = acc;
        Min = min;
        Max = max;
        MustSelect = mustSelect;
        CanSelect = canSelect;
    }
    
    public byte[] GetResponse(List<int> ids)
    {
        var invalid = ids.Any(x => x >= MustSelect.Count + CanSelect.Count || x < 0);
        
        if (invalid)
            return [];

        if (MustSelect.Count > 0)
        {
            foreach (var must in MustSelect)
            {
                if (!ids.Contains((int)must.Index))
                    return [];
            }
        }

        if (HasMax && ids.Count > Max && ids.Count < Min)
            return [];

        var selectedCards = new List<CardReference>();
        
        foreach (var id in ids)
        {
            if (id < MustSelect.Count)
            {
                selectedCards.Add(MustSelect[id]);
                continue;
            }
            selectedCards.Add(CanSelect[id - MustSelect.Count]);
        }

        var tot = (uint) selectedCards.Sum(x => (int) x.Sum);
        if (tot < Acc)
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
        return [];
    }

    public override string ToString()
    {
        var max = "";
        if (HasMax)
        {
            max = $", and you must select between {Min} and {Max} cards";
        }
        var sb = new StringBuilder();
        sb.AppendLine($"You need a sum of {Acc}{max}.");
        if (MustSelect.Count > 0)
            sb.AppendLine("You must select the following cards:");
        foreach (var card in MustSelect)
        {
            sb.AppendLine($"[{card.Index}] => {card}, SumValue={card.Sum}");
        }
        sb.AppendLine("You can select the following cards:");
        foreach (var card in CanSelect)
        {
            sb.AppendLine($"[{card.Index}] => {card}, SumValue={card.Sum}");
        }

        return sb.ToString();
    }
}