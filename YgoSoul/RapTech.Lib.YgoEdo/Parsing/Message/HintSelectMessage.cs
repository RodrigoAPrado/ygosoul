using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class HintSelectMessage : BaseHintMessage
{
    public byte Player { get; }
    public ulong Description { get; }

    public HintSelectMessage(byte player, ulong description) : base(
        $"Player {player}, {GetHintText(description)}...")
    {
        Player = player;
        Description = description;
    }
    
    
    private static string GetHintText(ulong hint)
    {
        var rawBits = BitConverter.GetBytes(hint);
        var cardText = BitConverter.ToUInt16(rawBits, 0);
        var cardIdRaw = BitConverter.ToUInt32(rawBits, 2);
        var cardId = cardIdRaw >> 4;
        
        if(CardLibrary.HasCard(cardId))
        {
            return CardLibrary.InternalGetCard(cardId).Strings[cardText];
        }
        
        return System.Enum.IsDefined(typeof(OCG_GameStrings), hint) 
            ? ((OCG_GameStrings)hint).ToString() 
            : CardLibrary.InternalGetCard((uint)hint).Name;
    }
}