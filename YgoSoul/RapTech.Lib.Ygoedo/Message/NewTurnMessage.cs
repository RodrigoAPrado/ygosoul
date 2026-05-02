using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class NewTurnMessage : SimpleTextMessage
{
    public byte Player { get; }
    public NewTurnMessage(byte player) : base($"Your turn, {player}")
    {
        Player = player;
    }
}