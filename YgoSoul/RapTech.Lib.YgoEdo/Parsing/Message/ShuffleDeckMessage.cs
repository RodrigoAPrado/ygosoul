using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ShuffleDeckMessage : SimpleTextMessage
{
    public byte Player { get; }
    public ShuffleDeckMessage(byte player) : base($"Shuffle player {player} deck.")
    {
        Player = player;
    }
}