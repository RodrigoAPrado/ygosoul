using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class DeckTopMessage : SimpleTextMessage
{
    public byte Player { get; }
    public uint CardCode { get; }
    public OCG_CardPosition Position { get; }
    
    public DeckTopMessage(byte player, uint cardCode, OCG_CardPosition position) 
        : base($"Deck Top - Player {player}, card is {CardLibrary.InternalGetCard(cardCode).Name}, position {position}")
    {
        Player = player;
        CardCode = cardCode;
        Position = position;
    }
}