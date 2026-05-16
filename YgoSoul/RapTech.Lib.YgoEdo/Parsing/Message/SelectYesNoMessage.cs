using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.System.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class SelectYesNoMessage : IOcgMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => 1;

    public byte Player { get; }
    public ulong Description { get; }

    public SelectYesNoMessage(byte player, ulong description)
    {
        Player = player;
        Description = description;
    }
    public byte[] GetResponse(List<int> input)
    {
        if (input.Count != 1)
            return [];
        
        var id = input[0];
        
        if (id != 0 && id != 1)
            return [];

        return BitConverter.GetBytes(id);
    }
    
    public override string ToString()
    {
        return $"Player {Player}, activate effect? Description={DescriptionHandler.GetDescription(Description)}:\n[0] - No\n[1] - Yes";
    }
}