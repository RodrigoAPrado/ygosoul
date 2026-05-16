using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class ChainingMessage : BaseMessage, IChainingMessage
{
    public uint CardCode { get; }
    public IFullLocationReference LocationReference => _locationReference;
    public byte ActivationPlayer { get; }
    public Location ActivationLocation => _activationLocation.ToLocation();
    public uint ActivationSequence { get; }
    public string Description => DescriptionHandler.GetDescription(_description);
    public uint ChainSize { get; }
    private readonly FullLocationReference _locationReference;
    private readonly OCG_CardLocation _activationLocation;
    private readonly ulong _description;

    public ChainingMessage(uint cardCode, FullLocationReference locationReference,
        byte activationPlayer, OCG_CardLocation activationLocation, uint activationSequence, ulong description, uint chainSize)
    {
        CardCode = cardCode;
        _locationReference = locationReference;
        ActivationPlayer = activationPlayer;
        _activationLocation = activationLocation;
        ActivationSequence = activationSequence;
        _description = description;
        ChainSize = chainSize;
    }

    public override string ToString()
    {
        return $"Card {CardLibrary.InternalGetCard(CardCode).Name} from " +
               $"Player={LocationReference.Controller}, Location={LocationReference.Location}, " +
               $"Sequence={LocationReference.Sequence}, Position={LocationReference.Position}, " +
               $"\nwas activated by Player={ActivationPlayer}, Location={ActivationLocation}, Sequence={ActivationSequence}, " +
               $"\nwith Description={Description}, Chain Size={ChainSize}";
    }
}
