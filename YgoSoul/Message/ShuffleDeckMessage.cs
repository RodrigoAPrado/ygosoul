using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class ShuffleDeckMessage : SimpleTextMessage
{
    public byte Player { get; }
    public ShuffleDeckMessage(byte player) : base($"Shuffle player {player} deck.")
    {
        Player = player;
    }
}