using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class SetMessage : BaseMessage
{
    public uint CardCode { get; }
    public byte Player { get; }
    public CardLocation Location { get; }
    public uint Sequence { get; }
    public CardPosition Position { get; }
    
    public SetMessage(uint cardCode, byte player, CardLocation location, uint sequence, CardPosition position) 
    {
        CardCode = cardCode;
        Player = player;
        Location = location;
        Sequence = sequence;
        Position = position;
    }

    public override string ToString()
    {
        return $"{CardLibrary.GetCard(CardCode).Name} is being set for " +
               $"{Player} on {Location} in sequence {Sequence} and position {Position}";
    }
}