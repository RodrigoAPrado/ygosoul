using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class LpUpdateMessage : BaseMessage
{
    public byte Player { get; }
    public uint Lp { get; }

    public LpUpdateMessage(byte player, uint lp)
    {
        Player = player;
        Lp = lp;
    }

    public override string ToString()
    {
        return $"LP update, Player={Player}, LP={Lp}";
    }
}