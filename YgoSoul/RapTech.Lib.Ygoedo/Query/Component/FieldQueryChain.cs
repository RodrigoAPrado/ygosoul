using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Handler;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

namespace YgoSoul.RapTech.Lib.Ygoedo.Query.Component;

public class FieldQueryChain
{
    public uint CardCode { get; }
    public FullLocationReference Location { get; }
    public byte TriggerController { get; }
    public CardLocation TriggerLocation { get; }
    public uint TriggerSequence { get; }
    public ulong Description { get; }

    public FieldQueryChain(
        uint cardCode, 
        FullLocationReference location, 
        byte triggerController, 
        CardLocation triggerLocation, 
        uint triggerSequence, 
        ulong description
        )
    {
        CardCode = cardCode;
        Location = location;
        TriggerController = triggerController;
        TriggerLocation = triggerLocation;
        TriggerSequence = triggerSequence;
        Description = description;
    }

    public override string ToString()
    {
        return $"FieldQueryChain=[Card={CardLibrary.InternalGetCard(CardCode).Name}, " +
               $"Location=[{Location}], " +
               $"TriggerController={TriggerController}, " +
               $"TriggerLocation={TriggerLocation}, " +
               $"TriggerSequence={TriggerSequence}], " +
               $"Description={DescriptionHandler.GetDescription(Description)}," +
               $"DescriptionHex={Description:x16}]";
    }
}