using YgoSoul.RapTech.Lib.Ygoedo.Flag;

namespace YgoSoul.RapTech.Lib.Ygoedo.Query.Component;

public class FieldQueryCard
{
    public Zone Zone { get; set; }
    public CardPosition Position { get; }
    public uint XyzMaterials { get; }
    
    public FieldQueryCard(Zone zone, CardPosition position, uint xyzMaterials)
    {
        Zone = zone;
        Position = position;
        XyzMaterials = xyzMaterials;
    }

    public override string ToString()
    {
        return $"Zone={Zone}, Position={Position}, XyzMaterials={XyzMaterials}";
    }
}