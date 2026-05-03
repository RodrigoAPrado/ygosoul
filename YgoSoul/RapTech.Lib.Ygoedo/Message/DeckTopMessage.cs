using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class DeckTopMessage : SimpleTextMessage
{
    public byte Player { get; }
    public uint CardCode { get; }
    public CardPosition Position { get; }
    
    public DeckTopMessage(byte player, uint cardCode, CardPosition position) 
        : base($"Deck Top - Player {player}, card is {CardLibrary.InternalGetCard(cardCode).Name}, position {position}")
    {
        Player = player;
        CardCode = cardCode;
        Position = position;
    }
}