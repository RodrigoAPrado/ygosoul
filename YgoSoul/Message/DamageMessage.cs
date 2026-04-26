using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class DamageMessage : BaseMessage
{
    public byte Player { get; }
    public uint Damage { get; }
    
    public DamageMessage(byte player, uint damage)
    {
        Player = player;
        Damage = damage;
    }

    public override string ToString()
    {
        return $"Player: {Player}, took {Damage} damage!";
    }
}