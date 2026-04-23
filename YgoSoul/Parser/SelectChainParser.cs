using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class SelectChainParser : BaseParser
{
    private const uint SummoningTiming = 0x0; //???
    private const uint MainPhaseEnd = 0x4;
    private const uint SummonTiming = 0x40;
    private const uint DrawphaseTiming = 0x10000;
    private const uint StandbyphaseTiming = 0x200000;
    private const uint DrawStandbyphaseTiming = DrawphaseTiming + StandbyphaseTiming;
    
    protected override IMessage DoParse(byte[] buffer)
    {
        var playerId = buffer[1];
        var effectCount = buffer[2];
        var forcedCount = buffer[3];

        var currentPos = 4;
        var hintTiming = BitConverter.ToUInt32(buffer, currentPos);

        currentPos += 4;
        var hintTiming2 = BitConverter.ToUInt32(buffer, currentPos);

        currentPos += 4;
        var chainSize = BitConverter.ToUInt32(buffer, currentPos);

        if (chainSize > 0)
        {
            return new UnknownMessage(buffer);
        }

        var hintTimmingString = "";
        switch (hintTiming)
        {
            case SummoningTiming:
                hintTimmingString = "Summoning Window";
                break;
            case MainPhaseEnd:
                hintTimmingString = "Main Phase End";
                break;
            case SummonTiming:
                hintTimmingString = "Summoned Window";
                break;
            case DrawphaseTiming:
                hintTimmingString = "Draw Phase";
                break;
            case StandbyphaseTiming:
                hintTimmingString = "Standby Phase";
                break;
            case DrawStandbyphaseTiming:
                hintTimmingString = "Draw and Standby Phase";
                break;
        }

        var hintTimming2String = "";
        switch (hintTiming2)
        {
            case SummoningTiming:
                hintTimming2String = "Summoning Window";
                break;
            case MainPhaseEnd:
                hintTimming2String = "Main Phase End";
                break;
            case SummonTiming:
                hintTimming2String = "Summoned Window";
                break;
            case DrawphaseTiming:
                hintTimming2String = "Draw Phase";
                break;
            case StandbyphaseTiming:
                hintTimming2String = "Standby Phase";
                break;
            case DrawStandbyphaseTiming:
                hintTimming2String = "Draw and Standby Phase";
                break;
        }

        if (hintTimmingString == "" || hintTimming2String == "")
        {
            return new UnknownMessage(buffer);
        }
        
        return new SelectChainMessage(playerId, effectCount, forcedCount, hintTimmingString, hintTimming2String);
    }
}

/*
 *
 *
 *
 
 10-
 00-
 00-
 00-
 00-00-21-00-
 00-00-21-00-
 00-00-00-00-

 * 
 */