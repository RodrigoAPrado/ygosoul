using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.System.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class SelectEffectYesNoMessage : ISelectionOcgMessage, ISelectEffectYesNoMessage
{
    public InputType Input => InputType.Value;
    public int InputCount => 1;
    public byte Player { get; }
    public ICardReference Card => _card;
    public string Description { get; }
    private readonly CardReference _card;
    private readonly ulong _description;

    public SelectEffectYesNoMessage(byte player, CardReference card, ulong description)
    {
        Player = player;
        _card = card;
        _description = description;
        Description = DescriptionUtil.GetDescription(_description);
    }
    
    public byte[] GetResponse(List<int> input)
    {
        if (input.Count != 1)
            return [];
        
        var id = input[0];

        if (id != 0 && id != 1)
            return [];

        return BitConverter.GetBytes(id);
    }


    public override string ToString()
    {
        return $"\nPlayer {Player}, card effect for card {CardLibrary.InternalGetCard(_card.CardCode).Name}. Description={DescriptionUtil.GetDescription(_description)}\n[0] - No\n[1] - Yes";
    }

    public bool CanCancel => false;
    public byte[] Cancel()
    {
        return [];
    }
}