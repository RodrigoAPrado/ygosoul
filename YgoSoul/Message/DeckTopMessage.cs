using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class DeckTopMessage : SimpleTextMessage
{
    public byte Player { get; }
    public uint CardCode { get; }
    public CardPosition Position { get; }
    
    public DeckTopMessage(byte player, uint cardCode, CardPosition position) 
        : base($"Deck Top - Player {player}, card is {CardLibrary.GetCard(cardCode).Name}, position {position}")
    {
        Player = player;
        CardCode = cardCode;
        Position = position;
    }
}