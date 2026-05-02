using YgoSoul.RapTech.Lib.Ygoedo.Handler;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class SelectYesNoMessage : IMessage
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
    
    public byte[] GetResponse(int id)
    {
        if (id != 0 && id != 1)
            return [];

        return BitConverter.GetBytes(id);
    }

    public override string ToString()
    {
        return $"Player {Player}, activate effect? Description={DescriptionHandler.GetDescription(Description)}:\n[0] - No\n[1] - Yes";
    }
}