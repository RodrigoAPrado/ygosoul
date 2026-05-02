using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class SwapGraveDeckMessage : BaseMessage
{
    public byte Player { get; }
    public uint ExtraSize { get; }
    public byte[] Data { get; }

    public SwapGraveDeckMessage(byte player, uint extraSize, byte[] data)
    {
        Player = player;
        ExtraSize = extraSize;
        Data = data;
    }

    public override string ToString()
    {
        return $"SwapGraveDeckMessage=[Player={Player}, ExtraSize={ExtraSize}, Data={BitConverter.ToString(Data)}]";
    }
}