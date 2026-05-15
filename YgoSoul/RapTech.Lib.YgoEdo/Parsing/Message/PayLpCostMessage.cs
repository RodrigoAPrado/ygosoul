using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class PayLpCostMessage : BaseMessage
{
    public byte Player { get; }
    public uint Cost { get; }

    public PayLpCostMessage(byte player, uint cost)
    {
        Player = player;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"Player {Player}, payed {Cost} LP!";
    }
}