using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Handler;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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
        return $"Card {CardLibrary.InternalGetCard(CardCode).Name} from " +
               $"Player={Player}, Location={Location}, Sequence={Sequence}, Position={Position}, " +
               $"\nwas activated by Player={ActivationPlayer}, Location={ActivationLocation}, Sequence={ActivationSequence}, " +
               $"\nwith Description={DescriptionHandler.GetDescription(Description)}, Chain Size={ChainSize}";
    }
}


//46-
//0A-34-40-05-
//00-
//10-
//09-00-00-00-
//05-00-00-00-
//00-
//10-
//09-00-00-00-
//00-00-00-00-00-00-00-00-
//01-00-00-00

