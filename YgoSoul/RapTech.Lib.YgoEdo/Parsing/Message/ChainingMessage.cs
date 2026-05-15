using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message;

public class ChainingMessage : BaseMessage
{
    public uint CardCode { get; }
    public byte Player { get; }
    public OCG_CardLocation Location { get; }
    public uint Sequence { get; }
    public OCG_CardPosition Position { get; }
    public byte ActivationPlayer { get; }
    public OCG_CardLocation ActivationLocation { get; }
    public uint ActivationSequence { get; }
    public ulong Description { get; }
    public uint ChainSize { get; }

    public ChainingMessage(uint cardCode, byte player, OCG_CardLocation location, uint sequence, OCG_CardPosition position,
        byte activationPlayer, OCG_CardLocation activationLocation, uint activationSequence, ulong description, uint chainSize)
    {
        CardCode = cardCode;
        Player = player;
        Location = location;
        Sequence = sequence;
        Position = position;
        ActivationPlayer = activationPlayer;
        ActivationLocation = activationLocation;
        ActivationSequence = activationSequence;
        Description = description;
        ChainSize = chainSize;
    }

    public override string ToString()
    {
        return $"Card {CardLibrary.InternalGetCard(CardCode).Name} from " +
               $"Player={Player}, Location={Location}, Sequence={Sequence}, Position={Position}, " +
               $"\nwas activated by Player={ActivationPlayer}, Location={ActivationLocation}, Sequence={ActivationSequence}, " +
               $"\nwith Description={DescriptionHandler.GetDescription(Description)}, Chain Size={ChainSize}";
    }
}
