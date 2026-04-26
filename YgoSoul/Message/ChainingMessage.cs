using YgoSoul.Flag;
using YgoSoul.Handler;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;

namespace YgoSoul.Message;

public class ChainingMessage : BaseMessage
{
    public uint CardCode { get; }
    public byte Player { get; }
    public CardLocation Location { get; }
    public uint Sequence { get; }
    public CardPosition Position { get; }
    public byte ActivationPlayer { get; }
    public CardLocation ActivationLocation { get; }
    public uint ActivationSequence { get; }
    public ulong Description { get; }
    public uint ChainSize { get; }

    public ChainingMessage(uint cardCode, byte player, CardLocation location, uint sequence, CardPosition position,
        byte activationPlayer, CardLocation activationLocation, uint activationSequence, ulong description, uint chainSize)
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
        return $"Card {CardLibrary.GetCard(CardCode).Name} from " +
               $"Player={Player}, Location={Location}, Sequence={Sequence}, Position={Position}, " +
               $"\nwas activated by Player={ActivationPlayer}, Location={ActivationLocation}, Sequence={ActivationSequence}, " +
               $"\nwith Description={DescriptionHandler.GetDescription(Description)}, Chain Size={ChainSize}";
    }
}