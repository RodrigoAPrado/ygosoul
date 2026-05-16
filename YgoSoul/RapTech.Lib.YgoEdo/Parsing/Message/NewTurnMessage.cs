using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class NewTurnMessage : SimpleTextMessage
{
    public byte Player { get; }
    public NewTurnMessage(byte player) : base($"Your turn, {player}")
    {
        Player = player;
    }
}