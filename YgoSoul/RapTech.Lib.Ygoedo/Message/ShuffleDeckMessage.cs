using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class ShuffleDeckMessage : SimpleTextMessage
{
    public byte Player { get; }
    public ShuffleDeckMessage(byte player) : base($"Shuffle player {player} deck.")
    {
        Player = player;
    }
}