using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class NewTurnMessage : SimpleTextMessage
{
    public byte Player { get; }
    public NewTurnMessage(byte player) : base($"Your turn, {player}")
    {
        Player = player;
    }
}