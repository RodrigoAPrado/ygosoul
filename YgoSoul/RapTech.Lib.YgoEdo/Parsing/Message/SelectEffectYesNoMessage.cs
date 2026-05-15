using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class SelectEffectYesNoMessage : IOcgMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => 1;
    public byte Player { get; }
    public CardReference Card { get; }
    public ulong Description { get; }

    public SelectEffectYesNoMessage(byte player, CardReference card, ulong description)
    {
        Player = player;
        Card = card;
        Description = description;
    }
    
    public byte[] GetResponse(List<int> input)
    {
        if (input.Count != 1)
            return [];
        
        var id = input[0];

        if (id != 0 && id != 1)
            return [];

        return BitConverter.GetBytes(id);
        
        throw new NotImplementedException();
    }


    public override string ToString()
    {
        return $"\nPlayer {Player}, card effect for card {CardLibrary.InternalGetCard(Card.CardCode).Name}. Description={DescriptionHandler.GetDescription(Description)}\n[0] - No\n[1] - Yes";
    }
}