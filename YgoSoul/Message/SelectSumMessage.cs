using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class SelectSumMessage : ISelectionsMessage
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
    
    public byte[] GetResponse(int id)
    {
        return GetResponse([id]);
    }
    public byte[] GetResponse(List<int> ids)
    {
        var invalid = ids.Any(x => x >= MustSelect.Count + CanSelect.Count || x < 0);
        
        if (invalid)
            return [];

        if (MustSelect.Count > 0)
        {
            
        }
        
    }
    
    public byte[] Cancel()
    {
        return [];
    }
}