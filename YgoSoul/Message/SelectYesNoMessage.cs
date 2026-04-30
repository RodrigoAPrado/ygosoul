using YgoSoul.Handler;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

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