using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class SwapGraveDeckMessage : BaseMessage, ISwapGraveDeckMessage
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